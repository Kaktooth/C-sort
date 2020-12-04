using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp76
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Student[] stud = new Student[N];
            for (int i = 0; i < N; i++)
            {
                string surname = Convert.ToString(Console.ReadLine());
                string name = Convert.ToString(Console.ReadLine());
                string clas = Convert.ToString(Console.ReadLine());

                string dat = Convert.ToString(Console.ReadLine());
                stud[i] = new Student(surname,name,clas,dat);

            }
            Array.Sort(stud);
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(stud[i].Class.Replace(" ","")+" "+stud[i].SurName.Replace(" ", "") + " " + stud[i].Name.Replace(" ", "") + " " + stud[i].Date.Replace(" ", ""));
            }
          
        }
    }
    class Student : IComparable
    {
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Class{ get; set; }
        public int numonly { get; set; }
        public char letteronly { get; set; }
        public string Date { get; set; }
        public Student(string surname, string name, string @class,string date )
        {
            SurName = surname;
            Name = name;
            Class = @class;
            Date = date;
            numonly = Convert.ToInt32(Regex.Replace(Class, "[^0-9.]", ""));
            letteronly = Convert.ToChar(Regex.Replace(Class, "[^A-Z]", ""));
        }
        public int Rec(string sur,int len)
        {
            if ((char)SurName[len] < (char)sur[len])
            {
                return -1;
            }
            else if ((char)SurName[len] > (char)sur[len])
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int CompareTo(object o)
        {
            Student p = o as Student;
            int numberOnly = Convert.ToInt32(Regex.Replace(p.Class, "[^0-9.]", ""));
            char LetterOnly = Convert.ToChar(Regex.Replace(p.Class, "[^A-Z]", ""));
            if (p != null)
            {

                    if (numonly < numberOnly)
                    {
                        return -1;
                    }
                    else if (numonly > numberOnly)
                    {
                        return 1;
                    }
                    else if(numonly == numberOnly)
                    {
                      if (letteronly < LetterOnly)
                      {
                         return -1;
                      }
                      else if (letteronly > LetterOnly)
                      {
                         return 1;
                      }
                      else
                      {
                        if(String.Compare(SurName, p.SurName) > 0)
                        {
                            return 1;
                        }
                        else if (String.Compare(SurName, p.SurName) < 0)
                        {
                            return -1;
                        }
                        else
                        {
                            return 0;
                        }

                    }

                    }
                else
                {
                    return 0;
                }


            }
            else
            {
                throw new Exception("Невозможно сравнить");
            }
        }
    }
}
