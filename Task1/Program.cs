using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxSum = random.Next(300, 500);
            Document newDocument = new Document(1, maxSum);
            Row lastRow = newDocument.createRows();
            int sum = newDocument.getSum() + lastRow.RowSum - newDocument.maxSum;

            newDocument.printDocument();
            Console.WriteLine($" Last Row sum: {lastRow.RowSum}");
            Console.WriteLine($" Total document sum: {newDocument.getSum()}");
            Console.WriteLine($" Amount by how much sum would\n be more than max sum: {sum}");
            Console.WriteLine("-------------------------------");
        }
    }
}
