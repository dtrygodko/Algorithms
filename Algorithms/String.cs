using System;

namespace Algorithms
{
    class String
    {
        public static int[,] ComputeLCSTable(string x, string y)
        {
            int m = x.Length, n = y.Length;
            var l = new int[m+1, n+1];
            for (int i = 1; i <= m; ++i)
            {
                for (int j = 1; j <= n; ++j)
                {
                    if (x[i-1] == y[j-1])
                    {
                        l[i, j] = l[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        if (l[i, j-1] >= l[i-1,j])
                        {
                            l[i, j] = l[i, j - 1];
                        }
                        else
                        {
                            l[i, j] = l[i - 1, j];
                        }
                    }
                }
            }
            return l;
        }

        public static string AssembleLCS(string x, string y, int[,] l, int i, int j)
        {
            if (l[i,j] == 0)
            {
                return "";
            }

            if (x[i-1] == y[j-1])
            {
                return AssembleLCS(x, y, l, i - 1, j - 1) + x[i - 1];
            }

            if (l[i, j - 1] > l[i - 1, j])
            {
                return AssembleLCS(x, y, l, i, j - 1);
            }

            return AssembleLCS(x, y, l, i - 1, j);
        }

        public enum Operation { Copy, Replace, Delete, Insert }

        public static Tuple<int[,], Operation[,]> ComputeTransformTables(string x, string y, int cc, int cr, int cd, int ci)
        {
            int m = x.Length, n = y.Length;
            var cost = new int[m + 1, n + 1];
            var op = new Operation[m + 1, n + 1];
            for (int i = 1; i <= m; ++i)
            {
                cost[i, 0] = i * cd;
                op[i, 0] = Operation.Delete;
            }
            for (int j = 1; j <= n; ++j)
            {
                cost[0, j] = j * ci;
                op[0, j] = Operation.Insert;
            }
            for (int i = 1; i <= m; ++i)
            {
                for (int j = 1; j <= n; ++j)
                {
                    if (x[i - 1] == y[j - 1])
                    {
                        cost[i, j] = cost[i - 1, j - 1] + cc;
                        op[i, j] = Operation.Copy;
                    }
                    else
                    {
                        cost[i, j] = cost[i - 1, j - 1] + cr;
                        op[i, j] = Operation.Replace;
                    }

                    if (cost[i - 1, j] + cd < cost[i, j])
                    {
                        cost[i, j] = cost[i - 1, j] + cd;
                        op[i, j] = Operation.Delete;
                    }
                    if (cost[i, j - 1] + ci < cost[i, j])
                    {
                        cost[i, j] = cost[i, j - 1] + ci;
                        op[i, j] = Operation.Insert;
                    }
                }
            }
            return new Tuple<int[,], Operation[,]> (cost, op);
        }
    }
}
