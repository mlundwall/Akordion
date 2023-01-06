/*
  Særlige
Hovedside-version
Parametre:
PictureBox pNodebillede,
ListBox pResultatliste

Label paralellToneart;
ListBox Resultatliste;
Og:
List<int> Resultater = new List<int>();
--
Resultatliste = pResultatliste;
Nodebillede = pNodebillede;


Tranpose-version
----------------
Parametre:
CheckBox pTilGreb,
ComboBox pTransBox,

Lokale:
PictureBox Nodebillede;
CheckBox TilGreb;
ComboBox TransBox;
--
TilGreb = pTilGreb;
TransBox = pTransBox;
*/

namespace Akordion
{
    public class SpilledåseRod
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool Beep(uint dwFreq, uint dwDuration);

        readonly String[] Tones = { "C", "Cis", "D", "Dis", "E", "F", "Fis", "G", "Gis", "A", "Ais", "H" };
        readonly String[] Toneb = { "C", "Des", "D", "Es", "E", "F", "Ges", "G", "As", "A", "bB", "H" };
        readonly byte[] Dur = { 2, 2, 1, 2, 2, 2, 1 };
        readonly byte[] Mol = { 2, 1, 2, 2, 1, 2, 2 };
        readonly byte halvtoner = 12;
        readonly byte heltoner = 7;
        Label[] label = new Label[7];
        ComboBox ToneArt;
        ComboBox Skalatype;

        public SpilledåseRod(
            Label l1, Label l2, Label l3, Label l4, Label l5, Label l6, Label l7,
            ComboBox pToneArt,
            ComboBox pSkalatype,
            ComboBox pAkord1, ComboBox pAkord2, ComboBox pAkord3,
            ComboBox pAkord4, ComboBox pAkord5,
            )
        {
            // tildeler lokale variable
            // Labels fyldes
            label[0] = l1; label[1] = l2; label[2] = l3;
            label[3] = l4; label[4] = l5; label[5] = l6;
            label[6] = l7;
            ToneArt = pToneArt;
            Skalatype = pSkalatype;
            // Antal akordbokse
            readonly static int ABoxe = 5;
            ComboBox[] ABox = new ComboBox[ABoxe];
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
            Skalatype.SelectedIndex = 0; // Dur

            // Tonelister fyldes
            for (int i = 0; i < halvtoner; i++)
                ToneArt.Items.Add(Tones[i]);
            // Lister initieres
            ToneArt.SelectedIndex = 0;
            TransBox.SelectedIndex = 1;

            // Fylder akkord-lister
            ABox[0] = pAkord1;
            ABox[1] = pAkord2;
            ABox[2] = pAkord3;
            ABox[3] = pAkord4;
            ABox[4] = pAkord5;
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
        } // Slut på Construktor for Spilledåse

        public void LavToneart
        /*
           Laver skala ud fra om det skal være dur eller mol og hvilket havltone-trin skalaen skal starte på
        */
        (
            int tpos,                       // Starttone 0-11 = C-H
            in int skalatype,               // 0 Dur eller 1 Mol
            out String[] skala,             // De 7 toner i tonearten
            out bool kryds,                 // Om det er b eller kryds
            out string toneArt,             // Toneartens navn
            out string paralelltoneart      // Parraleltoneartens navn
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
            paralelltoneart = Tone[ppos] + " " + pToneType;
        }

        public void PutBillede(int t)
        {
            switch (t)
            {
                case 0: { Nodebillede.Image = (System.Drawing.Image)(Resources.C_dur); break; }
                case 1: { Nodebillede.Image = (System.Drawing.Image)(Resources.Des_dur); break; }
                case 2: { Nodebillede.Image = (System.Drawing.Image)(Resources.D_dur); break; }
                case 3: { Nodebillede.Image = (System.Drawing.Image)(Resources.Es_dur); break; }
                case 4: { Nodebillede.Image = (System.Drawing.Image)(Resources.E_dur); break; }
                case 5: { Nodebillede.Image = (System.Drawing.Image)(Resources.F_dur); break; }
                case 6: { Nodebillede.Image = (System.Drawing.Image)(Resources.Fis_dur); break; }
                case 7: { Nodebillede.Image = (System.Drawing.Image)(Resources.G_dur); break; }
                case 8: { Nodebillede.Image = (System.Drawing.Image)(Resources.As_dur); break; }
                case 9: { Nodebillede.Image = (System.Drawing.Image)(Resources.A_dur); break; }
                case 10: { Nodebillede.Image = (System.Drawing.Image)(Resources.Hes_dur); break; }
                case 11: { Nodebillede.Image = (System.Drawing.Image)(Resources.H_Dur); break; }
                default: { Nodebillede.Image = (System.Drawing.Image)(Resources.C_dur); break; }
            }

        }

        public void Visskala(int tpos, int skalatype, ref Label[] labels)
        {
            bool kryds;
            String toneArt;
            String parallelToneArt;
            String[] skala = new string[heltoner];

            LavToneart(tpos, skalatype, out skala, out kryds, out toneArt, out parallelToneArt);

            for (int j = 0; j < heltoner; j++)
            {
                labels[j].Text = skala[j];
            }
            paralelltoneart.Text = "Paraleltoneart: " + parallelToneArt;

            if (labels[0] == label[0]) // Vi fylder i hovedskalaen
                if (Skalatype.SelectedIndex == 0)
                    PutBillede(tpos);
                else // Hvis det er mol, vælger vi paralleltoneartens billede
                    PutBillede((tpos + 3) % halvtoner);
            this.Update();
            if (Lyde.Checked)
                Spilskala();
        }

        private void Toneart_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala(ToneArt.SelectedIndex, Skalatype.SelectedIndex, ref label);
        }

        private void Skalatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala(ToneArt.SelectedIndex, Skalatype.SelectedIndex, ref label);
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
                Visskala(Toneart.SelectedIndex, Skalatype.SelectedIndex, ref label);
            }
        }

        private void ToneartT_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala();
        }

        private void SkalatypeT_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala();
        }

        private void TransBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala();
        }

        private void TilGreb_CheckedChanged(object sender, EventArgs e)
        {
            if (TilGreb.Checked) TilGreb.Text = "Til greb"; else TilGreb.Text = "Til noder";
            VisskalaT();
        }

        private void Spil(String s)
        {
            int tpos = 0;
            for (int t = 0; t < halvtoner; t++)
                if (s == Tones[t] || s == Toneb[t])
                    tpos = t;
            // Log10 440 = 2,64355 - Log10 880 = 2,9445 - Interval (dif/12 = 0.02508583)
            int hz = Convert.ToInt32(Math.Round(Math.Pow(10, 2.64355 + (0.02508583 * tpos))));
            Console.Beep(hz, 300);
        }

        private void Spilskala()
        {
            for (int i = 0; i < heltoner; i++)
                Spil(label[i].Text);
        }
        private void SpilskalaT()
        {
            for (int i = 0; i < heltoner; i++)
                Spil(labelT[i].Text);
        }

        private void Spiltone(object sender, EventArgs e)
        {
            if (Lyde.Checked)
            {
                Label l;
                l = (Label)sender;
                Spil(l.Text);
            }
        }

        private void Lyde_CheckedChanged(object sender, EventArgs e)
        {
            if (Lyde.Checked)
                if (Tabsider.SelectedIndex == 0)
                    Spilskala();
                else
                    SpilskalaT();
        }

    } // Slut på Spilledåse class

} // Tilføjet til namespace Akkordion
