using System;
using System.Windows.Forms;

namespace SasukosKodas
{
    public partial class Form : System.Windows.Forms.Form
    {
        private UCPirmas UCPirmas;
        private UCAntras UCAntras;
        private UCTrecias UCTrecias;

        public static Random randomGeneratorius;

        public Form()
        {
            InitializeComponent();
            UCPirmas = new UCPirmas();
            UCAntras = new UCAntras();
            UCTrecias = new UCTrecias();

            //Atsitiktinių skaičių generatorių inicijuojame tik vieną kartą, kai paleidžiama programą.
            randomGeneratorius = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Controls.Add(UCPirmas);
            Controls.Add(UCAntras);
            Controls.Add(UCTrecias);
        }

        private void pirmasButton_Click(object sender, EventArgs e)
        {
            UCPirmas.BringToFront();
        }

        private void antrasButton_Click(object sender, EventArgs e)
        {
            UCAntras.BringToFront();
        }

        private void treciasButton_Click(object sender, EventArgs e)
        {
            UCTrecias.BringToFront();
        }
    }
}
