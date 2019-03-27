using UnityEngine;
using Mirror;
using Heliograph.Settings;
using Heliograph.Packets;

namespace Heliograph
{
    [AddComponentMenu("Audio/Heliograph/HelioRecorder")]
    public class HelioRecorder : NetworkBehaviour
    {
        public MicrophoneSettings settings;
        private AudioClip clipToTransmit;
        private int lastSampleOffset;

        private void Start()
        {
            if (!isLocalPlayer) return;
            clipToTransmit = Microphone.Start(null, true, 10, MicrophoneSettings.Frequency);
        }

        private void OnDisable()
        {
            if (!isLocalPlayer) return;
            Microphone.End(null);
        }

        private void FixedUpdate()
        {
            if (!isLocalPlayer) return;
            int currentMicSamplePosition = Microphone.GetPosition(null);
            int samplesToTransmit = GetSampleTransmissionCount(currentMicSamplePosition);
            if (samplesToTransmit > 0)
            {
                TransmitSamples(samplesToTransmit);
                lastSampleOffset = currentMicSamplePosition;
            }
        }

        private int GetSampleTransmissionCount(int currentMicrophoneSample)
        {
            int sampleTransmissionCount = currentMicrophoneSample - lastSampleOffset;
            if (sampleTransmissionCount < 0)
            {
                sampleTransmissionCount = (clipToTransmit.samples - lastSampleOffset) + currentMicrophoneSample;
            }
            return sampleTransmissionCount;
        }

        private void TransmitSamples(int sampleCountToTransmit)
        {
            float[] samplesToTransmit = new float[sampleCountToTransmit * clipToTransmit.channels];
            clipToTransmit.GetData(samplesToTransmit, lastSampleOffset);
            CmdSendAudio(new AudioPacket(samplesToTransmit));
        }

        [Command]
        public void CmdSendAudio(AudioPacket audio)
        {
            foreach (var connection in NetworkServer.connections)
            {
                if (connection.Value != connectionToClient)
                {
                    TargetPlayAudio(connection.Value, audio);
                }
            }
        }

        [TargetRpc]
        public void TargetPlayAudio(NetworkConnection target, AudioPacket audio)
        {
            GetComponent<HelioPlayer>().UpdateSoundSamples(audio);
        }
    }
}
