using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Polynomial
{
    class Polynomial
    {
        public List<double> Coefs { get; }//coef of the bigest power is first
        public int Power
        {
            get
            {
                return Coefs.Count - 1;
            }
        }

        public Polynomial()
        {
            this.Coefs = new List<double>(new double[] { 1, 1 });
        }
        public Polynomial(double[] coefs)
        {
            if (coefs == null)
            {
                throw new NullReferenceException("Null can not be used in constructor as parameter");
            }
            this.Coefs = coefs.ToList();
        }

        public double this[int power]
        {
            get
            {
                if (Coefs.Count - power - 1 < 0 || power >= Coefs.Count)
                {
                    throw new ArgumentException($"Power {power} is bigger that max power of Polynomial");
                }
                return Coefs[Coefs.Count - power - 1];
            }

            set
            {
                if (Coefs.Count - power - 1 < 0 || power >= Coefs.Count)
                {
                    throw new ArgumentException($"Power {power} is bigger that max power of Polynomial");
                }
                this.Coefs[Coefs.Count - power - 1] = value;
            }
        }

        public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 == null || pol2 == null)
            {
                throw new NullReferenceException("Null can not be used in operator +");
            }
            List<double> result = new List<double>();
            List<double> secondArg = new List<double>();
            int DementionDifference = pol1.Coefs.Count - pol2.Coefs.Count;
            foreach (double elem in pol2.Coefs)
            {
                secondArg.Add(elem * (-1));
            }
            List<double> bigger = DementionDifference >= 0 ? pol1.Coefs : secondArg;
            List<double> smaller = DementionDifference >= 0 ? secondArg : pol1.Coefs;
            int i = 0;
            for (; i < Math.Abs(DementionDifference); i++)
            {
                result.Add(bigger[i]);
            }
            foreach (double smallerCoef in smaller)
            {
                result.Add(bigger[i] + smallerCoef);
                i++;
            }
            return new Polynomial(result.ToArray());
        }

        public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
        {
            if (pol1 == null || pol2 == null)
            {
                throw new NullReferenceException("Null can not be used in operator -");
            }
            List<double> result = new List<double>(pol1.Coefs.Count);
            int DementionDifference = pol1.Coefs.Count - pol2.Coefs.Count;
            List<double> bigger = DementionDifference >= 0 ? pol1.Coefs : pol2.Coefs;
            List<double> smaller = DementionDifference >= 0 ? pol2.Coefs : pol1.Coefs;
            int i = 0;
            for (; i < Math.Abs(DementionDifference); i++)
            {
                result.Add(bigger[i]);
            }
            foreach (double smallerCoef in smaller)
            {
                result.Add(bigger[i] + smallerCoef);
                i++;
            }
            return new Polynomial(result.ToArray());
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
            {
                throw new NullReferenceException("Null can not be used in operator *");
            }
            double[] result = new double[p1.Power + p2.Power + 1];
            for (int i = 0; i <= p1.Power; i++)
            {
                for (int j = 0; j <= p2.Power; j++)
                {
                    result[i + j] += p1.Coefs[i] * p2.Coefs[j];
                }
            }
            return new Polynomial(result);
        }
        public override string ToString()
        {
            StringBuilder res = new StringBuilder("");
            for (int i = Coefs.Count - 1; i > 0; i--)
            {
                res.Append(Coefs[Coefs.Count - 1 - i] + "x^" + i + " ");
                if (Coefs[Coefs.Count - 1 - i] > 0)
                    res.Append("+ ");
            }
            res.Append(Coefs[Coefs.Count - 1]);
            return res.ToString().TrimEnd('+');
        }
    }


}
