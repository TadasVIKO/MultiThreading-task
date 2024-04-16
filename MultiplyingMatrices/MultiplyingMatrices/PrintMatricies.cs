namespace MultiplyingMatrices;

public class PrintMatricies
{
    public static void Run(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            Console.Write("|");
            for (int j = 0; j < cols; j++)
            {
                if (index != 2)
                {
                    Console.Write(matrix[i, j] + "\t");
                    index++;
                }
                else
                {
                    Console.Write(matrix[i, j]);
                    index = 0;
                }
            }
            Console.Write("|\n");
        }
    }
}