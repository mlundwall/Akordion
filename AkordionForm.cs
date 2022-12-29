using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.Versioning;

//Todo: Billeder af tonearternes kryds/b-er indsættes i "Nodebillede"
//Todo: Icon indsættes
//Todo: Flere kommentarer

namespace Akordion
{
    public partial class Akordion : Form
    {//                             0    1      2    3      4    5    6      7    8      9    10     11       
        readonly String[] Tones = { "C", "Cis", "D", "Dis", "E", "F", "Fis", "G", "Gis", "A", "Ais", "H" };
        readonly String[] Toneb = { "C", "Des", "D", "Es",  "E", "F", "Ges", "G", "As",  "A", "Bb",  "H" };
        readonly byte[] Dur = { 2, 2, 1, 2, 2, 2, 1 };
        readonly byte[] Mol = { 2, 1, 2, 2, 1, 2, 2 };
        readonly byte halvtoner = 12;
        readonly byte heltoner = 7;
        // Antal akordbokse
        readonly static int ABoxe = 5;
        ComboBox[] ABox = new ComboBox[ABoxe];
        List<int> Resultater = new List<int>();

        public Akordion()
        {
            InitializeComponent();
        }

        public void LavToneart
        /*
           Laver skala ud fra om det skal være dur eller mol og hvilket havltone-trin skalaen skal starte på
        */
        (
            in int skalatype,               // 0 Dur eller 1 Mol
            int tpos,                       // Starttone 0-11 = C-H
            out String[] skala,             // De 7 toner i tonearten
            out bool kryds,                 // Om det er b eller kryds
            out string toneArt,             // Toneartens navn
            out string parallelToneArt      // Parraleltoneartens navn
        )
        {
            skala = new String[heltoner];   // Her ligger vi skalaen
            String[] Tone =                 // Her henter vi tone-navne fra
                new String[heltoner];
            String toneType;                // Om tonearten er dur eller mol
            String pToneType;               // Om paralelltonearten er dur eller mol
            int ppos;                       // Starttone for parraleltonearten
            byte[] tonalitet =              // Dur eller Mol i antal halvtonetrin
                (skalatype == 0) ? Dur : Mol;

            // Angiver dur/mol som string, og beregner paralelltoneartens placering            
            if (skalatype == 0)
            {
                ppos = (tpos + halvtoner - 3) % halvtoner;
                toneType = "dur";
                pToneType = "mol";
            }
            else
            {
                ppos = (tpos + 3) % halvtoner;
                toneType = "mol";
                pToneType = "dur";
            };

            // Finder ud af om der skal krydser eller b'er for
            if (
                (skalatype == 0 &&
                (tpos == 0 || tpos == 2 || tpos == 4 || tpos == 7 || tpos == 9 || tpos == 11))
                ||
                (skalatype == 1 &&
                (tpos == 1 || tpos == 3 || tpos == 4 || tpos == 6 || tpos == 8 || tpos == 9 || tpos == 11))
               )
                kryds = true;
            else
                kryds = false;

            // Finder tonenavne ud fra om der skulle krydser eller b'er for
            Tone = (kryds) ? Tones : Toneb;

            for (int j = 0, t = tpos; j < heltoner; j++)
            {
                skala[j] = Tone[t];
                t += tonalitet[j];
                t %= halvtoner;
            }

            // Danner tonearten og paralelltoneartens betegnelser
            toneArt = Tone[tpos] + " " + toneType;
            parallelToneArt = Tone[ppos] + " " + pToneType;
        }

        public void Visskala()
        {
            int tpos;
            String[] skala = new String[7];
            bool kryds;
            String toneArt;
            String parallelToneArt;

            tpos = Toneart.SelectedIndex;
            LavToneart(Skalatype.SelectedIndex, tpos, out skala, out kryds, out toneArt, out parallelToneArt);

            Label[] labels = new Label[15];
            labels[0] = label1; labels[1] = label2; labels[2] = label3;
            labels[3] = label4; labels[4] = label5; labels[5] = label6;
            labels[6] = label7;

            for (int j = 0; j < heltoner; j++)
            {
                labels[j].Text = skala[j];
            }
            paralelltoneart.Text = "Paraleltoneart: " + parallelToneArt;
            // Nodebillede.Image = Akordion.Properties.Resources.C_dur;

        }

