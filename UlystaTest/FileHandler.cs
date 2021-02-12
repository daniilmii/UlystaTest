﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlystaTest
{
  public static  class FileHandler
    {
        public static string ReadFile(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                return sr.ReadLine();
            }

        }
    }
}
