using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Strike
{
    internal class Tabanca : AtesliSilahlar
    {
        public override byte MermiKapasitesi { get; } = 15;
        public override MermiTipi MermiTipi { get; } = MermiTipi.Çekirdekli;
        public override byte Hasar { get; protected set; } = 15;
        public override int IsabetOlasiligi { get; protected set; } = 6;

        public Tabanca(string marka, string model, MenzilTipi menzilTipi, double kalibre, double agirlik, string atesSesi, string sarjorSesi, string picture)
        {
            Marka = marka;
            Model = model;
            MenzilTipi = menzilTipi;
            Kalibre = kalibre;
            Agirlik = agirlik;
            MermiSayisi = MermiKapasitesi;
            AtesSesi = atesSesi;
            SarjorSesi = sarjorSesi;
            MermiVarMi = true;
            Picture = picture;
        }

        public override void AtesEtme()
        {
            SoundPlayer sound = new SoundPlayer();
            sound.SoundLocation = AtesSesi;
            sound.Play();
            MermiSayisi -= 5;

        }
        public override void SarjorDoldurma()
        {
            SoundPlayer sound = new SoundPlayer();
            sound.SoundLocation = SarjorSesi;
            sound.Play();
            MermiSayisi = MermiKapasitesi;
        }
    }
}
