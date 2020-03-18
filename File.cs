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


        public Txt_File(List<string> f)
        {
            file = f;
            length = f.Count;
        }

        //Method Name: Get_List
        //Return: List<(string,int)>
        //Puporse: to compress the file using a lossless form of text compression
        public List<(string, int)> Get_List()
        {
            Dictionary<string, int> compressedFile = new Dictionary<string, int>();
            foreach (string paragraphs in file)
            {
                string[] words = paragraphs.Split();
                foreach(string word in words)
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
               
            }
            List<(string, int)> compressedlist = new List<(string, int)>();
            foreach(var entry in compressedFile)
            {
                compressedlist.Add((entry.Key,entry.Value));
            }

            return compressedlist;
        }

    }
}
