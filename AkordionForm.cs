using System.Windows.Forms;

//Done: Billeder af tonearternes kryds/b-er indsættes i "Nodebillede"
//Done: Icon indsættes
//Done: Tonerækker skal pakkes i objekter
//Todo: Flere kommentarer

namespace Akordion
{
    public partial class Akordion : Form
    {

        public Akordion()
        {
            InitializeComponent();
        }

        private void Akordion_Load(object sender, System.EventArgs e)
        {
            SpilledåseRod.RessourcePos = @"\..\..\Resources\";
            new SpilledåseHoved(this, label1, label2, label3, label4, label5, label6, label7, Toneart, Skalatype, Lyde, Akord1, Akord2, Akord3, Akord4, Akord5, paralelltoneartlabel, Nodebillede, Resultatliste);
            new SpilledåseTrans(this, labelT1, labelT2, labelT3, labelT4, labelT5, labelT6, labelT7, ToneartT, SkalatypeT, Lyde, TransBox, TilGreb);
        }

    } // Slut på Akordion class

} // Slut på Namespace