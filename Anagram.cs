using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

internal class Anagram
{

    //Chenell Mason
    // isAnagram Project

    //NOTICE ABOUT INPUT.TXT SET LOCATION:
    //The input file location is set to @C:\\input.txt
    //The output file is written to location Program\bin\debug\Net6.0 in the attach zip file: It should also automatically pop up after the program is ran.








    //Input file reader; reads input file and writes the file content into a String list.
    public static List<String> filereader(String inputreader)
    {
        List<String> fl = new List<String>();
        if (File.Exists(inputreader))
        {
            Process.Start("explorer.exe", inputreader);
        }


        foreach (string line in File.ReadLines(inputreader, Encoding.UTF8))
        {
           
            fl.Add(line);
        }




        return fl;
    }

    //Output file creator; The list is written into a new file. The file will open automattically after.
    public static void fileoutput(List<String> inputread)
    {
        
        string outputfile = "output.txt";
       

        File.WriteAllLines(outputfile, inputread);
        if (File.Exists(outputfile))
        {
            Process.Start("explorer.exe", outputfile);
        }

    }


   //String separator: The input file content are separated into single words and then added into a new string list.
    public static List<String> splitter(List<String> r)
    {
        List<String> result = new List<String>();


        foreach (String y in r)
            {
                String[] x = y.Split(',');

                for (int j = 0; j < x.Length; j++)
                {
                x[j].Replace(' ', '0');



                String y1 = String.Concat(x[j].Where(c => !Char.IsWhiteSpace(c)));


                result.Add(y1);
                //    Console.WriteLine(x[j]);
                }

            }



        result.Sort((a, b) => a.Length.CompareTo(b.Length));


        return result;
    }


    //Checks if two string are Anagram to one another. Returns true or false;
    public static bool isAnagram(String a, String b)
    {


        string aa = String.Concat(a.OrderBy(c => c));
        string bb = String.Concat(b.OrderBy(c => c));

      
            if (a != b)
            {
                if (aa.Contains(bb))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;


       


    }


    //Prints out all the anagram found in the input file. 
    public static List<String> anagramresult(List<String> inputread)
    {
        List<String> finalresult = new List<string>();
        //Part One

        List<int> index1 = new List<int>();
        List<int> index2 = new List<int>();
        List<String> ircopy = inputread; //To Hold a copy of the list in function


        for (int i = 0; i < inputread.Count; i++)
        {
            for (int j = 0; j < inputread.Count; j++)
            {
                if (isAnagram(inputread[i], ircopy[j]) == true)
                {



                    if (ircopy[j].Length == inputread[i].Length)
                    {
                        index1.Add(i);
                        index2.Add(j);
                    }
                }
            }
        }

        //Part Two

        List<List<String>> list = new List<List<String>>();
        foreach (String x in inputread)
        {
            List<String> temp = new List<String>();
            temp.Add(x);
            list.Add(temp);
        }


        //Part Three
        for (int v = 0; v < list.Count; v++)
        {
            for (int b = 0; b < list[v].Count; b++)
            {
                int cindex = inputread.IndexOf(list[v][b]);
              

                for (int i = 0; i < index1.Count; i++)
                {



                    if (cindex == index1[i])
                    {

                        int ind = index2[i];
                        String temp = inputread[ind];

                        list[v][b] += "," + inputread[ind];



                    }



                }

            }
        }
        //Part Four

     
        List<String> finalresult1 = new List<string>();  //To Hold a copy of finalresult list

        foreach (List<String> a in list)
        {
            foreach (String b in a)
            {
                
                finalresult.Add("["+b+"]");
            }
        }

        finalresult1 = finalresult;

        for (int i = 0; i < finalresult1.Count; i++)
        {
            for (int j = 0; j < finalresult.Count; j++)
            {
                if (finalresult[i].Length == finalresult1[j].Length)
                {
                    // Console.WriteLine(finalresult[i] + " " + finalresult1[j]);

                    if (isAnagram(finalresult[i], finalresult1[j]) == true)
                    {
                        finalresult.RemoveAt(finalresult.IndexOf(finalresult1[j]));
                        // Console.WriteLine(finalresult[i] + " " + finalresult1[j] + "  test");
                    }
                   

                }


            }

        }


        

        return finalresult;

    }

    //Writes to output.txt
    public static void isAnagramOutput(List<String> a)
    {
        
        fileoutput(a);
    }


    private static void Main(string[] args)
    {
     

        String inputfilename ="c:\\input.txt";
      


        List<String> inputread = splitter(filereader(inputfilename));
        isAnagramOutput(anagramresult(inputread));

 
    }
}
