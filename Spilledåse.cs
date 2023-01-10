using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Akordion
{
    /*************************
    *            ROD         *
    *            ---         *
    **************************/

    class SpilledåseRod
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        static extern bool Beep(uint dwFreq, uint dwDuration);

        protected readonly String[] toneS = { "C", "Cis", "D", "Dis", "E", "F", "Fis", "G", "Gis", "A", "Ais", "H" };
        protected readonly String[] toneB = { "C", "Des", "D", "Es", "E", "F", "Ges", "G", "As", "A", "bB", "H" };
        protected readonly byte[] Dur = { 2, 2, 1, 2, 2, 2, 1 };
        protected readonly byte[] Mol = { 2, 1, 2, 2, 1, 2, 2 };
        protected readonly byte halvtoner = 12;
        protected readonly byte heltoner = 7;
        protected String sparalelltoneart;
        protected Label[] NodeLabel = new Label[7];
        protected ComboBox ToneArt;
        protected ComboBox SkalaType;
        protected CheckBox Lyde;

        public SpilledåseRod(
            Label pL1, Label pL2, Label pL3, Label pL4, Label pL5, Label pL6, Label pL7,
            ComboBox pToneArt,
            ComboBox pSkalatype,
            CheckBox pLyde
            )
        {
            // tildeler lokale variable
            // Labels fyldes
            NodeLabel[0] = pL1; NodeLabel[1] = pL2; NodeLabel[2] = pL3;
            NodeLabel[3] = pL4; NodeLabel[4] = pL5; NodeLabel[5] = pL6;
            NodeLabel[6] = pL7;
            ToneArt = pToneArt;
            SkalaType = pSkalatype;
            Lyde = pLyde;

            // Tonelister fyldes
            for (int i = 0; i < halvtoner; i++)
                ToneArt.Items.Add(toneS[i]);

            ToneArt.SelectedIndexChanged += new EventHandler(ToneArt_SelectedIndexChanged);
            SkalaType.SelectedIndexChanged += new EventHandler(Skalatype_SelectedIndexChanged);
        } // Slut på Construktor for Spilledåse

        protected void LavToneart
        /*
           Laver skala ud fra om det skal være dur eller mol og hvilket havltone-trin skalaen skal starte på
        */
        (
            int tpos,                       // Starttone 0-11 = C-H
            in int skalatype,               // 0 Dur eller 1 Mol
            out String[] skala,             // De 7 toner i tonearten
            out bool kryds,                 // Om det er b eller kryds
            out string toneart,             // Toneartens navn
            out string paralelltoneart      // Parraleltoneartens navn
        )
        {
            skala = new String[heltoner];   // Her ligger vi skalaen
            String[] Tone =                 // Her henter vi tone-navne fra
                new String[heltoner];
            String tonetype;                // Om tonearten er dur eller mol
            String ptonetype;               // Om paralelltonearten er dur eller mol
            int ppos;                       // Starttone for parraleltonearten
            byte[] tonalitet =              // Dur eller Mol i antal halvtonetrin
                (skalatype == 0) ? Dur : Mol;

            // Angiver dur/mol som string, og beregner paralelltoneartens placering            
            if (skalatype == 0)
            {
                ppos = (tpos + halvtoner - 3) % halvtoner;
                tonetype = "dur";
                ptonetype = "mol";
            }
            else
            {
                ppos = (tpos + 3) % halvtoner;
                tonetype = "mol";
                ptonetype = "dur";
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
            Tone = (kryds) ? toneS : toneB;

            for (int j = 0, t = tpos; j < heltoner; j++)
            {
                skala[j] = Tone[t];
                t += tonalitet[j];
                t %= halvtoner;
            }

            // Danner tonearten og paralelltoneartens betegnelser
            toneart = Tone[tpos] + " " + tonetype;
            paralelltoneart = Tone[ppos] + " " + ptonetype;
        }

        protected virtual void Visskala(int tpos, int skalatype, ref Label[] labels)
        {
            bool kryds;
            String toneart;
            String[] skala = new string[heltoner];

            LavToneart(tpos, skalatype, out skala, out kryds, out toneart, out sparalelltoneart);

            for (int j = 0; j < heltoner; j++)
            {
                labels[j].Text = skala[j];
                labels[j].MouseHover += new System.EventHandler(Spiltone);
            }
            if (Lyde.Checked)
                Spilskala();
        }

        protected virtual void ToneArt_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala(ToneArt.SelectedIndex, SkalaType.SelectedIndex, ref NodeLabel);
        }

        protected virtual void Skalatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala(ToneArt.SelectedIndex, SkalaType.SelectedIndex, ref NodeLabel);
        }

        protected bool Match(byte[] T, byte[] D, byte starti)
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
        private void Spil(String s)
        {
            int tpos = 0;
            for (int t = 0; t < halvtoner; t++)
                if (s == toneS[t] || s == toneB[t])
                    tpos = t;
            // Log10 440 = 2,64355 - Log10 880 = 2,9445 - Interval (dif/12 = 0.02508583)
            int hz = Convert.ToInt32(Math.Round(Math.Pow(10, 2.64355 + (0.02508583 * tpos))));
            Console.Beep(hz, 300);
        }

        protected virtual void Spilskala()
        {
            for (int i = 0; i < heltoner; i++)
                Spil(NodeLabel[i].Text);
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
                Spilskala();
        }

    } // Slut på SpilledåseRod class

    /*************************
    *          HOVED         *
    *          -----         *
    *************************/

    class SpilledåseHoved : SpilledåseRod
    { // Start SpilledåseHoved class

        Label paralellToneart;
        ListBox Resultatliste;
        PictureBox Nodebillede;
        List<int> Resultater = new List<int>();
        static int ABoxe = 5;
        ComboBox[] ABox = new ComboBox[ABoxe];
        protected Form parentForm;

        public SpilledåseHoved(
            Form pparentForm,
            Label pL1, Label pL2, Label pL3, Label pL4, Label pL5, Label pL6, Label pL7,
            ComboBox pToneArt,
            ComboBox pSkalatype,
            CheckBox pLyde,
            ComboBox pAkord1, ComboBox pAkord2, ComboBox pAkord3,
            ComboBox pAkord4, ComboBox pAkord5,
            Label pparalellToneart,
            PictureBox pNodebillede,
            ListBox pResultatliste
            ) :
            base(pL1, pL2, pL3, pL4, pL5, pL6, pL7, pToneArt, pSkalatype, pLyde)
        {
            parentForm = pparentForm;
            paralellToneart = pparalellToneart;
            Nodebillede = pNodebillede;
            Resultatliste = pResultatliste;
            // Antal akordbokse
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
                    ABox[i].Items.Add(toneS[j]);
                }
                ABox[i].SelectedIndex = 0;

                ABox[i].SelectedIndexChanged += new System.EventHandler(Akord_SelectedIndexChanged);
            }
            ToneArt.SelectedIndex = 0;
            SkalaType.SelectedIndex = 0;
        }

        protected void PutBillede(int t)
        {
            string s = System.Reflection.Assembly.GetExecutingAssembly().Location;            
            s = System.IO.Path.GetDirectoryName(s) + "\\..\\..\\Resources\\";
            switch (t)
            {
                case 0: { Nodebillede.Image= Image.FromFile(s + "C-dur.png"); break; }
                case 1: { Nodebillede.Image = Image.FromFile(s + "Des-dur.png"); break; }
                case 2: { Nodebillede.Image = Image.FromFile(s + "D-dur.png"); break; }
                case 3: { Nodebillede.Image = Image.FromFile(s + "Es-dur.png"); break; }
                case 4: { Nodebillede.Image = Image.FromFile(s + "E-dur.png"); break; }
                case 5: { Nodebillede.Image = Image.FromFile(s + "F-dur.png"); break; }
                case 6: { Nodebillede.Image = Image.FromFile(s + "Fis-dur.png"); break; }
                case 7: { Nodebillede.Image = Image.FromFile(s + "G-dur.png"); break; }
                case 8: { Nodebillede.Image = Image.FromFile(s + "As-dur.png"); break; }
                case 9: { Nodebillede.Image = Image.FromFile(s + "A-dur.png"); break; }
                case 10: { Nodebillede.Image = Image.FromFile(s + "Hes-dur.png"); break; }
                case 11: { Nodebillede.Image = Image.FromFile(s + "H-Dur.png"); break; }
                default: { Nodebillede.Image = Image.FromFile(s + "C-dur.png"); break; }
            }
        }
        protected override void Visskala(int tpos, int skalatype, ref Label[] labels)
        {
            base.Visskala(tpos, skalatype, ref labels);
            paralellToneart.Text = sparalelltoneart;
            PutBillede(ToneArt.SelectedIndex);
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
                        Resultatliste.Items.Add(toneS[tpos] + " dur / " + toneS[(tpos + halvtoner - 3) % halvtoner] + " mol");
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
                SkalaType.SelectedIndex = 0;
                ToneArt.SelectedIndex = Resultater.ElementAt(Resultatliste.SelectedIndex);
                Visskala(ToneArt.SelectedIndex, SkalaType.SelectedIndex, ref NodeLabel);
            }
        }

        protected override void Spilskala()
        {
            parentForm.Update();
            base.Spilskala();
        }


    } // Slut SpilledåseHoved class

        /*************************
        *          TRANS         *
        *          -----         *
        *************************/

    class SpilledåseTrans : SpilledåseRod
    { // Start SpilledåseTrans class
        ComboBox TransBox;
        CheckBox TilGreb;

        public SpilledåseTrans(Form pparentForm, 
            Label pL1, Label pL2, Label pL3, Label pL4, Label pL5, Label pL6, Label pL7,
            ComboBox pToneArt,
            ComboBox pSkalatype,
            CheckBox pLyde,
            ComboBox pTransBox,
            CheckBox pTilGreb) :
        base(pL1, pL2, pL3, pL4, pL5, pL6, pL7, pToneArt, pSkalatype, pLyde)
        {
            TransBox = pTransBox;
            TilGreb = pTilGreb;

            TransBox.SelectedIndex = 1;
            ToneArt.SelectedIndex = 0;
            SkalaType.SelectedIndex = 0;

            TransBox.SelectedIndexChanged += new EventHandler(TransBox_SelectedIndexChanged);
            TilGreb.CheckedChanged += new EventHandler(TilGreb_CheckedChanged);
        }

        protected override void Visskala(int tpos, int skalatype, ref Label[] labels)
        {
            int Es;
            int bB;

            if (TilGreb.Checked) { Es = 3; bB = 12 - 2; } else { Es = 12 - 3; bB = 2; };
            if (ToneArt.SelectedIndex<0)
                ToneArt.SelectedIndex=0;
            switch (TransBox.SelectedIndex)
            {
                case (1): tpos = (ToneArt.SelectedIndex + Es) % halvtoner; break;// Sopraksax Es
                case (2): tpos = (ToneArt.SelectedIndex + bB) % halvtoner; break;// Klarinet  bB
                default: tpos = ToneArt.SelectedIndex; break;  // Lige over
            };
            base.Visskala(tpos, skalatype, ref labels);
        }
        protected void TransBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala(ToneArt.SelectedIndex, SkalaType.SelectedIndex, ref NodeLabel);
        }

        private void TilGreb_CheckedChanged(object sender, EventArgs e)
        {
            if (TilGreb.Checked) TilGreb.Text = "Til greb"; else TilGreb.Text = "Til noder";
            Visskala(ToneArt.SelectedIndex, SkalaType.SelectedIndex, ref NodeLabel);
        }

    } // Slut SpilledåseTrans class

} // Tilføjet til namespace Akkordion
