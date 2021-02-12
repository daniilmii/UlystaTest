using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlystaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input full path to file with file extension: ");
            StreamReader reader = null;

            while (true)
            {
                string filePath = Console.ReadLine();

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found, please input correct path :");
                    continue;
                }
                else
                {
                    reader = new StreamReader(filePath);
                    break;
                }
            }

            try
            {
                const int digitHeight = 4;
                string[] rowsInternal = new string[digitHeight];
                int rowCount = 0;
                string line;

                //first index
                int xIndex = 0;
                
                //last index
                int yIndex = 0;
                while ((line = reader.ReadLine()) != null)
                {

                    //read 4 rows in iteration 
                    var trimLine = line.Trim(' ');
                    if ((trimLine.Length == 0))
                    {
                        continue;
                    }
                    if (rowCount < digitHeight - 1)
                    {
                        rowsInternal[rowCount] = line;
                        rowCount++;
                        continue;
                    }
                    else if (rowCount == digitHeight - 1)
                    {
                        rowsInternal[rowCount] = line;
                        rowCount = 0;
                        xIndex = 0;
                        yIndex = 0;
                    }

                    //main logic
                    while (yIndex < rowsInternal[0].Length)
                    {
                        //increase yIndex before we find end of current digit
                        if (rowsInternal[0][yIndex] == ' ')
                        {
                            yIndex++;
                            continue;
                        }

                        for (var rowIndex = 0; rowIndex < digitHeight; rowIndex++) 
                        {
                            if (rowsInternal[rowIndex][yIndex] != ' ')
                            {
                                for (int j = yIndex; j < rowsInternal[0].Length; j++)
                                {
                                    if (j == rowsInternal[0].Length - 1)
                                    {
                                        yIndex = j;

                                        break;
                                    }
                                    if (rowsInternal[rowIndex][j] != ' ')
                                    {
                                        continue;
                                    }

                                    else
                                    {
                                        yIndex = j;
                                        break;
                                    }

                                }
                            }
                        }

                        string[] digit = new string[4];

                        for (int a = 0; a < 4; a++)
                        {
                             digit[a] = rowsInternal[a].Substring(xIndex, yIndex + 1 - xIndex);
                        }

                        DigitsProcessor(digit);

                        //save last index in first index
                        xIndex = yIndex;
                        yIndex++;

                    }

                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            finally
            {
                reader.Dispose();
            }
        }
        public static void DigitsProcessor(string[] digit)
        {
            var line0 = digit[0].Trim(' ');
            var line1 = digit[1].Trim(' ');

            switch (line0)
            {
                case "---":
                    if (line1 == "/")
                    {
                        Console.Write("3");
                    }
                    else if (line1 == "_|")
                    {
                        Console.Write("2");
                    }

                    break;

                case "|":
                    Console.Write("1");
                    break;

                case "|   |":
                    Console.Write("4");
                    break;

                case "-----":
                    Console.Write("5");
                    break;
            }
        }

    }
}
