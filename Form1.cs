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
    {
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
            byte[] skala;
            System.Windows.Forms.Label[] labels = new System.Windows.Forms.Label[15];
            labels[0]  = label1;
            labels[1]  = label2;
            labels[2]  = label3;
            labels[3]  = label4;
            labels[4]  = label5;
            labels[5]  = label6;
            labels[6]  = label7;
            labels[7]  = label8;
            labels[8]  = label9;
            labels[9]  = label10;
            labels[10] = label11;
            labels[11] = label12;
            labels[12] = label13;
            labels[13] = label14;
            labels[14] = label15;
            if (Skalatype.SelectedIndex == 0)
                skala = Dur;
            else
                skala = Mol;

            int tpos = 0 + Toneart.SelectedIndex;
            for (int j = 0; j < 2 * heltoner + 1; j++)
            {
                if (sharpToner.Checked)
                    labels[j].Text = Tone[tpos];
                else
                    labels[j].Text = Toneb[tpos];
                tpos += skala[j % heltoner];
                tpos = tpos % halvtoner;
            }
        }
        private void Danskala_Click(object sender, EventArgs e)
        {
            Visskala();
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
            Danskala_Click(null, null);
        }

        private void Toneart_SelectedIndexChanged(object sender, EventArgs e)
        {
            Danskala_Click(null, null);
        }

        private void Skalatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Danskala_Click(null, null);
        }

    }
}
