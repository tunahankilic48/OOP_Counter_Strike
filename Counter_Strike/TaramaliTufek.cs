using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Counter_Strike
{
    internal class TaramaliTufek : Tufek
    {
        public override byte MermiKapasitesi { get; } = 50;
        public override MermiTipi MermiTipi { get; } = MermiTipi.Çekirdekli;
        public override byte Hasar { get; protected set; } = 20;
        public override int IsabetOlasiligi { get; protected set; } = 4;

        public TaramaliTufek(string marka, string model, MenzilTipi menzilTipi, double kalibre, double agirlik, string atesSesi, string sarjorSesi, string picture)
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
            MermiSayisi -= 10;

        }
        public override void SarjorDoldurma()
        {
            SoundPlayer sound = new SoundPlayer();
            sound.SoundLocation = SarjorSesi;
            sound.Play();
            MermiSayisi = MermiKapasitesi;

        }
        public override void Uzaklastirma()
        {
            IsabetOlasiligi -= 2;
            Hasar += 3;
        }
        public override void Yakinlastirma()
        {
            IsabetOlasiligi += 2;
            Hasar -= 3;
        }
        public override void EskiDegerlereDon()
        {
            IsabetOlasiligi = 5;
            Hasar = 20;
        }
    }
}
