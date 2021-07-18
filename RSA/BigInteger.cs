using System;
using System.Collections.Generic;
using System.Text;

namespace RSA_Public_Key_Cryptosystem_Team_12
{
    public class BigInteger
    {
        public string Num;
        
        public BigInteger()
        { }
        public BigInteger(string num)
        {
            Num = num;
        }

        public  string M(string first, string second)
        {
            var n = Math.Max(first.Length, second.Length);
            var m = Math.Min(first.Length, second.Length);
            if (first.Length == 0 || second.Length == 0)
                return ("0");

            
            if (n < 9)
            {
                return (long.Parse(first) * long.Parse(second)).ToString();
            }
            int N = Math.Min(first.Length, second.Length);
            N = N / 2 + N % 2;
            string a = first.Remove(first.Length - N);
            string b = first.Substring(first.Length -N);
            string c = second.Remove(second.Length - N);
            string d = second.Substring(second.Length -N);

           // Console.WriteLine(first + '*' + second + '*' + a + ' ' + b + ' ' + c + ' ' + d);
           

            string ac = M(a, c);
            string bd = M(b, d);
            string ab_cd = M((new BigInteger(a) + new BigInteger(b)).Num, (new BigInteger(c) + new BigInteger(d)).Num);
            return calculateResult(ac, bd, ab_cd, b.Length + d.Length);
        }

        public static BigInteger operator -(BigInteger a, BigInteger b) 
        {
            String str_result = "";
   
            while (b.Num.Length < a.Num.Length) 
                b.Num = "0" + b.Num;           
                                               

            int carry = 0;

            for (int i = a.Num.Length-1; i>=0; i--)
            {
                if ((int)a.Num[i] - carry >= (int)b.Num[i])
                {
                    str_result = (char)((int)a.Num[i] - (int)b.Num[i] - carry  +'0') + str_result;
                    carry = 0;
                }
                else
                {
                    str_result = (char)((int)a.Num[i] - (int)b.Num[i] - carry + 10 + '0') + str_result;
                    carry = 1;
                }

            }
            int j = 1;
            for (int i = 0; i < str_result.Length; i++)
            {
                if (str_result[i] == '0')
                    j++;
                else
                    break;
            }
            if (j > str_result.Length)
                return new BigInteger("0");
            return new BigInteger(str_result.Substring(j-1));
        }
        public static BigInteger operator +(BigInteger a, BigInteger b)
        {
            if (a.Num.Length > b.Num.Length)
            {
                string temp = a.Num;
                a.Num = b.Num;
                b.Num = temp;
            }
            string Result = "";
            int n1_size = a.Num.Length;
            int n2_size = b.Num.Length;
            int size_of_larger = n2_size - n1_size;
            int carry = 0;
            int sum_temp;
            for (int i = n1_size - 1; i >= 0; i--)
            {
                sum_temp = ((int)(a.Num[i] - '0') + (int)(b.Num[i + size_of_larger] - '0') + carry);
                Result += (char)(sum_temp % 10 + '0');
                carry = sum_temp / 10;
            }
            for (int i = n2_size - n1_size - 1; i >= 0; i--)
            {
                sum_temp = ((int)(b.Num[i] - '0') + carry);
                Result += (char)(sum_temp % 10 + '0');
                carry = sum_temp / 10;
            }
            if (carry > 0)
                Result += (char)(carry + '0');

            char[] ch_result = Result.ToCharArray();
            Array.Reverse(ch_result);
            Result = new string(ch_result);

            return new BigInteger(Result);
        }
        
       

       

        
        static  string  calculateResult(string ac, string bd, string ab_cd, int padding)
        {
            string term0 = ((new BigInteger (ab_cd)- new BigInteger (ac)) - new BigInteger(bd)).Num;
            string term1 = term0.PadRight(term0.Length + padding / 2, '0');
            string term2 = ac.PadRight(ac.Length + padding, '0');
            return (new BigInteger(term1)+ new BigInteger(term2)+ new BigInteger(bd)).Num;
        }
        


    }
}
