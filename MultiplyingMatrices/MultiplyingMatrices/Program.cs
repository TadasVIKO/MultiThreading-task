using System;
using MultiplyingMatrices;

class Program {
        static void Main(string[] args)
        {
            string filePath = "/Users/tadasgrigaitis/Library/CloudStorage/OneDrive-Vilniauskolegija/" +
                              "Multithreading/MultiplyingMatrices/MultiplyingMatrices/matricies.csv";
            
            string[] lines = File.ReadAllLines(filePath);

            int numRows = lines.Length / 2;
            string[] firstRow = lines[0].Split(',');
            int numCols = firstRow.Length;

            int[,] matrix1 = new int[numRows, numCols];
            int[,] matrix2 = new int[numRows, numCols];

            int rowIndex = 0;
            int matrixIndex = 0;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    matrixIndex++;
                    rowIndex = 0;
                    continue;
                }

                string[] values = line.Split(',');

                for (int j = 0; j < numCols; j++)
                {
                    int.TryParse(values[j], out int value);
                    if (matrixIndex == 0)
                        matrix1[rowIndex, j] = value;
                    else if (matrixIndex == 1)
                        matrix2[rowIndex, j] = value;
                }
                rowIndex++;
            }
            
            int[,] answerMatrix = CountMatricies.Run(matrix1, matrix2);
            
            Console.WriteLine("\nAnswer:");
            PrintMatricies.Run(answerMatrix);
        }
    }

    