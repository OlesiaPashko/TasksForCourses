using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Matrix
{
    class Matrix : ICloneable, IComparable<Matrix>
    {
        public int[,] Data { get; set; }

        public int M { get; }
        public int N { get; }
        Matrix(int n, int m)
        {
            M = m;
            N = n;
            Data = new int[n, m];
        }

        public Matrix(int[,] data)
        {
            this.Data = data;
            N = Data.GetUpperBound(0) + 1;
            M = Data.GetUpperBound(1) + 1;
        }

        public int this[int n, int m]
        {
            get
            {
                return Data[n, m];
            }
            set
            {
                Data[n, m] = value;
            }
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.M != b.M || a.N != b.N)
                throw new DementionException("Matrixes have differend dementions",
                     a.N, a.M, b.N, b.M);
            if (a == null || b == null)
                throw new NullReferenceException("You can not multiply null");
            Matrix result = new Matrix(a.N, b.M);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.M; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.M != b.M || a.N != b.N)
                throw new DementionException("Matrixes have differend dementions", a.N, a.M, b.N, b.M);
            if (a == null || b == null)
                throw new NullReferenceException("You can not multiply null");
            Matrix result = new Matrix(a.N , b.M);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.M; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a == null || b == null)
                throw new NullReferenceException("You can not multiply null");
            if (a.N != b.M)
                throw new DementionException("Matrixes have dementions, that can not be multiplied", a.N, a.M, b.N, b.M);
            Matrix result = new Matrix(a.N, b.M);
            for (int i = 0; i < result.N; i++)
            {
                for (int j = 0; j < result.M; j++)
                {
                    int elem = 0;
                    for (int k = 0; k < a.M; k++)
                    {
                        elem += a[i, k] * b[k, j];
                    }
                    result[i, j] = elem;
                }
            }
            return result;
        }

        public void WriteToFile(string path) {
            using (StreamWriter stream = new StreamWriter(path))
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                        stream.Write("{0} ", Data[i, j]);
                    stream.WriteLine();
                }
            }
        }

        public void ReadFromFile(string path)
        {
            using (StreamReader stream = new StreamReader(path))
            {
                while (stream.Peek() >= 0)
                {
                    string line = stream.ReadLine();
                    string[] tokens = line.Split(new Char[] { ' ' });

                    int[] values = new int[M];
                    for (int i = 0; tokens[i] != ""; i++)
                        Int32.TryParse(tokens[i], out values[i]);

                    for (int i = 0; i < M; i++)
                        Console.Write("{0} ", values[i]);
                    Console.WriteLine();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            for(int i = 0; i<N; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    res.Append((Data[i,j]).ToString()+"  ");
                }
                res.Append("\n");
            }
            return res.ToString();
        }

        public object Clone()
        {
            return new Matrix((int[,])Data.Clone());
        }

        public int CompareTo(Matrix other)
        {
            if (other == null)
                throw new NullReferenceException("You can not compare to null");
            if (N != other.N || M != other.M)
            {
                return -1;
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (Math.Abs(Data[i, j] - other[i, j]) > 0)
                    {
                        return -1;
                    }
                }
            }

            return 0;
        }
    }
}
