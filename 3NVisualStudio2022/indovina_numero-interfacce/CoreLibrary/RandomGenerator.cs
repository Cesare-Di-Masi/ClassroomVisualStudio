using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject
{
    internal class RandomGenerator : IGenerator
    {
        int IGenerator.GenerateNumber(int maxNumber)
        {
            Random random = new Random();
            return random.Next(maxNumber);
        }
    }
}
