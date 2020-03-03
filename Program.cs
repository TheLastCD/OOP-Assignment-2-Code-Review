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
            DirectoryInfo d = new DirectoryInfo(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents"));
            FileInfo[] Files = d.GetFiles("*.txt");
            FileInfo filechoice1 = Files[0];
            int count = 1,UserFileChoice1 = 0, UserFileChoice2 =0;
            bool leave = false, failed = false;
            Console.WriteLine("Good Morning, I am in your documents folder, what txt files would you like to compare ");
            foreach (FileInfo txts in Files)
            {
                string[] justName= txts.ToString().Split("\\");
                Console.Write($"{count}.{justName[justName.Length-1]}, ");
                count++;
            }
            Console.WriteLine("\n Please enter the number");
            while (!leave)
            {
                try
                {
                    Console.WriteLine("Select the first file:");
                    UserFileChoice1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Select the second:");
                    UserFileChoice2 = Convert.ToInt32(Console.ReadLine());
                    leave = true;
                }

                catch
                {
                    Console.WriteLine("I'm Sorry there has been an error please enter it again");
                }
            }

            List<string> FirstFile = new List<string> (File.ReadAllLines(Files[UserFileChoice1 - 1].ToString()));
            List<string> SecondFile = new List<string> (File.ReadAllLines(Files[UserFileChoice2 - 1].ToString()));


            Console.WriteLine("Do you want the filter to be case sensitive? (Y/N)");
            leave = false;
            while(!leave)
            {
                string caseSense = Console.ReadLine();
                if (caseSense.ToLower().Trim() == "y" || caseSense.ToLower().Trim() == "n")
                {
                    leave = true;
                    if(caseSense.ToLower().Trim() == "y")
                    {
                        FirstFile = FirstFile.Select(x => x.ToLower()).ToList();
                        SecondFile = SecondFile.Select(x => x.ToLower()).ToList();
                    }
                    
                }

                else
                    Console.WriteLine("there has been an error please try again");
            }
            Txt_File First = new Txt_File(FirstFile);
            Txt_File Second = new Txt_File(SecondFile);
            List<(string,int)> SecList= Second.Get_List(),FirList = First.Get_List();
            try
            {
                for (int i = 0; i <= SecList.Count(); i++)
                {
                    if (SecList[i] != FirList[i])
                    {
                        Console.WriteLine("The Files are not the same");
                        failed = true;
                    }
                }
                if (!failed)
                {
                    Console.WriteLine("the two files are the same!!!");
                }
            }
            catch
            {
                Console.WriteLine("the files are not the same");
            }
            
        }











    }
    }
}
