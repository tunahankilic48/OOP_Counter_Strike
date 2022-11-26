using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter_Strike
{
    internal interface IScope
    {
        abstract void Yakinlastirma();
        abstract void Uzaklastirma();
        abstract void EskiDegerlereDon();
    }
}
