using System;

namespace Answers
{
    class Program
    {
        static void Main(string[] args)
        {
            Sum();
            Fibonacci();
        }

        static void Sum()
        {
            int INDICE = 13, SOMA = 0, K = 0;
            while (K < INDICE)
            {
                K = K + 1;
                SOMA = SOMA + K;
            }

            Console.WriteLine(SOMA); // 91
        }

        static void Fibonacci() {
            Console.Write("Informe um número para verificar se pertence à sequência de Fibonacci: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (BelongsFibonacci(number))
                {
                    Console.WriteLine($"O número {number} pertence à sequência de Fibonacci.");
                }
                else
                {
                    Console.WriteLine($"O número {number} NÃO pertence à sequência de Fibonacci.");
                }
            }
            else
            {
                Console.WriteLine("Por favor, informe um número válido.");
            }
        }

        static bool BelongsFibonacci(int number)
        {
            if (number < 0)
                return false;

            int a = 0, b = 1;

            while (a <= number)
            {
                if (a == number)
                    return true;

                int temp = a + b;
                a = b;
                b = temp;
            }

            return false;
        }
    }
}
