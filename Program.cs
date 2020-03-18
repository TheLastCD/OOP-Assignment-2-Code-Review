using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;

namespace OOP_Assignment_2_Code_Review
{
    class Program
    {
        static void Main(string[] args)
        {
            bool leave = false, failed = false;
            List<string> FirstFile = new List<string>(), SecondFile = new List<string>();
            string[] files = new string[0];
            while (!leave)
            {
                try
                {
                    Console.Write(">: [Input] ");
                    files = Console.ReadLine().Split();
                    if (files[0].ToLower() == "dif")
                    {
                        FirstFile = new List<string>(File.ReadAllLines(files[1].ToString()));
                        SecondFile = new List<string>(File.ReadAllLines(files[2].ToString()));
                        leave = true;
                    }
                    else
                    {
                        Console.WriteLine("You hvae not used the Dif command");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

            }
            Txt_File First = new Txt_File(FirstFile);
            Txt_File Second = new Txt_File(SecondFile);
            List<(string, int)> SecList = Second.Get_List(), FirList = First.Get_List();
            Console.Write($">: [Output] {files[1]} and {files[2]} are ");
            try
            {
                for (int i = 0; i < SecList.Count(); i++)
                {
                    
                    if (SecList[i] != FirList[i])
                    {
                        Console.WriteLine(i);
                        failed = true;
                        break;
                    }
                }
                if (!failed)
                {
                    Console.Write("not different");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
