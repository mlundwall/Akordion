namespace ToneGenerator
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Media;

    class MainClass
    {
        static protected readonly String[] toneS = { "C", "Cis", "D", "Dis", "E", "F", "Fis", "G", "Gis", "A", "Ais", "H" };
        static protected readonly byte halvtoner = 12;
        private static SoundPlayer player = new SoundPlayer();
        private static readonly String ResPos = @"C:\Dev\Akordion\Resources\";
        public static void Main()
        {
            for (int tpos = 0; tpos < halvtoner; tpos++)
            {
                // Log10 440 = 2,64355 - Log10 880 = 2,9445 - Interval (dif/12 = 0.02508583)
                int hz = Convert.ToInt32(Math.Round(Math.Pow(10, 2.64355 + (0.02508583 * tpos))));
                lavtone((double)hz, toneS[tpos]);
            }

            // player.LoadCompleted += new AsyncCompletedEventHandler(Player_LoadCompleted);
            for (int tpos = 0; tpos < halvtoner; tpos++)
            {

                player.SoundLocation = ResPos + toneS[tpos] + ".wav";
                // Load the .wav file.
                //   player.LoadAsync();
                player.Play();
            }
        }

        static void Player_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (player.IsLoadCompleted)
            {
                try
                {
                    player.PlaySync();
                }
                catch { }
            }
        }
        public static void lavtone(double tone, string navn)
        {
            FileStream stream = new FileStream(ResPos + navn + ".wav", FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
            int RIFF = 0x46464952;
            int WAVE = 0x45564157;
            int formatChunkSize = 16;
            int headerSize = 8;
            int format = 0x20746D66;
            short formatType = 1;
            short tracks = 1;
            int samplesPerSecond = 44100;
            short bitsPerSample = 16;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int data = 0x61746164;
            int samples = 88200; // *4
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
            writer.Write(RIFF);
            writer.Write(fileSize);
            writer.Write(WAVE);
            writer.Write(format);
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(data);
            writer.Write(dataChunkSize);
            double ampl = 10000;
            double concert = 1.498307077;
            double freq = tone * concert;
            for (int i = 0; i < samples / 4; i++)
            {
                double t = (double)i / (double)samplesPerSecond;
                short s = (short)(ampl * (Math.Sin(t * freq * 2.0 * Math.PI)));
                writer.Write(s);
            }

            writer.Close();
            stream.Close();
        }
    }
}