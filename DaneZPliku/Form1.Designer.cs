namespace DaneZPlikuOkienko
{
    partial class DaneZPliku
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
            this.btnWybierzSystemTestowy = new System.Windows.Forms.Button();
            this.tbSciezkaDoSystemuTestowego = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSciezkaDoSystemuTreningowego = new System.Windows.Forms.TextBox();
            this.btnWybierzSystemTreningowy = new System.Windows.Forms.Button();
            this.tbSystemTestowy = new System.Windows.Forms.TextBox();
            this.tbSystemTreningowy = new System.Windows.Forms.TextBox();
            this.tbWyniki = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cBox = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWybierzSystemTestowy
            // 
            this.btnWybierzSystemTestowy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWybierzSystemTestowy.Location = new System.Drawing.Point(900, 10);
            this.btnWybierzSystemTestowy.Margin = new System.Windows.Forms.Padding(2);
            this.btnWybierzSystemTestowy.Name = "btnWybierzSystemTestowy";
            this.btnWybierzSystemTestowy.Size = new System.Drawing.Size(32, 19);
            this.btnWybierzSystemTestowy.TabIndex = 0;
            this.btnWybierzSystemTestowy.Text = "...";
            this.btnWybierzSystemTestowy.UseVisualStyleBackColor = true;
            this.btnWybierzSystemTestowy.Click += new System.EventHandler(this.btnWybierzSystemTestowy_Click);
            // 
            // tbSciezkaDoSystemuTestowego
            // 
            this.tbSciezkaDoSystemuTestowego.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSciezkaDoSystemuTestowego.Location = new System.Drawing.Point(189, 10);
            this.tbSciezkaDoSystemuTestowego.Margin = new System.Windows.Forms.Padding(2);
            this.tbSciezkaDoSystemuTestowego.Name = "tbSciezkaDoSystemuTestowego";
            this.tbSciezkaDoSystemuTestowego.ReadOnly = true;
            this.tbSciezkaDoSystemuTestowego.Size = new System.Drawing.Size(708, 20);
            this.tbSciezkaDoSystemuTestowego.TabIndex = 1;
            this.tbSciezkaDoSystemuTestowego.Click += new System.EventHandler(this.btnWybierzSystemTestowy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ścieżka do systemu testowego";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStart.Location = new System.Drawing.Point(707, 487);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 35);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Pracuj";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ścieżka do systemu treningowego";
            // 
            // tbSciezkaDoSystemuTreningowego
            // 
            this.tbSciezkaDoSystemuTreningowego.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSciezkaDoSystemuTreningowego.Location = new System.Drawing.Point(189, 36);
            this.tbSciezkaDoSystemuTreningowego.Margin = new System.Windows.Forms.Padding(2);
            this.tbSciezkaDoSystemuTreningowego.Name = "tbSciezkaDoSystemuTreningowego";
            this.tbSciezkaDoSystemuTreningowego.ReadOnly = true;
            this.tbSciezkaDoSystemuTreningowego.Size = new System.Drawing.Size(708, 20);
            this.tbSciezkaDoSystemuTreningowego.TabIndex = 5;
            this.tbSciezkaDoSystemuTreningowego.Click += new System.EventHandler(this.btnWybierzSystemTreningowy_Click);
            // 
            // btnWybierzSystemTreningowy
            // 
            this.btnWybierzSystemTreningowy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWybierzSystemTreningowy.Location = new System.Drawing.Point(900, 36);
            this.btnWybierzSystemTreningowy.Margin = new System.Windows.Forms.Padding(2);
            this.btnWybierzSystemTreningowy.Name = "btnWybierzSystemTreningowy";
            this.btnWybierzSystemTreningowy.Size = new System.Drawing.Size(32, 19);
            this.btnWybierzSystemTreningowy.TabIndex = 6;
            this.btnWybierzSystemTreningowy.Text = "...";
            this.btnWybierzSystemTreningowy.UseVisualStyleBackColor = true;
            this.btnWybierzSystemTreningowy.Click += new System.EventHandler(this.btnWybierzSystemTreningowy_Click);
            // 
            // tbSystemTestowy
            // 
            this.tbSystemTestowy.Location = new System.Drawing.Point(12, 67);
            this.tbSystemTestowy.Multiline = true;
            this.tbSystemTestowy.Name = "tbSystemTestowy";
            this.tbSystemTestowy.Size = new System.Drawing.Size(129, 453);
            this.tbSystemTestowy.TabIndex = 11;
            // 
            // tbSystemTreningowy
            // 
            this.tbSystemTreningowy.Location = new System.Drawing.Point(147, 67);
            this.tbSystemTreningowy.Multiline = true;
            this.tbSystemTreningowy.Name = "tbSystemTreningowy";
            this.tbSystemTreningowy.Size = new System.Drawing.Size(100, 454);
            this.tbSystemTreningowy.TabIndex = 12;
            // 
            // tbWyniki
            // 
            this.tbWyniki.Location = new System.Drawing.Point(253, 67);
            this.tbWyniki.Multiline = true;
            this.tbWyniki.Name = "tbWyniki";
            this.tbWyniki.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbWyniki.Size = new System.Drawing.Size(676, 413);
            this.tbWyniki.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBox);
            this.groupBox2.Location = new System.Drawing.Point(253, 487);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 44);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Metoda";
            // 
            // cBox
            // 
            this.cBox.FormattingEnabled = true;
            this.cBox.Items.AddRange(new object[] {
            "Euklidesa",
            "Canberra",
            "Manhattan",
            "Czebyszewa",
            "Pearsona"});
            this.cBox.Location = new System.Drawing.Point(6, 13);
            this.cBox.Name = "cBox";
            this.cBox.Size = new System.Drawing.Size(146, 21);
            this.cBox.TabIndex = 0;
            this.cBox.SelectedIndexChanged += new System.EventHandler(this.cBox_SelectedIndexChanged);
            // 
            // DaneZPliku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 533);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbWyniki);
            this.Controls.Add(this.tbSystemTreningowy);
            this.Controls.Add(this.tbSystemTestowy);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnWybierzSystemTreningowy);
            this.Controls.Add(this.tbSciezkaDoSystemuTreningowego);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSciezkaDoSystemuTestowego);
            this.Controls.Add(this.btnWybierzSystemTestowy);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(529, 413);
            this.Name = "DaneZPliku";
            this.Text = "Dane z pliku";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWybierzSystemTestowy;
        private System.Windows.Forms.TextBox tbSciezkaDoSystemuTestowego;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSciezkaDoSystemuTreningowego;
        private System.Windows.Forms.Button btnWybierzSystemTreningowy;
        private System.Windows.Forms.TextBox tbSystemTestowy;
        private System.Windows.Forms.TextBox tbSystemTreningowy;
        private System.Windows.Forms.TextBox tbWyniki;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cBox;
    }
}

