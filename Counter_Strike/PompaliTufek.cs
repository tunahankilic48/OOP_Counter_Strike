using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Strike
{
    internal class PompaliTufek : Tufek
    {
        public override byte MermiKapasitesi { get; } = 4;
        public override MermiTipi MermiTipi { get; } = MermiTipi.Saçma;
        public override byte Hasar { get; protected set; } = 20;
        public override int IsabetOlasiligi { get; protected set; } = 4;

        public PompaliTufek(string marka, string model, MenzilTipi menzilTipi, double kalibre, double agirlik, string atesSesi, string sarjorSesi, string picture)
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
            MermiSayisi -= 2;
        }
        public override void SarjorDoldurma()
        {
            int eklenenMermi = 0;
            for (int i = 0; i < MermiKapasitesi - MermiSayisi; i++)
            {
                SoundPlayer sound = new SoundPlayer();
                sound.SoundLocation = SarjorSesi;
                sound.Play();
                Thread.Sleep(500);
                eklenenMermi += 1;
            }
            MermiSayisi += eklenenMermi;
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
