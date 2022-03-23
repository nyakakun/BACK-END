using System;
using System.Net;
namespace Calc
{
    internal class Program
    {
        static int Main(string[] args)
        {
            try
            {
                var (FistNumber, Operation, SecondNumber) = PharseArgs(args);
                switch (Operation)
                {
                    case '+':
                        Console.WriteLine(FistNumber + SecondNumber);
                        break;
                    case '-':
                        Console.WriteLine(FistNumber - SecondNumber);
                        break;
                    case '*':
                        Console.WriteLine(FistNumber * SecondNumber);
                        break;
                    case '/':
                        Console.WriteLine(FistNumber / SecondNumber);
                        break;
                }
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message);
                return 1;
            }
            return 0;
        }

        static (double, char, double) PharseArgs(string[] args)
        {

            if (args.Length != 3) { throw new Exception("Ожидалось 3 параметра; [число] [операция] [число]"); }
            double FistNumber, SecontNamber;
            char Operation = '\0';
            if (!double.TryParse(args[0], out FistNumber)) { throw new Exception("ожидалось число первым аргументом"); }

            switch (args[1].Trim()[0])
            {
                case '+':
                    Operation = '+';
                    break;
                case '-':
                    Operation = '-';
                    break;
                case '*':
                    Operation = '*';
                    break;
                case '/':
                    Operation = '/';
                    break;
                default: throw new Exception("Ожидалась арифместическая операция вторым аргументом (+, -, *, /)");
            }

            if (!double.TryParse(args[2], out SecontNamber)) { throw new Exception("ожидалось число третьим аргументом"); }

            return (FistNumber, Operation, SecontNamber);
        }
    }
}
