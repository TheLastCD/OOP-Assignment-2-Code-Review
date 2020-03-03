using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;

namespace OOP_Assignment_2_Code_Review
{
    class Txt_File
    {
        List<string> file;
        public int length;
        Dictionary<string, int> compressedFile;

        public Txt_File(List<string> f)
        {
            file = f;
            length = f.Count;
        }
        public Dictionary<string, int> Get_Dictionary()
        {
            foreach (string word in file)
            {
                if (compressedFile.ContainsKey(word))
                {
                    compressedFile[word] += 1;
                }
                else
                {
                    compressedFile.Add(word, 1);
                }
            }
            return compressedFile;
        }

    }
}
