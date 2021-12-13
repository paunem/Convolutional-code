using System;
using System.Collections.Generic;

namespace SasukosKodas
{
    /* Funkcija: padaro klaidų užkoduotoje sekoje.
       Parametrai: užkoduota seka, klaidos tikimybė.
       Rezultatas: iš kanalo gauta seka. */
    public class Kanalas
    {
        public static List<byte> SiustiKanalu(List<byte> uzkoduotaSeka, decimal klaidosTikimybe)
        {
            List<byte> kanaloSeka = new List<byte>();
            foreach (byte bitas in uzkoduotaSeka)
            {
                //Sugeneruojam atsitiktinį skaičių 0-1.
                double atsitiktinis = Form.randomGeneratorius.NextDouble();
                //Jei atsitiktinis skaičius < klaidos tikimybę tada iškraipom (pakeičiam) sekos bitą ir pridedam į naują sąrašą.
                if ((decimal)atsitiktinis < klaidosTikimybe)
                {
                    kanaloSeka.Add((byte)((bitas + 1) % 2));
                }
                else
                {
                    kanaloSeka.Add(bitas);
                }
            }
            return kanaloSeka;
        }
    }
}
