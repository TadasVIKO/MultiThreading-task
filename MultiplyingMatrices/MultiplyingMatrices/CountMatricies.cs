namespace MultiplyingMatrices;

public static class CountMatricies
{
    public static int[,] Run(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (cols1 != rows2)
        {
            Console.WriteLine("\nERROR: Matricies cannot be multiplied! Incompatible dimensions!");
            return null;
        }
            
        int[,] multipliedMatrix = new int[rows1, cols2];

        Thread[] threads = new Thread[rows1 * cols2];
        int threadIndex = 0;
        
        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                int row = i;
                int col = j;

                threads[threadIndex] = new Thread(() =>
                {
                    int sum = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        sum += matrix1[row, k] * matrix2[k, col];
                    }
                    multipliedMatrix[row, col] = sum;
                    Console.Write(sum + " ");
                });

                threads[threadIndex].Start();
                threadIndex++;
            }
        }
        return multipliedMatrix;
    }
}