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
            int holesCount = 1;
            int rodesCount = 0;

            CreateField(field, ref vankRow, ref vankoCol);

            field[vankRow, vankoCol] = '*';                      

            bool isElectrocuted = false;
            bool isRoadHit = false;
           
            while (true)
            {
                int nextRow = 0;
                int nextCol = 0;

                int lastRow = vankRow;
                int lastCol = vankoCol;
               
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
                    continue;
                }               
                else if (direction == "End")
                {
                    break;
                }

                vankRow += nextRow;
                vankoCol += nextCol;

                if (field[vankRow, vankoCol] == 'C')
                {
                    isElectrocuted = true;
                    field[vankRow, vankoCol] = 'E';
                    holesCount++;

                    break;
                }
                else if (field[vankRow, vankoCol] == 'R')
                {   
                    isRoadHit = true;
                    rodesCount++;

                    vankRow = lastRow; 
                    vankoCol = lastCol;
                    Console.WriteLine($"Vanko hit a rod!");

                    continue;
                }
                else 
                {                    
                    if (field[vankRow, vankoCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankRow}, {vankoCol}]!");
                        continue;
                    }

                    field[vankRow, vankoCol] = '*';
                    holesCount++;
                   
                }
            }
            
            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                PrintMatrix(field);
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodesCount} rod(s).");
                field[vankRow, vankoCol] = 'V';
                PrintMatrix(field);
            }

                    
        }

        private static void PrintMatrix(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for(int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
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
                        vankRow = row; 
                        vankoCol = col;
                    }
                   
                }
            }
        }
    }
}