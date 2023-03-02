// Curt Lynch
// 3/2/2023
// FindPiThread class

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDarts
{
    internal class FindPiThread
    {
        int darts;
        int hits;
        Random rand;

        public int Hits { get { return hits; } }

        public FindPiThread(int darts)
        {
            this.darts = darts;
            hits = 0;
            rand = new Random();
        }

        public void throwDarts()
        {
            double x, y, hypotenuse;
            while (darts > 0)
            {
                x = rand.NextDouble();
                y = rand.NextDouble();
                hypotenuse = Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(y, 2));
                if (hypotenuse <= 1)
                {
                    hits++;
                }
                darts--;
            }
        }
    }
}
