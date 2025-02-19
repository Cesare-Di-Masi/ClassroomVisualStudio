using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary;
using LibraryProject;

namespace TestProject
{
    internal class FixedGenerator : IGenerator
    {
        private int _fixedNumber;
        public FixedGenerator(int number) { _fixedNumber = number; }
        public int GenerateNumber(int maxNumber)
        {
            return _fixedNumber;
        }
    }
}
