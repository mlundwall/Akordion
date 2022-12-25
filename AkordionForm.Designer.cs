namespace Akordion
{
    partial class Akordion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("C Dur / A Mol");
            this.Toneart = new System.Windows.Forms.ComboBox();
            this.Skalatype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.paralelltoneart = new System.Windows.Forms.Label();
            this.Nodebillede = new System.Windows.Forms.PictureBox();
            this.Tone1 = new System.Windows.Forms.ComboBox();
            this.Tone2 = new System.Windows.Forms.ComboBox();
            this.Tone3 = new System.Windows.Forms.ComboBox();
            this.Resultatliste = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.Nodebillede)).BeginInit();
            this.SuspendLayout();
            // 
            // Toneart
            // 
            this.Toneart.FormattingEnabled = true;
            this.Toneart.Location = new System.Drawing.Point(12, 14);
            this.Toneart.Name = "Toneart";
            this.Toneart.Size = new System.Drawing.Size(43, 21);
            this.Toneart.TabIndex = 4;
            this.Toneart.Text = "C";
            this.Toneart.SelectedIndexChanged += new System.EventHandler(this.Toneart_SelectedIndexChanged);
            // 
            // Skalatype
            // 
            this.Skalatype.FormattingEnabled = true;
            this.Skalatype.Items.AddRange(new object[] {
            "Dur",
            "Mol"});
            this.Skalatype.Location = new System.Drawing.Point(58, 14);
            this.Skalatype.Name = "Skalatype";
            this.Skalatype.Size = new System.Drawing.Size(42, 21);
            this.Skalatype.TabIndex = 5;
            this.Skalatype.Text = "Dur";
            this.Skalatype.SelectedIndexChanged += new System.EventHandler(this.Skalatype_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(16, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(92, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(130, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Crimson;
            this.label5.Location = new System.Drawing.Point(169, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(207, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(246, 86);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "-";
            // 
            // paralelltoneart
            // 
            this.paralelltoneart.AutoSize = true;
            this.paralelltoneart.Location = new System.Drawing.Point(9, 38);
            this.paralelltoneart.Name = "paralelltoneart";
            this.paralelltoneart.Size = new System.Drawing.Size(80, 13);
            this.paralelltoneart.TabIndex = 23;
            this.paralelltoneart.Text = "Paralleltoneart: ";
            // 
            // Nodebillede
            // 
            this.Nodebillede.Location = new System.Drawing.Point(123, 9);
            this.Nodebillede.Margin = new System.Windows.Forms.Padding(0);
            this.Nodebillede.Name = "Nodebillede";
            this.Nodebillede.Size = new System.Drawing.Size(119, 64);
            this.Nodebillede.TabIndex = 24;
            this.Nodebillede.TabStop = false;
            // 
            // Tone1
            // 
            this.Tone1.FormattingEnabled = true;
            this.Tone1.Location = new System.Drawing.Point(18, 121);
            this.Tone1.Name = "Tone1";
            this.Tone1.Size = new System.Drawing.Size(43, 21);
            this.Tone1.TabIndex = 25;
            this.Tone1.Text = "C";
            this.Tone1.SelectedIndexChanged += new System.EventHandler(this.Tone1_SelectedIndexChanged);
            // 
            // Tone2
            // 
            this.Tone2.FormattingEnabled = true;
            this.Tone2.Location = new System.Drawing.Point(67, 121);
            this.Tone2.Name = "Tone2";
            this.Tone2.Size = new System.Drawing.Size(43, 21);
            this.Tone2.TabIndex = 26;
            this.Tone2.Text = "E";
            this.Tone2.SelectedIndexChanged += new System.EventHandler(this.Tone2_SelectedIndexChanged);
            // 
            // Tone3
            // 
            this.Tone3.FormattingEnabled = true;
            this.Tone3.Location = new System.Drawing.Point(117, 121);
            this.Tone3.Name = "Tone3";
            this.Tone3.Size = new System.Drawing.Size(43, 21);
            this.Tone3.TabIndex = 27;
            this.Tone3.Text = "G";
            this.Tone3.SelectedIndexChanged += new System.EventHandler(this.Tone3_SelectedIndexChanged);
            // 
            // Resultatliste
            // 
            this.Resultatliste.HideSelection = false;
            this.Resultatliste.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.Resultatliste.Location = new System.Drawing.Point(343, 121);
            this.Resultatliste.Name = "Resultatliste";
            this.Resultatliste.Size = new System.Drawing.Size(114, 56);
            this.Resultatliste.TabIndex = 28;
            this.Resultatliste.UseCompatibleStateImageBehavior = false;
            this.Resultatliste.SelectedIndexChanged += new System.EventHandler(this.Resultatliste_SelectedIndexChanged);
            // 
            // Akordion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(469, 221);
            this.Controls.Add(this.Resultatliste);
            this.Controls.Add(this.Tone3);
            this.Controls.Add(this.Tone2);
            this.Controls.Add(this.Tone1);
            this.Controls.Add(this.Nodebillede);
            this.Controls.Add(this.paralelltoneart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Skalatype);
            this.Controls.Add(this.Toneart);
            this.Controls.Add(this.label1);
            this.Name = "Akordion";
            this.Text = "Akordion";
            this.Load += new System.EventHandler(this.Akordion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nodebillede)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Toneart;
        private System.Windows.Forms.ComboBox Skalatype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label paralelltoneart;
        private System.Windows.Forms.PictureBox Nodebillede;
        private System.Windows.Forms.ComboBox Tone1;
        private System.Windows.Forms.ComboBox Tone2;
        private System.Windows.Forms.ComboBox Tone3;
        private System.Windows.Forms.ListView Resultatliste;
    }
}

