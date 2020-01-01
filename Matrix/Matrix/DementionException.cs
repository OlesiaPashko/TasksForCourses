using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    class DementionException:Exception
    {
        public int Matrix1N { get; }
        public int Matrix1M { get; }
        public int Matrix2N { get; }
        public int Matrix2M { get; }

        public DementionException(string message, int n1, int m1, int n2, int m2)
            : base(message)
        {
            Matrix1N = n1;
            Matrix1M = m1;
            Matrix2N = n2;
            Matrix2M = m2;
        }
    }
}
