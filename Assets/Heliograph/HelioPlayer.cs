using UnityEngine;
using Heliograph.Settings;
using Heliograph.Packets;

namespace Heliograph
{
    [AddComponentMenu("Audio/Heliograph/HelioPlayer")]
    public class HelioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        private int lastSamplePlayed;

        void OnEnable()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        public void UpdateSoundSamples(AudioPacket sound)
        {
            if (!audioSource.isPlaying)
            {
                InitialiseAudioSource();
            }

            audioSource.clip.SetData(sound.samples, lastSamplePlayed);

            if (!audioSource.isPlaying)
            {
                audioSource.PlayDelayed(0.1f);
            }

            lastSamplePlayed = (lastSamplePlayed + sound.samples.Length) % MicrophoneSettings.MaxAudioClipSamples;
        }

        private void InitialiseAudioSource()
        {
            lastSamplePlayed = 0;
            audioSource.clip = AudioClip.Create("TransmittedAudio", MicrophoneSettings.MaxAudioClipSamples,
                MicrophoneSettings.AudioTransmissionChannels, MicrophoneSettings.Frequency, false);
        }
    }
}