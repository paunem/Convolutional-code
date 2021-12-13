using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SasukosKodas
{
    public partial class UCPirmas : UserControl
    {
        private string pradineSeka;
        private List<byte> uzkoduotaSeka;
        private List<byte> kanaloSeka;
        private List<byte> dekoduotaSeka;

        public UCPirmas()
        {
            InitializeComponent();
        }

        private void KoduotiButton_Click(object sender, EventArgs e)
        {
            pradineSeka = sekosTextBox.Text;
            //Leidžiam naudotojui įvesti į sekos laukelį tik 0 arba 1.
            Regex regex = new Regex(@"^[0-1]+$");
            if (!regex.IsMatch(pradineSeka))
            {
                MessageBox.Show("Seka turi būti iš dvejetainių simbolių (0 arba 1)");
                return;
            }

            //Prie įvestos sekos pridedam 6 nulius, kurie bus naudojami kodavimui, kad išstumti sekos elementus iš registrų.
            string sekaKodavimui = pradineSeka + "000000";
            //Bitų seką sudedam į masyvą
            byte[] seka = sekaKodavimui.Select(c => byte.Parse(c.ToString())).ToArray();
            //Koduojame seką
            uzkoduotaSeka = Koderis.Uzkoduoti(seka);
            //Parodome ekrane užkoduotą seką 
            uzkoduotasLabel.Text = BitConverter.ToString(uzkoduotaSeka.ToArray()).Replace("-0", string.Empty).Remove(0, 1);
        }

        private void SiustiButton_Click(object sender, EventArgs e)
        {
            //Leidžiame įvesti klaidos tikimybę ir su tašku, ir su kableliu.
            string klaidosTikimybesString = tikimybesTextBox.Text.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            decimal klaidosTikimybe;
            //Tikrinam ar tikimybė yra tarp 0 ir 1.
            if (!decimal.TryParse(klaidosTikimybesString, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out klaidosTikimybe)
                || klaidosTikimybe < 0 || klaidosTikimybe > 1)
            {
                MessageBox.Show("Tikimybė turi būti tarp 0 ir 1");
                return;
            }

            //Siunčiame užkoduotą seką kanalu
            kanaloSeka = Kanalas.SiustiKanalu(uzkoduotaSeka, klaidosTikimybe);
            //Parodome ekrane iš kanalo gautą seką
            kanaloSekosTextBox.Text = BitConverter.ToString(kanaloSeka.ToArray()).Replace("-0", string.Empty).Remove(0, 1);
            //Parodyti kiek klaidų buvo padaryta siunčiant kanalu
            ParodytiKlaidas();
        }

        private void PataisytiButton_Click(object sender, EventArgs e)
        {
            //Leidžiame naudotojui pataisyti iš kanalo gautą seką prieš dekodavimą.
            kanaloSeka = kanaloSekosTextBox.Text.Select(c => byte.Parse(c.ToString())).ToList();
            ParodytiKlaidas();
        }

        private void DekoduotiButton_Click(object sender, EventArgs e)
        {
            //Dekoduojame iš kanalo gautą seką.
            dekoduotaSeka = Dekoderis.Dekoduoti(kanaloSeka);
            //Parodome ekrane dekoduotą seką nuėmę pirmus 6 bitus, kurie yra dekoderio būsenos bitai
            dekoduotasLabel.Text = BitConverter.ToString(dekoduotaSeka.ToArray()).Replace("-0", string.Empty).Remove(0, 7);
            SkaiciuotiKlaidasDekodavime();
        }

        /* Funkcija: parodo kiek klaidų ir kuriose vietose buvo padaryta siunčiant kanalu. */
        private void ParodytiKlaidas()
        {
            //1-etai parodys, kad toje vietoje buvo padaryta klaida, 0-iai, kad klaidos nėra.
            string klaidos = "";
            int klaiduSkaicius = 0;

            for (int i = 0; i < uzkoduotaSeka.Count; i++)
            {
                //Lyginam kiekvieną užkoduotą ir iš kanalo gautą bitą. Jeigu nesutampa reiškia buvo padaryta klaida.
                if(uzkoduotaSeka[i] != kanaloSeka[i])
                {
                    klaidos += "1";
                    klaiduSkaicius++;
                }
                else
                {
                    klaidos += "0";
                }
            }

            klaiduSkaiciusLabel.Text = klaiduSkaicius.ToString();
            padarytosKlaidosLabel.Text = klaidos;
        }

        /* Funkcija: parodo kiek klaidų buvo padaryta dekoduojant. */
        private void SkaiciuotiKlaidasDekodavime()
        {
            int klaiduSkaicius = 0;
            string dekoduotaSekaString = BitConverter.ToString(dekoduotaSeka.ToArray()).Replace("-0", string.Empty).Remove(0, 7);

            for (int i = 0; i < pradineSeka.Length; i++)
            {
                //Lyginam kiekvieną pradinį ir dekoduotą bitą.
                if (pradineSeka[i] != dekoduotaSekaString[i])
                {
                    klaiduSkaicius++;
                }
            }

            klaidosDekodavimeLabel.Text = klaiduSkaicius.ToString();
        }
    }
}
