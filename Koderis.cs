using System.Collections.Generic;

namespace SasukosKodas
{
    public class Koderis
    {
        /* Funkcija: užkoduoja naudotojo įvestą seką.
           Parametrai: naudotojo įvesta seka.
           Rezultatas: užkoduota seka. */
        public static List<byte> Uzkoduoti(byte[] seka)
        {
            //Sąrašas registrams. Pradžioje kodavimo jie užpildyti nuliais.
            List<byte> registrai = new List<byte>() {0, 0, 0, 0, 0, 0};
            List<byte> uzkoduotaSeka = new List<byte>();

            for (int i = 0; i < seka.Length; i++)
            {
                //Suskaičiuojam bitą, kuris ateis iš apačios. Sudedam sekos elementą ir tris registrus (2, 5, 6) mod 2.
                byte antrasBitas = (byte)((seka[i] + registrai[1] + registrai[4] + registrai[5]) % 2);
                
                //Į registrų sąrašo pradžią įterpiam sekos elementą, kad pastumti registrus.
                registrai.Insert(0, seka[i]);
                //Iš registrų sąrašo ištrinam paskutinį (septintą) elementą, kad atlaisvinti atmintį.
                registrai.RemoveAt(6);

                //Į užkoduotą seką įdedam patį sekos elementą ir iš karto po jo bitą, kurį suskaičiavome apačioje.
                uzkoduotaSeka.Add(seka[i]);
                uzkoduotaSeka.Add(antrasBitas);
            }

            return uzkoduotaSeka;
        }
    }
}
