
namespace SasukosKodas
{
    partial class UCAntras
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.KoduotiButton = new System.Windows.Forms.Button();
            this.tekstoTextBox = new System.Windows.Forms.TextBox();
            this.tikimybesTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SiustiButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.kanaloLabel = new System.Windows.Forms.Label();
            this.kodavimoLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Įveskite tekstą:";
            // 
            // KoduotiButton
            // 
            this.KoduotiButton.Location = new System.Drawing.Point(824, 391);
            this.KoduotiButton.Name = "KoduotiButton";
            this.KoduotiButton.Size = new System.Drawing.Size(145, 72);
            this.KoduotiButton.TabIndex = 5;
            this.KoduotiButton.Text = "Koduoti,\r\nsiųsti kanalu,\r\ndekoduoti\r\n";
            this.KoduotiButton.UseVisualStyleBackColor = true;
            this.KoduotiButton.Click += new System.EventHandler(this.KoduotiButton_Click);
            // 
            // tekstoTextBox
            // 
            this.tekstoTextBox.Location = new System.Drawing.Point(219, 45);
            this.tekstoTextBox.Multiline = true;
            this.tekstoTextBox.Name = "tekstoTextBox";
            this.tekstoTextBox.Size = new System.Drawing.Size(586, 127);
            this.tekstoTextBox.TabIndex = 4;
            // 
            // tikimybesTextBox
            // 
            this.tikimybesTextBox.Location = new System.Drawing.Point(219, 180);
            this.tikimybesTextBox.Name = "tikimybesTextBox";
            this.tikimybesTextBox.Size = new System.Drawing.Size(586, 27);
            this.tikimybesTextBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Įveskite klaidos tikimybę 0-1:";
            // 
            // SiustiButton
            // 
            this.SiustiButton.Location = new System.Drawing.Point(824, 180);
            this.SiustiButton.Name = "SiustiButton";
            this.SiustiButton.Size = new System.Drawing.Size(145, 52);
            this.SiustiButton.TabIndex = 10;
            this.SiustiButton.Text = "Siųsti kanalu\r\nbe kodavimo";
            this.SiustiButton.UseVisualStyleBackColor = true;
            this.SiustiButton.Click += new System.EventHandler(this.SiustiButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tekstas po siuntimo kanalu:";
            // 
            // kanaloLabel
            // 
            this.kanaloLabel.AutoSize = true;
            this.kanaloLabel.Location = new System.Drawing.Point(219, 220);
            this.kanaloLabel.Name = "kanaloLabel";
            this.kanaloLabel.Size = new System.Drawing.Size(15, 20);
            this.kanaloLabel.TabIndex = 14;
            this.kanaloLabel.Text = "-";
            // 
            // kodavimoLabel
            // 
            this.kodavimoLabel.AutoSize = true;
            this.kodavimoLabel.Location = new System.Drawing.Point(219, 391);
            this.kodavimoLabel.Name = "kodavimoLabel";
            this.kodavimoLabel.Size = new System.Drawing.Size(15, 20);
            this.kodavimoLabel.TabIndex = 16;
            this.kodavimoLabel.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 60);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tekstas po kodavimo,\r\nsiuntimo kanalu\r\nir dekodavimo:";
            // 
            // UCAntras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kodavimoLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.kanaloLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tikimybesTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SiustiButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KoduotiButton);
            this.Controls.Add(this.tekstoTextBox);
            this.Name = "UCAntras";
            this.Size = new System.Drawing.Size(1000, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button KoduotiButton;
        private System.Windows.Forms.TextBox tekstoTextBox;
        private System.Windows.Forms.TextBox tikimybesTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SiustiButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label kanaloLabel;
        private System.Windows.Forms.Label kodavimoLabel;
        private System.Windows.Forms.Label label5;
    }
}
