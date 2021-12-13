using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SasukosKodas
{
    public partial class UCTrecias : UserControl
    {
        private string paveiksliukasPradinis;
        private Bitmap paveiksliukas;

        public UCTrecias()
        {
            InitializeComponent();
        }

        private void PasirinktiButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Atidaryti paveiksliuką";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    paveiksliukas = new Bitmap(dlg.FileName);
                    paveiksliukasPradinis = dlg.FileName;
                    PavPictureBox.Image = paveiksliukas;
                }
            }
        }

        private void SiustiButton_Click(object sender, EventArgs e)
        {
            //Stačiakampis bitmapo plotui
            Rectangle rect = new Rectangle(0, 0, paveiksliukas.Width, paveiksliukas.Height);
            //Bitmap'as "užrakinamas" atmintyje
            BitmapData bmpData = paveiksliukas.LockBits(rect, ImageLockMode.ReadWrite, paveiksliukas.PixelFormat);
            //Pointer'is į vietą atmintyje kur yra bitmap'o informacija
            IntPtr pointeris = bmpData.Scan0;
            //Suskaičiuojama kiek baitų užima ta informacija
            int baitai = Math.Abs(bmpData.Stride) * bmpData.Height;
            //Sukuriamas masyvas bitmap'o RGB reikšmėms
            byte[] rgbReiksmes = new byte[baitai];
            //Į masyvą perkopijuojami baitai iš atminties
            Marshal.Copy(pointeris, rgbReiksmes, 0, baitai);

            //Vykdomas tas pats algoritmas kaip ir su teksto scenarijumi
            string pavDvejetainis = string.Join("", rgbReiksmes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
            List<byte> seka = pavDvejetainis.Select(c => byte.Parse(c.ToString())).ToList();

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
            List<byte> kanaloSeka = Kanalas.SiustiKanalu(seka, klaidosTikimybe);
            //Iš kanalo gautą seką paverčiam į stringą.
            string kanaloSekaString = BitConverter.ToString(kanaloSeka.ToArray()).Replace("-0", string.Empty).Remove(0, 1);
            rgbReiksmes = BinaryToByteArray(kanaloSekaString);

            //Į atmintį perkopijuojami baitai iš pakeisto RGB masyvo
            Marshal.Copy(rgbReiksmes, 0, pointeris, baitai);
            //Bitmap'as "atrakinamas" atmintyje
            paveiksliukas.UnlockBits(bmpData);

            neKodPictureBox.Image = paveiksliukas;
            paveiksliukas = new Bitmap(paveiksliukasPradinis);
        }

        private void KoduotiButton_Click(object sender, EventArgs e)
        {
            //Stačiakampis bitmapo plotui
            Rectangle rect = new Rectangle(0, 0, paveiksliukas.Width, paveiksliukas.Height);
            //Bitmap'as "užrakinamas" atmintyje
            BitmapData bmpData = paveiksliukas.LockBits(rect, ImageLockMode.ReadWrite, paveiksliukas.PixelFormat);
            //Pointer'is į vietą atmintyje kur yra bitmap'o informacija
            IntPtr pointeris = bmpData.Scan0;
            //Suskaičiuojama kiek baitų užima ta informacija
            int baitai = Math.Abs(bmpData.Stride) * bmpData.Height;
            //Sukuriamas masyvas bitmap'o RGB reikšmėms
            byte[] rgbReiksmes = new byte[baitai];
            //Į masyvą perkopijuojami baitai iš atminties
            Marshal.Copy(pointeris, rgbReiksmes, 0, baitai);

            //Vykdomas tas pats algoritmas kaip ir su teksto scenarijumi
            string pavDvejetainis = string.Join("", rgbReiksmes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0'))) + "000000";
            byte[] seka = pavDvejetainis.Select(c => byte.Parse(c.ToString())).ToArray();

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
            List<byte> dekoduotaSeka = Dekoderis.Dekoduoti(kanaloSeka);
            //Dekoduotą seką paverčiam į stringą nuėmę pirmus 6 bitus, kurie yra dekoderio būsenos bitai.
            string dekoduotaSekaString = BitConverter.ToString(dekoduotaSeka.ToArray()).Replace("-0", string.Empty).Remove(0, 7);

            rgbReiksmes = BinaryToByteArray(dekoduotaSekaString);

            //Į atmintį perkopijuojami baitai iš pakeisto RGB masyvo
            Marshal.Copy(rgbReiksmes, 0, pointeris, baitai);
            //Bitmap'as "atrakinamas" atmintyje
            paveiksliukas.UnlockBits(bmpData);

            kodPictureBox.Image = paveiksliukas;
            paveiksliukas = new Bitmap(paveiksliukasPradinis);
        }

        /* Funkcija: dvejetainę seką string formato konvertuoja į baitų masyvą.
           Parametrai: dvejetainė seka.
           Rezultatas: baitų sąrašas */
        private byte[] BinaryToByteArray(string sekaDvejetaine)
        {
            List<byte> baituSeka = new List<byte>();

            for (int i = 0; i < sekaDvejetaine.Length; i += 8)
            {
                //Kiekvieną 8 bitų seką paverčiam į baitą ir sudedam į sąrašą.
                baituSeka.Add(Convert.ToByte(sekaDvejetaine.Substring(i, 8), 2));
            }

            return baituSeka.ToArray();
        }
    }
}
