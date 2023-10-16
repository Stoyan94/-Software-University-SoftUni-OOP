namespace Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());            

            char[,] field = new char[size, size];

            int vankRow = 0;
            int vankoCol = 0;
            int holesCount = 0;

            CreateField(field, ref vankRow, ref vankoCol);
                      

            bool isElectrocuted = true;

           
            while (true)
            {
                int nextRow = 0;
                int nextCol = 0;

                string direction = Console.ReadLine();
                

                switch (direction)
                {
                    case "up": nextRow = -1; break;
                    case "down": nextRow = 1; break;
                    case "left": nextCol = -1; break;
                    case "right": nextCol = 1; break;
                }

                if (!isInRenage(field, vankRow + nextRow, vankoCol + nextCol))
                {                 
                    break;
                }

                vankRow += nextRow;
                vankoCol += nextCol;

                if (field[vankRow, vankoCol] == 'R')
                {
                    isElectrocuted = false;

                   
                    break;
                }
                else
                {
                    if (field[vankRow, vankoCol] == 'h')
                    {
                        
                    }
                }
            }
           
        }
       

        public static bool isInRenage(char[,] field, int row, int col)
        {
            return row >= 0 && row < field.GetLength(0) &&
                   col >= 0 && col < field.GetLength(1);
        }

        public static void CreateField(char[,] field, ref int vankRow,
            ref int vankoCol)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] fieldInput = Console.ReadLine()!.ToCharArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = fieldInput[col];

                    if (field[row, col] == 'V')
                    {
                        vankRow = row; vankoCol = col;
                    }
                   
                }
            }
        }
    }
}