        public void FyldAkordlister()
        {
            for (int i = 0; i < ABoxe; i++)
            {
                ABox[i].Items.Clear();
                ABox[i].Items.Add("-");
                for (int j = 0; j < halvtoner; j++)
                {
                    ABox[i].Items.Add(Tones[j]);
                }
                ABox[i].SelectedIndex = 0;

                ABox[i].SelectedIndexChanged += new System.EventHandler(Akord_SelectedIndexChanged);

            }
        }
        private void Akordion_Load(object sender, EventArgs e)
        {
            Skalatype.SelectedIndex = 0; // Dur
            // Toneliste fyldes
            for (int i = 0; i < halvtoner; i++)
                Toneart.Items.Add(Tones[i]);
            Toneart.SelectedIndex = 0;

            // Fylder akkord-lister
            ABox[0] = Akord1;
            ABox[1] = Akord2;
            ABox[2] = Akord3;
            ABox[3] = Akord4;
            ABox[4] = Akord5;
            FyldAkordlister();
        }

        private void Toneart_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala();
        }

        private void Skalatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala();
        }

        private bool Match(byte[] T, byte[] D, byte starti)
        {
            byte[] DD = new byte[heltoner];
            byte Dsum = starti;
            // Initierer DD udfra D: intervaller til positioner
            for (byte i = 0; i < heltoner; i++)
            {
                DD[i] = Convert.ToByte(Dsum % halvtoner);
                Dsum += Convert.ToByte(D[Convert.ToByte(i % heltoner)]);
            }
            // Tjekker at alle T'er har tilhørende positioner
            bool match = true;
            for (int i = 0; (i < T.Length) && match; i++)
            { // Tjek alle T'er
                bool fundet = false;
                for (int j = 0; (j < heltoner) && !fundet; j++)
                { // Tjek at de findes i DD
                    if (T[i] == DD[j])
                        fundet = true;
                }
                if (!fundet)
                    match = false;
            }
            return (match);
        }

        private void Akord_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<byte> Tonerække = new List<byte>();
            byte[] T;

            Resultatliste.Items.Clear();
            Resultater.Clear();
            Tonerække.Clear();
            for (int j = 0; j < ABoxe; j++)
                if (ABox[j].SelectedIndex > 0)
                    if (!Tonerække.Contains(Convert.ToByte(ABox[j].SelectedIndex - 1)))
                        Tonerække.Add(Convert.ToByte(ABox[j].SelectedIndex - 1));

            Tonerække.Sort();

            // Putter dem i selecterne i rigtig rækkefølge
            for (int i = 0; i < ABoxe; i++)
            {
                ABox[i].SelectedIndexChanged -= Akord_SelectedIndexChanged;
                if (i < Tonerække.Count)
                    ABox[i].SelectedIndex = Tonerække.ElementAt(i) + 1;
                else
                    ABox[i].SelectedIndex = 0;
                ABox[i].SelectedIndexChanged += new System.EventHandler(Akord_SelectedIndexChanged);
            }

            if (Tonerække.Count > 2)
            {
                T = new byte[Convert.ToByte(Tonerække.Count)];
                for (byte i = 0; i < Tonerække.Count; i++)
                {
                    T[i] = Convert.ToByte(Tonerække.ElementAt(i));
                }

                // T indeholder nu tonespringene i Akorden i halvtoner
                // Vi prøver med forskellige tonearter, først dur:
                for (byte tpos = 0; tpos < halvtoner; tpos++)
                {
                    if (Match(T, Dur, tpos)) // der er et match
                    {
                        Resultatliste.Items.Add(Tones[tpos] + " dur / " + Tones[(tpos + halvtoner - 3) % halvtoner] + " mol");
                        Resultater.Add(tpos);
                    }
                }
                if (Resultater.Count > 0)
                {
                    Resultatliste.SelectedIndex = 0;
                    Resultatliste_Click(null, null);
                }
            }
        }

        private void Resultatliste_Click(object sender, EventArgs e)
        {
            if (Resultater.Count > 0)
            {
                Skalatype.SelectedIndex = 0;
                Toneart.SelectedIndex = Resultater.ElementAt(Resultatliste.SelectedIndex);
                Visskala();
            }
        }

    }
}
