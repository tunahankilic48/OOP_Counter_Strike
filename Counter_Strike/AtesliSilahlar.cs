using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Strike
{
    public abstract class AtesliSilahlar : Silahlar
    {
        public abstract MermiTipi MermiTipi { get; }
        public abstract byte MermiKapasitesi { get; }
        public double Kalibre { get; set; }
        public int MermiSayisi { get; set; }
        public string AtesSesi { get; set; }
        public string SarjorSesi { get; set; }
        public bool MermiVarMi { get; set; }
        public abstract int IsabetOlasiligi { get; protected set; }

        public abstract void SarjorDoldurma();
        public abstract void AtesEtme();
        public bool IsabetliMi()
        {
            Random rnd = new Random();
            int vurduMu = rnd.Next(1, 11);
            return vurduMu <= IsabetOlasiligi ? true : false;
        }
    }
}
