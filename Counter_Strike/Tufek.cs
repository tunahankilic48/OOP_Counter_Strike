using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Strike
{
    internal abstract class Tufek : AtesliSilahlar, IScope
    {
        public abstract override byte MermiKapasitesi { get; }

        public abstract void EskiDegerlereDon();

        public abstract override void SarjorDoldurma();

        public abstract void Uzaklastirma();

        public abstract void Yakinlastirma();
    }
}
