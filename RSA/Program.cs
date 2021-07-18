using System;
using System.IO;

namespace RSA_Public_Key_Cryptosystem_Team_12
{

    public class Program
    {
        public static void Main(string[] args)
        {
            long timeBefore = System.Environment.TickCount;

            CheckMulFunction("MultiplyTestCases.txt", "Output/MultiplyTestCases_Output.txt");
            CheckAddFunction("AddTestCases.txt", "Output/AddTestCases_Output.txt");
            CheckSubFunction("SubtractTestCases.txt", "Output/SubtractTestCases_Output.txt");
            long timeAfter = System.Environment.TickCount;

            Console.WriteLine("Finish After "+(timeAfter - timeBefore).ToString() +" ms");
        }


        static void CheckSubFunction(string inputName, string outName)
        {
            File.WriteAllText(outName, String.Empty);
            using (System.IO.StreamWriter write_file = new System.IO.StreamWriter(outName, true))
            {
                FileStream file = new FileStream(inputName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                int cases = int.Parse(sr.ReadLine());
                for (int i = 0; i < cases; i++)
                {
                    if (i > 0)
                    {
                        write_file.WriteLine(String.Empty);
                    }
                    sr.ReadLine();
                    BigInteger x = new BigInteger(sr.ReadLine());
                    BigInteger y = new BigInteger(sr.ReadLine());
                    write_file.WriteLine((x - y).Num);

                }
            }
        }
        static void CheckAddFunction(string inputName, string outName)
        {
            File.WriteAllText(outName, String.Empty);
            using (System.IO.StreamWriter write_file = new System.IO.StreamWriter(outName, true))
            {
                FileStream file = new FileStream(inputName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                int cases = int.Parse(sr.ReadLine());
                for (int i = 0; i < cases; i++)
                {
                    if (i > 0)
                        write_file.WriteLine(String.Empty);

                    sr.ReadLine();
                    BigInteger x = new BigInteger(sr.ReadLine());
                    BigInteger y = new BigInteger(sr.ReadLine());
                    write_file.WriteLine((x + y).Num);
                }
            }
        }
        static void CheckMulFunction(string inputName, string outName)
        {
            File.WriteAllText(outName, String.Empty);
            using (System.IO.StreamWriter write_file = new System.IO.StreamWriter(outName, true))
            {
                var temp = new BigInteger();
                FileStream file = new FileStream(inputName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                int cases = int.Parse(sr.ReadLine());
                for (int i = 0; i < cases; i++)
                {
                    if (i > 0)
                        write_file.WriteLine(String.Empty);

                    sr.ReadLine();
                    string x = sr.ReadLine();
                    string y = sr.ReadLine();
                    write_file.WriteLine(temp.M(x,y));
                }
            }
        }
    }
}
