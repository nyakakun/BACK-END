using System;
using System.Collections.Generic;
using System.Net;
namespace Calc
{
    internal class Program
    {
        static int Main(string[] args)
        {

            string Line;

            while ((Line = Console.ReadLine()) != null)
            {
                if (Line.ToLower() == "exit")
                {
                    return 0;
                }
                try
                {
                    double ResultNum = Calc(Line);
                    Console.WriteLine(ResultNum);
                }
                catch (Exception Error)
                {
                    Console.WriteLine(Error.Message);
                }
            }
            return 0;
        }

        static double Calc(string Line)
        {

            (double LeftNum, char Operation, double RightNum) = PharseArgs(Line);
            double ResultNum = 0;
            if (Operation == '+')
            {
                ResultNum = LeftNum + RightNum;
            }
            else if (Operation == '-')
            {
                ResultNum = LeftNum - RightNum;
            }
            else if (Operation == '*')
            {
                ResultNum = LeftNum * RightNum;
            }
            else if (Operation == '/')
            {
                if (RightNum == 0)
                {
                    throw new Exception("Деление на ноль");
                }
                ResultNum = LeftNum / RightNum;
            }

            return ResultNum;
        }

        static (double, char, double) PharseArgs(string Line)
        {
            static List<string> PharseLine(string Line)
            {
                List<string> Pharse = new List<string>();
                Pharse.Add("");
                foreach (char c in Line)
                {
                    switch (c)
                    {
                        /*case ' ':
                            //if (Args[^1] != "") Args.Add("");
                            break;*/
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            {
                                Pharse.Add(c.ToString());
                                Pharse.Add("");
                                break;
                            }
                        default:
                            {
                                Pharse[^1] += c;
                                break;
                            }
                    }
                }

                for (int i = Pharse.Count - 1; i >= 0; i--)
                {
                    Pharse[i] = Pharse[i].Trim();
                    if (Pharse[i] == "")
                    {
                        Pharse.RemoveAt(i);
                    }
                }
                return Pharse;
            }

            List<string> PharseArgs = PharseLine(Line);

            if (PharseArgs.Count != 3)
            {
                throw new Exception("Данные не соответствуют формату: [Число] [Операция(+ - * /)] [Число]" + '\n' +
                                    "или введите exit для выхода");
            }
            if (!double.TryParse(PharseArgs[0], out double LeftNum))
            {
                throw new Exception("Левый аргумент не является числом");
            }
            char Operation = PharseArgs[1].Trim() switch
            {
                "+" => '+',
                "-" => '-',
                "*" => '*',
                "/" => '/',
            };
            if (!double.TryParse(PharseArgs[2], out double RightNum))
            {
                throw new Exception("Правый аргумент не является числом");
            }
            return (LeftNum, Operation, RightNum);
        }
    }
}
