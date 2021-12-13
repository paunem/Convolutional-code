using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SasukosKodas
{
    public partial class UCAntras : UserControl
    {

        public UCAntras()
        {
            InitializeComponent();
        }

        private void SiustiButton_Click(object sender, EventArgs e)
        {
            //Tekstą konvertuojam į dvejetainę seką.
            string tekstasDvejetainis = TextToBinary(tekstoTextBox.Text);
            //Dvejetainę bitų seką sudedam į sąrašą.
            List<byte> seka = tekstasDvejetainis.Select(c => byte.Parse(c.ToString())).ToList();

            // Leidžiame įvesti klaidos tikimybę ir su tašku, ir su kableliu.
            string klaidosTikimybesString = tikimybesTextBox.Text.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            decimal klaidosTikimybe;
            //Tikrinam ar tikimybė yra tarp 0 ir 1.
            if (!decimal.TryParse(klaidosTikimybesString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out klaidosTikimybe)
                || klaidosTikimybe < 0 || klaidosTikimybe > 1)
            {
                MessageBox.Show("Tikimybė turi būti tarp 0 ir 1");
                return;
            }

            //Bitų seką siunčiam kanalu.
            List<byte> kanaloSeka = Kanalas.SiustiKanalu(seka, klaidosTikimybe);
            //Iš kanalo gautą seką konvertuojam į stringą.
            string kanaloSekaString = BitConverter.ToString(kanaloSeka.ToArray()).Replace("-0", string.Empty).Remove(0, 1);
            //Iš kanalo gautą seką konvertuojam į tekstą ir parodom naudotojui.
            kanaloLabel.Text = BinaryToText(kanaloSekaString);
        }

        private void KoduotiButton_Click(object sender, EventArgs e)
        {
            //Tekstą konvertuojam į dvejetainę seką ir pridedam 6 nulius kodavimui.
            string tekstasDvejetainis = TextToBinary(tekstoTextBox.Text) + "000000";
            //Dvejetainę bitų seką sudedam į masyvą.
            byte[] seka = tekstasDvejetainis.Select(c => byte.Parse(c.ToString())).ToArray();

            //Koduojame seką
            List<byte> uzkoduotaSeka = Koderis.Uzkoduoti(seka);

            // Leidžiame įvesti klaidos tikimybę ir su tašku, ir su kableliu.
            string klaidosTikimybesString = tikimybesTextBox.Text.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            decimal klaidosTikimybe;
            //Tikrinam ar tikimybė yra tarp 0 ir 1.
            if (!klaidosTikimybesString.StartsWith("0.") ||
                !decimal.TryParse(klaidosTikimybesString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out klaidosTikimybe))
            {
                MessageBox.Show("Tikimybė turi būti tarp 0 ir 1");
                return;
            }

            //Bitų seką siunčiam kanalu.
            List<byte> kanaloSeka = Kanalas.SiustiKanalu(uzkoduotaSeka, klaidosTikimybe);
            //Dekoduojame iš kanalo gautą seką.
            List<byte>  dekoduotaSeka = Dekoderis.Dekoduoti(kanaloSeka);
            //Dekoduotą seką paverčiam į stringą nuėmę pirmus 6 bitus, kurie yra dekoderio būsenos bitai.
            string dekoduotaSekaString = BitConverter.ToString(dekoduotaSeka.ToArray()).Replace("-0", string.Empty).Remove(0, 7);
            //Dekoduotą seką konvertuojam į tekstą ir parodom naudotojui.
            kodavimoLabel.Text = BinaryToText(dekoduotaSekaString);
        }

        /* Funkcija: konvertuoja tekstą į dvejetainę seką.
           Parametrai: tekstas.
           Rezultatas: dvejetainis tekstas. */
        private string TextToBinary(string tekstas)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in tekstas)
            {
                //Kiekvieną simbolį paverčiam į dvejetainį atitikmenį ir praplečiam iki 8 bitų.
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        /* Funkcija: konvertuoja dvejetainę seką į tekstą.
           Parametrai: dvejetainis tekstas.
           Rezultatas: tekstas. */
        private string BinaryToText(string tekstasDvejetainis)
        {
            List<byte> baituSeka = new List<byte>();

            for (int i = 0; i < tekstasDvejetainis.Length; i += 8)
            {
                //Kiekvieną 8 bitų seką paverčiam į baitą ir sudedam į sąrašą.
                baituSeka.Add(Convert.ToByte(tekstasDvejetainis.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(baituSeka.ToArray());
        }
    }
}
