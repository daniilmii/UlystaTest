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
            var line2 = entity.digit[2].Trim(' ');
            var line3 = entity.digit[3].Trim(' ');

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
            string filePath = @"c:\Users\minak\Desktop\NumberParser.txt";
            var sr = new StreamReader(filePath);
            try
            {
                int lineCounter = 0;
                int digitHeight = 4;



                //string[][] rows = new string[digitHeight + 1][];

                string[] rowsInternal = new string[4];

                //var trimLine = line.Trim(' ');

                //if (trimLine.Length == 0)
                //{
                //    line = sr.ReadLine();
                //    continue;
                //}
                int rowCounter = 0;
                rowsInternal[0] = sr.ReadLine();
                rowsInternal[1] = sr.ReadLine();
                rowsInternal[2] = sr.ReadLine();
                rowsInternal[3] = sr.ReadLine();


                int xDelimiterIndex = 0;
                int yDelimiterIndex = 0;


                while (yDelimiterIndex != rowsInternal[0].Length)
                {


                    if (rowsInternal[0][yDelimiterIndex] == ' ')
                    {
                        yDelimiterIndex++;
                        continue;
                    }

                    for (int i = 0; i < rowsInternal.Length; i++)
                    {

                        for (int j = yDelimiterIndex; j < rowsInternal[0].Length; j++)
                        {
                            if (rowsInternal[0][j] != ' ')
                            {
                                continue;
                            }
                            else
                            {
                                yDelimiterIndex = j;
                                break;
                            }

                        }
                        if (rowsInternal[i][yDelimiterIndex] != ' ')
                        {
                            continue;
                        }
                    }


                    DigitEntity entity = new DigitEntity();

                    for (int a = 0; a < 4; a++)
                    {
                        entity.digit[a] = rowsInternal[a].Substring(xDelimiterIndex, yDelimiterIndex - xDelimiterIndex);
                    }

                    DigitsProcessor(entity);
                    xDelimiterIndex = yDelimiterIndex;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            finally
            {
                sr.Dispose();
            }





        }

    }
}
