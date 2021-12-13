using System.Collections.Generic;

namespace SasukosKodas
{
    public class Dekoderis
    {
        /* Funkcija: dekoduoja iš kanalo gautą seką.
           Parametrai: iš kanalo gauta seka.
           Rezultatas: dekoduota seka. */
        public static List<byte> Dekoduoti(List<byte> seka)
        {
            //Sąrašai registrams. Pradžioje kodavimo jie užpildyti nuliais.
            List<byte> regVirsuje = new List<byte>() { 0, 0, 0, 0, 0, 0 };
            List<byte> regApacioje = new List<byte>() { 0, 0, 0, 0, 0, 0 };
            List<byte> dekoduotaSeka = new List<byte>();

            for (int i = 0; i < seka.Count; i += 2)
            {
                //Suskaičiuojam tarpinį bitą apačioje. Sudedam 2 sekos elementus ir tris viršutinius registrus (2, 5, 6) mod 2.
                byte tarpinisBitas = (byte)((seka[i] + seka[i+1] + regVirsuje[1] + regVirsuje[4] + regVirsuje[5]) % 2);
                //Suskaičiuojam MDE sumos elementą. Sudedam tarpinį bitą ir tris apatinius registrus (1, 4, 6) mod 2.
                byte mdeSuma = (byte)(tarpinisBitas + regApacioje[0] + regApacioje[3] + regApacioje[5]);
                byte mde;
                //Jeigu MDE suma <= 2 tai reiškia dauguma buvo nuliai, todėl MDE bus 0.
                if (mdeSuma <= 2)
                {
                    mde = 0;
                }
                //Jeigu MDE suma > 2 tai reiškia dauguma buvo vienetai, todėl MDE bus 1.
                else
                {
                    mde = 1;
                }

                //Skaičiuojam dekoduotą bitą. Sudedam viršutinį paskutinį registrą ir MDE.
                byte galutinisBitas = (byte)((regVirsuje[5] + mde) % 2);
                //Į dekoduotą seką įdedam dekoduotą bitą.
                dekoduotaSeka.Add(galutinisBitas);

                //Į viršutinio registro pradžią įterpiam sekos bitą.
                regVirsuje.Insert(0, seka[i]);
                regVirsuje.RemoveAt(6);
                //Į apationio registro pradžią įterpiam tarpinį bitą.
                regApacioje.Insert(0, tarpinisBitas);
                regApacioje.RemoveAt(6);

                //Grįžtamasis ryšys. Prie (1, 2, 5) apatinio registro pridedam mde mod 2
                regApacioje[0] = (byte)((regApacioje[0] + mde) % 2);
                regApacioje[1] = (byte)((regApacioje[1] + mde) % 2);
                regApacioje[4] = (byte)((regApacioje[4] + mde) % 2);
            }
            return dekoduotaSeka;
        }
    }
}
