using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Strike
{
    internal class Bicak : Silahlar
    {
        public string KesmeSesi { get; set; }
        public string BileylemeSesi { get; set; }
        public override byte Hasar { get; protected set; } = 30;

        public Bicak(string marka, double agirlik, MenzilTipi menzilTipi, string model, string kesmeSesi, string bileylemeSesi, string picture)
        {
            Marka = marka;
            Agirlik = agirlik;
            MenzilTipi = menzilTipi;
            Model = model;
            KesmeSesi = kesmeSesi;
            BileylemeSesi = bileylemeSesi;
            Picture = picture;
        }
        public void Bileyle()
        {
            SoundPlayer sound = new SoundPlayer();
            sound.SoundLocation = BileylemeSesi;
            sound.Play();
            Hasar += 10;
        }
        public void Kes()
        {
            SoundPlayer sound = new SoundPlayer();
            sound.SoundLocation = KesmeSesi;
            sound.Play();
            Hasar = 30;
        }

    }
}
