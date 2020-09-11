using System;

namespace Task1
{
    class Row
    {
        public string Code;
        public int RowSum;

        /**
         * printRow:
         * Prints row values
         * 
         * @return void
         */
        public void printRow()
        {
            Console.WriteLine($" Code: {Code}; RowSum:  {RowSum};");
        }
    }
}
