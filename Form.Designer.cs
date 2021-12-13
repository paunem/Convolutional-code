
namespace SasukosKodas
{
    partial class Form
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
            this.antrasButton = new System.Windows.Forms.Button();
            this.pirmasButton = new System.Windows.Forms.Button();
            this.treciasButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // antrasButton
            // 
            this.antrasButton.Location = new System.Drawing.Point(434, 626);
            this.antrasButton.Name = "antrasButton";
            this.antrasButton.Size = new System.Drawing.Size(146, 55);
            this.antrasButton.TabIndex = 30;
            this.antrasButton.Text = "Tekstas\r\n(antras scenarijus)";
            this.antrasButton.UseVisualStyleBackColor = true;
            this.antrasButton.Click += new System.EventHandler(this.antrasButton_Click);
            // 
            // pirmasButton
            // 
            this.pirmasButton.Location = new System.Drawing.Point(269, 626);
            this.pirmasButton.Name = "pirmasButton";
            this.pirmasButton.Size = new System.Drawing.Size(146, 55);
            this.pirmasButton.TabIndex = 29;
            this.pirmasButton.Text = "Vektorius\r\n(pirmas scenarijus)";
            this.pirmasButton.UseVisualStyleBackColor = true;
            this.pirmasButton.Click += new System.EventHandler(this.pirmasButton_Click);
            // 
            // treciasButton
            // 
            this.treciasButton.Location = new System.Drawing.Point(602, 626);
            this.treciasButton.Name = "treciasButton";
            this.treciasButton.Size = new System.Drawing.Size(146, 55);
            this.treciasButton.TabIndex = 31;
            this.treciasButton.Text = "Paveiksliukas\r\n(Trečias scenarijus)";
            this.treciasButton.UseVisualStyleBackColor = true;
            this.treciasButton.Click += new System.EventHandler(this.treciasButton_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.treciasButton);
            this.Controls.Add(this.antrasButton);
            this.Controls.Add(this.pirmasButton);
            this.Name = "Form";
            this.Text = "Sąsukos kodas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button antrasButton;
        private System.Windows.Forms.Button pirmasButton;
        private System.Windows.Forms.Button treciasButton;
    }
}