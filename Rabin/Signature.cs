using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RabinLib

{
    public class Signature
    {
        public BigInteger S { get; set; }
        public BigInteger I { get; set; }

        public Signature(BigInteger S, BigInteger I)
        {
            this.S = S;
            this.I = I;
        }


    }
}
