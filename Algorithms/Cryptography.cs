namespace Algorithms
{
    class Cryptography
    {
        public static (int g, int i, int j) Euclid(int a, int b)
        {
            if (b == 0)
            {
                return (a, 1, 0);
            }

            (int g, int i1, int j1) = Euclid(b, a % b);
            var i = j1;
            var j = i1 - (a / b) * j1;
            return (g, i, j);
        }

        public static int ModularExponentiation(int x, int d, int n)
        {
            if (d == 0)
            {
                return 1;
            }
            if (d % 2 == 0)
            {
                var z = ModularExponentiation(x, d / 2, n);
                return (z * z) % n;
            }
            var z1 = ModularExponentiation(x, (d - 1) / 2, n);
            return (z1 * z1 * x) % n;
        }
    }
}
