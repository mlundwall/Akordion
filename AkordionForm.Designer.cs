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
            this.Akord1 = new System.Windows.Forms.ComboBox();
            this.Akord2 = new System.Windows.Forms.ComboBox();
            this.Akord3 = new System.Windows.Forms.ComboBox();
            this.Akord4 = new System.Windows.Forms.ComboBox();
            this.Akord5 = new System.Windows.Forms.ComboBox();
            this.Resultatliste = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(15, 60);
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
            this.label2.Location = new System.Drawing.Point(53, 60);
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
            this.label3.Location = new System.Drawing.Point(91, 60);
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
            this.label4.Location = new System.Drawing.Point(129, 60);
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
            this.label5.Location = new System.Drawing.Point(168, 60);
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
            this.label6.Location = new System.Drawing.Point(206, 60);
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
            this.label7.Location = new System.Drawing.Point(245, 60);
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
            this.Nodebillede.Location = new System.Drawing.Point(343, 14);
            this.Nodebillede.Margin = new System.Windows.Forms.Padding(0);
            this.Nodebillede.Name = "Nodebillede";
            this.Nodebillede.Size = new System.Drawing.Size(119, 64);
            this.Nodebillede.TabIndex = 24;
            this.Nodebillede.TabStop = false;
            // 
            // Akord1
            // 
            this.Akord1.FormattingEnabled = true;
            this.Akord1.Location = new System.Drawing.Point(14, 112);
            this.Akord1.Name = "Akord1";
            this.Akord1.Size = new System.Drawing.Size(43, 21);
            this.Akord1.TabIndex = 25;
            this.Akord1.Text = "C";
            // 
            // Akord2
            // 
            this.Akord2.FormattingEnabled = true;
            this.Akord2.Location = new System.Drawing.Point(65, 112);
            this.Akord2.Name = "Akord2";
            this.Akord2.Size = new System.Drawing.Size(43, 21);
            this.Akord2.TabIndex = 26;
            this.Akord2.Text = "E";
            // 
            // Akord3
            // 
            this.Akord3.FormattingEnabled = true;
            this.Akord3.Location = new System.Drawing.Point(115, 112);
            this.Akord3.Name = "Akord3";
            this.Akord3.Size = new System.Drawing.Size(43, 21);
            this.Akord3.TabIndex = 27;
            this.Akord3.Text = "G";
            // 
            // Akord4
            // 
            this.Akord4.FormattingEnabled = true;
            this.Akord4.Location = new System.Drawing.Point(166, 112);
            this.Akord4.Name = "Akord4";
            this.Akord4.Size = new System.Drawing.Size(43, 21);
            this.Akord4.TabIndex = 29;
            this.Akord4.Text = "G";
            // 
            // Akord5
            // 
            this.Akord5.FormattingEnabled = true;
            this.Akord5.Location = new System.Drawing.Point(217, 112);
            this.Akord5.Name = "Akord5";
            this.Akord5.Size = new System.Drawing.Size(43, 21);
            this.Akord5.TabIndex = 30;
            this.Akord5.Text = "G";
            // 
            // Resultatliste
            // 
            this.Resultatliste.FormattingEnabled = true;
            this.Resultatliste.Location = new System.Drawing.Point(343, 110);
            this.Resultatliste.Name = "Resultatliste";
            this.Resultatliste.Size = new System.Drawing.Size(116, 56);
            this.Resultatliste.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Toneliste";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(345, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "I tonearten ";
            // 
            // Akordion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(469, 179);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Resultatliste);
            this.Controls.Add(this.Akord5);
            this.Controls.Add(this.Akord4);
            this.Controls.Add(this.Akord3);
            this.Controls.Add(this.Akord2);
            this.Controls.Add(this.Akord1);
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
        private System.Windows.Forms.ComboBox Akord1;
        private System.Windows.Forms.ComboBox Akord2;
        private System.Windows.Forms.ComboBox Akord3;
        private System.Windows.Forms.ComboBox Akord4;
        private System.Windows.Forms.ComboBox Akord5;
        private System.Windows.Forms.ListBox Resultatliste;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

