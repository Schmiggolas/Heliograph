using System;

namespace Heliograph.Packets
{
    [Serializable]
    public class AudioPacket
    {
        public float[] samples;

        public AudioPacket(float[] samples)
        {
            this.samples = samples;
        }
        public AudioPacket()
        {

        }
    }
}