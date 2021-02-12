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
        public static void DigitsProcessor(DigitEntity entity)
        {
            var line0 = entity.digit[0].Trim(' ');
            var line1 = entity.digit[1].Trim(' ');

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

                int xIndex = 0;
                int yIndex = 0;
                while ((line = reader.ReadLine()) != null)
                {

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



                    while (yIndex < rowsInternal[0].Length)
                    {
                        if (rowsInternal[0][yIndex] == ' ')
                        {
                            yIndex++;
                            continue;
                        }
                        for (int j = yIndex; j < rowsInternal[0].Length; j++)
                        {

                            if (j == rowsInternal[0].Length - 1)
                            {
                                yIndex = j;

                                break;
                            }
                            if (rowsInternal[0][j] != ' ')
                            {
                                continue;
                            }

                            else
                            {
                                yIndex = j;

                                break;
                            }

                        }
                        if (rowsInternal[1][yIndex] != ' ')
                        {
                            for (int j = yIndex; j < rowsInternal[0].Length; j++)
                            {
                                if (j == rowsInternal[0].Length - 1)
                                {
                                    yIndex = j;

                                    break;
                                }
                                if (rowsInternal[1][j] != ' ')
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
                        if (rowsInternal[2][yIndex] != ' ')
                        {
                            for (int j = yIndex; j < rowsInternal[0].Length; j++)
                            {
                                if (j == rowsInternal[0].Length - 1)
                                {
                                    yIndex = j;

                                    break;
                                }
                                if (rowsInternal[2][j] != ' ')
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
                        if (rowsInternal[3][yIndex] != ' ')
                        {
                            for (int j = yIndex; j < rowsInternal[0].Length; j++)
                            {
                                if (j == rowsInternal[0].Length - 1)
                                {
                                    yIndex = j;

                                    break;
                                }
                                if (rowsInternal[3][j] != ' ')
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

                        DigitEntity entity = new DigitEntity();

                        for (int a = 0; a < 4; a++)
                        {
                            entity.digit[a] = rowsInternal[a].Substring(xIndex, yIndex + 1 - xIndex);
                        }

                        DigitsProcessor(entity);

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

    }
}
