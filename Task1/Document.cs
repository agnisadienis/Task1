using System;
using System.Linq;
using System.Collections;

namespace Task1
{
    class Document
    {
        public int number;
        public int maxSum;
        public string date;
        public ArrayList rows = new ArrayList();
        
        //To create unique randomised inputs
        private static Random random = new Random();
        
        /**
         * Constructor:
         * Sets Document number, Max sum limit and Date
         * 
         * @int x number
         * @int y maxSum
         * 
         * @return void
         */
        public Document(int x, int y)
        {
            number = x;
            maxSum = y;
            date = getDate();
        }

        /**
         * getDate:
         * Get the following monday
         * 
         * @return string
         */
        public string getDate()
        {
            DateTime monday = new DateTime(2020, 08, 31);
            DateTime today = DateTime.Now;
            double dif = (today.Date - monday.Date).Days;
            dif = dif % 7;
            today = today.AddDays(-dif+7);

            return today.ToString("dd/MM/yyyy");
        }

        /**
         * createRows:
         * Create row values
         * 
         * @return Row
         */
        public Row createRows()
        {
            int totalSum=0;
            Row newRow = new Row();
            while (totalSum <= (maxSum))
            { 
                newRow = new Row();
                newRow.Code = RandomString(10);
                newRow.RowSum = random.Next(maxSum / 3);
                totalSum += newRow.RowSum;
                if (!(totalSum <= maxSum))
                { 
                    break; 
                }
                setRows(newRow);
            }

            return newRow; 
        }

        /**
         * setRows:
         * Put rows into array
         * @class row Row
         * 
         * @return void
         */
        public void setRows(Row row)
        {
             rows.Add(row);
        }

        /**
         * getSum:
         * Calculates sum of all row sums
         * 
         * @return int
         */
        public int getSum()
        {
            int x = 0;
            foreach (Row row in rows) {
                x += row.RowSum; 
            }

            return x;
        }

        /**
         * printRows:
         * Iterates through an array and calls for function that prints out row values
         * 
         * @return void
         */
        public void printRows()
        {
            Console.WriteLine("-------------------------------");
            foreach (Row row in rows)
            {
                row.printRow();
            }
            Console.WriteLine("-------------------------------");
        }

        /**
         * printDocument:
         * Shows all document output to user
         * 
         * @return void
         */
        public void printDocument()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine($" Date: {date} \n Number: {number}\n maxSum: {maxSum}");

            printRows();
            Console.WriteLine($" Row count: {rows.Count}");
            Console.WriteLine("-------------------------------");
            getSum();
        }

        /**
         * RandomString:
         * Creates a random value to put into row code
         * 
         * @int length
         * 
         * @return Row
         */
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
