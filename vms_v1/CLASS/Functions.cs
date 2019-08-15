using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vms_v1;
using Bunifu.Framework.UI;
using System.Windows.Forms;
using System.IO;


namespace vms_v1.CLASS
{
    class Functions
    {
        public static String GetSettingItem(String path, String Identifier)
        {
            StreamReader S = new StreamReader(path);
            string Result = "";
            do
            {
                string Line = S.ReadLine();
                if (Line.ToLower().StartsWith(Identifier.ToLower() + "="))
                {
                    Result = Line.Substring(Identifier.Length + 2);
                }
            } while (S.Peek() != -1);
            return Result;
        }
       

        public static String toTitleCase(Object obj)
        {
            string newString = string.Empty;
            BunifuMetroTextbox txt = (BunifuMetroTextbox)obj;
            string s = (string)txt.Text;
            try
            {
                newString = newString + char.ToUpper(s[0]);
                for (int i = 1; i < s.Length; i++)
                {
                    if (char.IsLower(s[i]))
                    {
                        newString = newString + s[i];
                    }
                    if (char.IsUpper(s[i]))
                    {
                        newString = newString + char.ToLower(s[i]);
                    }
                    if ((s[i] == '-'))
                    {
                        newString = newString + s[i];
                        newString = newString + char.ToUpper(s[i + 1]);
                        i++;
                    }
                    if (char.IsDigit(s[i]))
                    {
                        newString = newString + s[i];
                        newString = newString + char.ToUpper(s[i + 1]);
                        i++;

                    }
                    if (char.IsWhiteSpace(s[i]))
                    {
                        newString = newString + s[i];
                        newString = newString + char.ToUpper(s[i + 1]);
                        i++;
                    }
                }
            }
            catch (IndexOutOfRangeException e) {  /*MessageBox.Show(e.Message);*/ }

            return newString;
        }
        public static void noSpace(Object obj)
        {
            BunifuMetroTextbox shit = (BunifuMetroTextbox)obj;
            if (string.IsNullOrWhiteSpace((string)shit.Text))
                shit.Text = string.Empty;
        }

        public static void numberOnly(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                if (e.KeyChar == ',')
                    e.Handled = false;
            }
        }
        public static void letterOnly(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar)
                && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                if (e.KeyChar == '-')
                    e.Handled = false;
            }
        }

        public static bool checkSpace(params string[] buni)
        {
            for (int i = 0; i < buni.Length; i++)
            {
                if (buni[i] == string.Empty)
                    return true;
            }
            return false;
        }

        public static string generateRandomString() 
        {
            System.Random rnd = new System.Random();
            const string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            string temp = "";

            for (int i = 0; i < 30;i++) 
            {
                temp = temp + alpha[rnd.Next(61)];
            }

            return "chy" + temp; 
        }



    }//
}
