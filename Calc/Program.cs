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
                Console.WriteLine(
                    Operation switch
                    {
                        '+' => FistNumber + SecondNumber,
                        '-' => FistNumber - SecondNumber,
                        '*' => FistNumber * SecondNumber,
                        '/' => FistNumber / SecondNumber,
                    }
                );
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

            if (!double.TryParse(args[0], out double FistNumber)) { throw new Exception("ожидалось число первым аргументом"); }

            char Operation = args[1].Trim()[0] switch
            {
                '+' => '+',
                '-' => '-',
                '*' => '*',
                '/' => '/',
                _ => throw new Exception("Ожидалась арифместическая операция вторым аргументом (+, -, *, /)"),
            };

            if (!double.TryParse(args[2], out double SecontNamber)) { throw new Exception("ожидалось число третьим аргументом"); }

            return (FistNumber, Operation, SecontNamber);
        }
    }
}
