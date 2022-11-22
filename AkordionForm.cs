using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akordion
{
    public partial class Akordion : Form
    {//                             0    1      2    3      4    5    6      7    8      9    10     11       
        readonly String[] Tones = { "C", "Cis", "D", "Dis", "E", "F", "Fis", "G", "Gis", "A", "Ais", "H" };
        readonly String[] Toneb = { "C", "Des", "D", "Es", "E", "F", "Ges", "G", "As", "A", "Bb", "H" };
        readonly byte[] Dur = { 2, 2, 1, 2, 2, 2, 1 };
        readonly byte[] Mol = { 2, 1, 2, 2, 1, 2, 2 };
        readonly byte halvtoner = 12;
        readonly byte heltoner = 7;

        public Akordion()
        {
            InitializeComponent();
        }

        public void LavToneart
          (
            in int skalatype,             // 0 Dur eller 1 Mol
            int tpos,                     // Starttone 0-11
            out String[] tone,            // De 7 toner
            out string parallelToneArt    // Parraleltonearten
          )
        {
            bool sharpToner;              // Om det er sharp eller flat
            byte[] skala = (skalatype == 0) ? Dur : Mol;
            tone = new String[7];

            if (
                (Skalatype.SelectedIndex == 0 &&
                (tpos == 0 || tpos == 2 || tpos == 4 || tpos == 7 || tpos == 9 || tpos == 11))
                ||
                (Skalatype.SelectedIndex == 1 &&
                (tpos == 1 || tpos == 3 || tpos == 4 || tpos == 6 || tpos == 8 || tpos == 9 || tpos == 11))
               )
                sharpToner = true;
            else
                sharpToner = false;

            String[] Tone = (sharpToner) ? Tones : Toneb;

            for (int j = 0; j < heltoner; j++)
            {
                tone[j] = Tone[tpos];
                tpos += skala[j % heltoner];
                tpos %= halvtoner;
            }

            String pToneType;
            if (Skalatype.SelectedIndex == 0)
            {
                tpos = (9 + Toneart.SelectedIndex) % halvtoner;
                pToneType = "mol";
            }
            else
            {
                tpos = (3 + Toneart.SelectedIndex) % halvtoner;
                pToneType = "dur";
            };

            parallelToneArt = tone[tpos] + " " + pToneType;
        }

        public void Visskala()
        {
            byte[] skala = (Skalatype.SelectedIndex == 0) ? Dur : Mol;

            int tpos = Toneart.SelectedIndex;

            bool sharpToner;

            if (
                (Skalatype.SelectedIndex == 0 &&
                (tpos == 0 || tpos == 2 || tpos == 4 || tpos == 7 || tpos == 9 || tpos == 11))
                ||
                (Skalatype.SelectedIndex == 1 &&
                (tpos == 1 || tpos == 3 || tpos == 4 || tpos == 6 || tpos == 8 || tpos == 9 || tpos == 11))
               )
                sharpToner = true;
            else
                sharpToner = false;

            String[] tone = (sharpToner) ? Tones : Toneb;

            System.Windows.Forms.Label[] labels = new System.Windows.Forms.Label[15];
            labels[0] = label1; labels[1] = label2; labels[2] = label3;
            labels[3] = label4; labels[4] = label5; labels[5] = label6;
            labels[6] = label7;

            for (int j = 0; j < heltoner; j++)
            {
                labels[j].Text = tone[tpos];
                tpos += skala[j % heltoner];
                tpos %= halvtoner;
            }

            String pToneType;
            if (Skalatype.SelectedIndex == 0)
            {
                tpos = (9 + Toneart.SelectedIndex) % halvtoner;
                pToneType = "mol";
            }
            else
            {
                tpos = (3 + Toneart.SelectedIndex) % halvtoner;
                pToneType = "dur";
            };

            paralelltoneart.Text = "Paraleltoneart: " + tone[tpos] + " " + pToneType;
        }

        private void Akordion_Load(object sender, EventArgs e)
        {
            Skalatype.SelectedIndex = 0;
            for (int i = 0; i < halvtoner; i++)
            {
                Toneart.Items.Add(Tones[i]);
                Tone1.Items.Add(Tones[i]);
                Tone2.Items.Add(Tones[i]);
                Tone3.Items.Add(Tones[i]);
            }
            Toneart.SelectedIndex = 0;
            Tone1.SelectedIndex = 0;
            Tone2.SelectedIndex = 2;
            Tone3.SelectedIndex = 4;
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

        }

        private void Tone2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Tone3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
