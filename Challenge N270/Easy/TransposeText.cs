using System;
using System.IO;

namespace Challenge_N270_Transpose_the_input_text
{
    class Program
    {
        
        static char[,] TransposeMatrix(char[,] matrix, int sizeX ,int sizeY)
        {
            char[,] dummyArr = new char[sizeY, sizeX];

            for (int line = 0; line < sizeX; ++line)
            {
                for (int x = 0; x < sizeY; ++x)
                {
                    dummyArr[x, line] = matrix[line, x];
                }
            }

            return dummyArr;
        }



        static void Main(string[] args)

        {
            //input
            string[] lines = File.ReadAllLines(System.Environment.CurrentDirectory.ToString() + @"\input.txt");

            //checks what are the needed proprtions for the 2D array
            int numberOfLines = lines.Length;
            int longestLineLength = 0;

            foreach (var line in lines)
            {
                if (line.Length > longestLineLength)
                {
                    longestLineLength = line.Length;
                }
            }

            //fills 2D array with chars form the input
            char[,] linesArr2D = new char[numberOfLines, longestLineLength];

            for (int i = 0; i < numberOfLines; i++)
            {
                for (int o = 0; o < lines[i].Length; o++)
                {
                    linesArr2D[i, o] = lines[i][o];
                }
            }


            //transposes the 2D array
            char[,] rotatedArr = TransposeMatrix(linesArr2D, numberOfLines, longestLineLength);


            //  outputs the transposed array
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(System.Environment.CurrentDirectory.ToString() + @"\output.txt"))
            {
                

                    for (int i = 0; i < longestLineLength; i++)
                    {
                        for (int o = 0; o < numberOfLines; o++)
                        {
                            file.Write(rotatedArr[i, o]);
                        }
                        file.WriteLine();
                    }                    
                
            }

            Console.WriteLine("Job's done!");

        }
    }
}
