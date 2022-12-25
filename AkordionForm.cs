using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

//Todo: Tone1 - Tone3 udvides til fem toner, og boksen skal udfyldes med den / de tonearter, der indeholder disse toner
//Todo: Billeder af tonearternes kryds/b-er indsættes i "Nodebillede"

namespace Akordion
{
    public partial class Akordion : Form
    {//                             0    1      2    3      4    5    6      7    8      9    10     11       
        readonly String[] Tones = { "C", "Cis", "D", "Dis", "E", "F", "Fis", "G", "Gis", "A", "Ais", "H" };
        readonly String[] Toneb = { "C", "Des", "D", "Es", "E", "F", "Ges", "G", "As", "A", "Bb", "H" };
        readonly byte[] Dur = { 2, 2, 1, 2, 2, 2, 1 };
        List<int> dur = new List<int>();
        readonly byte[] Mol = { 2, 1, 2, 2, 1, 2, 2 };
        readonly byte halvtoner = 12;
        readonly byte heltoner = 7;

        public Akordion()
        {
            InitializeComponent();
            for (int n = 0; n < heltoner; n++)
                dur.Add(Dur[n]);
        }

        public void LavToneart
          (
            in int skalatype,             // 0 Dur eller 1 Mol
            int tpos,                     // Starttone 0-11 = C-H
            out bool kryds,               // Om det er b eller kryds
            out String[] tone,            // De 7 toner i tonearten
            out string parallelToneArt    // Parraleltoneartens navn
          )
        {
            byte[] skala;                 // Dur eller Mol i antal halvtonetrin

            skala = (skalatype == 0) ? Dur : Mol;
            tone = new String[heltoner];
            String[] Tone = new String[heltoner];
            String pToneType;
            int ppos;

            if (skalatype == 0)
            {
                ppos = (9 + tpos) % halvtoner;
                pToneType = "mol";
            }
            else
            {
                ppos = (3 + tpos) % halvtoner;
                pToneType = "dur";
            };

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

            Tone = (kryds) ? Tones : Toneb;

            for (int j = 0; j < heltoner; j++)
            {
                tone[j] = Tone[tpos];
                tpos += skala[j];
                tpos %= halvtoner;
            }

            parallelToneArt = Tone[ppos] + " " + pToneType;
        }

        public void Visskala()
        {
            int tpos = Toneart.SelectedIndex;
            String[] tone = new String[7];
            String parallelToneArt;
            bool kryds;

            LavToneart(Skalatype.SelectedIndex, tpos, out kryds, out tone, out parallelToneArt);

            Label[] labels = new Label[15];
            labels[0] = label1; labels[1] = label2; labels[2] = label3;
            labels[3] = label4; labels[4] = label5; labels[5] = label6;
            labels[6] = label7;

            for (int j = 0; j < heltoner; j++)
            {
                labels[j].Text = tone[j];
            }
            paralelltoneart.Text = "Paraleltoneart: " + parallelToneArt;
        }

        public void Fyld123(int start)
        {
            Tone2.Items.Clear();
            Tone2.Items.Add("-");
            Tone3.Items.Clear();
            Tone3.Items.Add("-");
            for (int i = start; i < start + halvtoner; i++)
            {
                Tone2.Items.Add(Tones[(i + 1) % halvtoner]);
                Tone3.Items.Add(Tones[(i + 2) % halvtoner]);
            }
            Tone2.SelectedIndex = 3;
            Tone3.SelectedIndex = 5;
        }
        private void Akordion_Load(object sender, EventArgs e)
        {
            Skalatype.SelectedIndex = 0;
            for (int i = 0; i < halvtoner; i++)
                Toneart.Items.Add(Tones[i]);
            Toneart.SelectedIndex = 0;

            Tone1.Items.Add("-");
            for (int i = 0; i < halvtoner; i++)
                Tone1.Items.Add(Tones[i]);

            Tone1.SelectedIndex = 1;
        }

        private void sharpBox_CheckboxCanged(object sender, EventArgs e)
        {
            // Danskala_Click(null, null);
        }

        private void Toneart_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala();
        }

        private void Skalatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Visskala();
        }

        private void Tone1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> Tonerække = new List<int>();
            int[] T;
            Fyld123(Tone1.SelectedIndex);
            Tonerække.Clear();
            Tonerække.Add(Tone1.SelectedIndex);
            Tonerække.Add(Tone2.SelectedIndex);
            Tonerække.Add(Tone3.SelectedIndex);
            Tonerække.Sort();
            while (Tonerække.ElementAt(0) == 0)
                Tonerække.RemoveAt(0);
            T = new int[Tonerække.Count-1];
            for (int i = 1; i < Tonerække.Count; i++)
                T[i - 1] = Tonerække.ElementAt(i) - Tonerække.ElementAt(i - 1);

        }

        private void Tone2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tone3.SelectedIndex = Tone2.SelectedIndex + 1;
        }

        private void Tone3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tone2.SelectedIndex = Tone1.SelectedIndex + 1;

        }

        private void Resultatliste_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
