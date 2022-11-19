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
        readonly String[] Tone = { "C", "Cis", "D", "Dis", "E", "F", "Fis", "G", "Gis", "A", "Ais", "H" };
        readonly String[] Toneb = { "C", "Des", "D", "Es", "E", "F", "Ges", "G", "As", "A", "Bb", "H" };
        readonly byte[] Dur = { 2, 2, 1, 2, 2, 2, 1 };
        readonly byte[] Mol = { 2, 1, 2, 2, 1, 2, 2 };
        readonly byte halvtoner = 12;
        readonly byte heltoner = 7;

        public Akordion()
        {
            InitializeComponent();
        }

        public void Visskala()
        {
            byte[] skala = (Skalatype.SelectedIndex == 0) ? Dur : Mol;

            int tpos = Toneart.SelectedIndex;

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

            String[] tone = (sharpToner) ? Tone : Toneb;

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
                Toneart.Items.Add(Tone[i]);
            Toneart.SelectedIndex = 0;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
