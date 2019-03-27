namespace Heliograph.Settings
{
    [System.Serializable]
    public class MicrophoneSettings
    {
        public static int Frequency = 44100;
        public static int MaxAudioClipSamples = 100 * Frequency;
        public static int AudioTransmissionChannels = 1;
    }
}
