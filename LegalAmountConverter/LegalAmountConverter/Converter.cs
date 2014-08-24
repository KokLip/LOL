using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LegalAmountConverter;

namespace LegalAmountConverter
{

    public class NegativeNumberException : Exception
    {
        public NegativeNumberException()
            : base("Negative number is not allowed")
        {
        }
    }

    public interface Language
    {
        string Converter();
    }


    public class Melayu : Language
    {
        string[] Ones = { "Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tuhuh", "Lapan", "Sembilan", "Sepuluh", "Sebelas", "Dua Belas", "Tiga Belas", "Empat Belas", "Lima Belas", "Enam Belas", "Tujuh Belas", "Lapan Belas", "Sembilan Belas" };
        string[] Tens = { "Sepuluh", "Dua Puluh", "Tiga Puluh", "Empat Puluh", "Lima Puluh", "Enam Puluh", "Tujuh Puluh", "Lapan Puluh", "Sembilan Puluh" };

        double no;

       public Melayu(double no)
        {
            this.no = no;
        }

        public string Converter()
        {
            string strWords = "";
            string strDecimalWords = "";

            if (no.ToString().Contains('.'))
            {
                


                if (decPart > 20 && decPart < 100)
                {
                    double i = decPart / 10;
                    double db = Math.Floor(i);
                    int result = Convert.ToInt32(db);
                    strDecimalWords = strDecimalWords + "Dan Sen" + " " + Tens[result - 1] + " ";
                    decPart = decPart % 10;
                }

                if (decPart > 0 && decPart < 20)
                {
                    int change = Convert.ToInt32(decPart);
                    strDecimalWords = strDecimalWords + Ones[change - 1] + " sahaja";
                }
            }

                if (no >= 100000 && no < 1000000)
                {
                    double i = no / 100000;
                    double db = Math.Floor(i);
                    int result = Convert.ToInt32(db);
                    strWords = strWords + Ones[result - 1] + " Ratus ";
                    no = Math.Floor(no) % 100000;
                }

                if (no >= 20000 && no < 100000)
                {
                    double i = no / 10000;
                    double db = Math.Floor(i);
                    int result = Convert.ToInt32(db);
                    strWords = strWords + Tens[result - 1] + " ";
                    no = Math.Floor(no) % 10000;
                }

                if (no > 10000 && no < 20000)
                {
                    double db = Math.Floor(no);
                    int change = Convert.ToInt32(db);
                    strWords = strWords + Ones[change - 1] + " Ribu";
                }


                if (no > 999 && no < 10000)
                {
                    double i = no / 1000;
                    double db = Math.Floor(i);
                    int result = Convert.ToInt32(db);
                    strWords = strWords + Ones[result - 1] + " Ribu ";
                    no = Math.Floor(no) % 1000;
                }


                if (no >= 100 && no < 1000)
                {
                    double i = no / 100;
                    double db = Math.Floor(i);
                    int result = Convert.ToInt32(db);
                    strWords = strWords + Ones[result - 1] + " Ratus ";
                    no = Math.Floor(no) % 100;
                }

                if (no >= 20 && no < 100)
                {
                    double i = no / 10;
                    double db = Math.Floor(i);
                    int result = Convert.ToInt32(db);
                    strWords = strWords + Tens[result - 1] + " ";
                    no = Math.Floor(no) % 10;
                }

                if (no > 0 && no < 20)
                {
                    double db = Math.Floor(no);
                    int change = Convert.ToInt32(db);
                    strWords = strWords + Ones[change - 1] + " ";
                }

                strWords = strWords + strDecimalWords;
     
             return strWords;
        }
    }

    public class English : Language
    {
        string[] Ones = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen" };
        string[] Tens = { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };

        double no;

        public English(double no)
        {
            this.no = no;
        }

        public string Converter()
        {
            string strWords = "";
            string strDecimalWords = "";
            if (no.ToString().Contains('.'))
            {
                string[] splitter = no.ToString().Split('.');
                double decPart = double.Parse(splitter[1]);

                if (decPart > 20 && decPart < 100)
                {
                    double i = decPart / 10;
                    double db = Math.Floor(i);
                    int result = Convert.ToInt32(db);
                    strDecimalWords = strDecimalWords + "And Cents" + " " + Tens[result - 1] + " ";
                    decPart = decPart % 10;
                }

                if (decPart > 0 && decPart < 20)
                {
                    int change = Convert.ToInt32(decPart);
                    strDecimalWords = strDecimalWords + Ones[change - 1] + " only";
                }
            
            }
                         
            if (no >=100000 && no < 1000000)
            {
                double i = no / 100000;
                double db = Math.Floor(i);
                int result = Convert.ToInt32(db);
                strWords = strWords + Ones[result - 1] + " Hundred ";
                no = Math.Floor(no) % 100000;
            }

            if (no >= 20000 && no < 100000)
            {
                double i = no / 10000;
                double db = Math.Floor(i);
                int result = Convert.ToInt32(db);
                strWords = strWords + Tens[result - 1] + " ";
                no = Math.Floor(no) % 10000;
            }

            if (no >= 10000 && no < 20000)
            {
                double i = no / 1000;
                double db = Math.Floor(i);
                int result = Convert.ToInt32(db);
                strWords = strWords + Ones[result - 1] + " Thousand ";
                no = Math.Floor(no) % 1000;
            }

            if (no >= 1000 && no < 10000)
            {
                double i = no / 1000;
                double db = Math.Floor(i);
                int result = Convert.ToInt32(db);
                strWords = strWords + Ones[result - 1] + " Thousand ";
                no = Math.Floor(no) % 1000;
            }


            if (no >= 100 && no < 1000)
            {
                double i = no / 100;
                double db = Math.Floor(i);
                int result = Convert.ToInt32(db);
                strWords = strWords + Ones[result - 1] + " Hundred ";
                no = Math.Floor(no) % 100;
            }

            if (no >= 20 && no < 100)
            {
                double i = no / 10;
                double db = Math.Floor(i);
                int result = Convert.ToInt32(db);
                strWords = strWords + Tens[result - 1] + " ";
                no = Math.Floor(no) % 10;
            }

            if (no > 0 && no < 20)
            {
                double db = Math.Floor(no);
                int change = Convert.ToInt32(db);
                strWords = strWords + Ones[change - 1] + " ";
            }

            strWords = strWords + strDecimalWords;              

            return strWords;

        }
    }
}
