using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Answers
{
    class Program
    {
        static void Main(string[] args)
        {
            Sum();
            Fibonacci();
            Invoicing();
            InvoicingPercent();
            StringInverterReader();
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

        static void Invoicing()
        {
            
            string filePath = "invoicing.json";

            List<InvoicingDay> invoicings = ReadInvoicing(filePath);

            if (invoicings == null || invoicings.Count == 0)
            {
                Console.WriteLine("Nenhum dado de faturamento encontrado.");
                return;
            }

            var daysWithInvoicing = invoicings.Where(f => f.Invoicing > 0).ToList();

            if (daysWithInvoicing.Count == 0)
            {
                Console.WriteLine("Não há dias com faturamento positivo.");
                return;
            }

            double minInvoicing = daysWithInvoicing.Min(f => f.Invoicing);
            double maxInvoicing = daysWithInvoicing.Max(f => f.Invoicing);

            double monthlyAverage = daysWithInvoicing.Average(f => f.Invoicing);

            int daysAboveAverage = daysWithInvoicing.Count(f => f.Invoicing > monthlyAverage);

            Console.WriteLine($"Menor faturamento: {minInvoicing:C}");
            Console.WriteLine($"Maior faturamento: {maxInvoicing:C}");
            Console.WriteLine($"Dias com faturamento acima da média: {daysAboveAverage}");
        }

        static List<InvoicingDay> ReadInvoicing(string filePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<InvoicingDay>>(jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo JSON: {ex.Message}");
                return null;
            }
        }

        static void InvoicingPercent()
        {
            double sp = 67836.43;
            double rj = 36678.66;
            double mg = 29229.88;
            double es = 27165.48;
            double outros = 19849.53;

            double faturamentoTotal = sp + rj + mg + es + outros;

            double percentualSP = (sp / faturamentoTotal) * 100;
            double percentualRJ = (rj / faturamentoTotal) * 100;
            double percentualMG = (mg / faturamentoTotal) * 100;
            double percentualES = (es / faturamentoTotal) * 100;
            double percentualOutros = (outros / faturamentoTotal) * 100;

            Console.WriteLine($"Percentual de SP: {percentualSP:F2}%");
            Console.WriteLine($"Percentual de RJ: {percentualRJ:F2}%");
            Console.WriteLine($"Percentual de MG: {percentualMG:F2}%");
            Console.WriteLine($"Percentual de ES: {percentualES:F2}%");
            Console.WriteLine($"Percentual de Outros: {percentualOutros:F2}%");
        }

        static void StringInverterReader()
        {
            Console.WriteLine("Digite uma string para inverter:");
            string input = Console.ReadLine();

            if (input != null)
            {
                string invertedString = StringInverter(input);

                Console.WriteLine("String invertida: " + invertedString);
            }
        }

        static string StringInverter(string str)
        {
            char[] caracteres = str.ToCharArray();
            int start = 0;
            int end = caracteres.Length - 1;

            while (start < end)
            {
                char temp = caracteres[start];
                caracteres[start] = caracteres[end];
                caracteres[end] = temp;

                start++;
                end--;
            }

            return new string(caracteres);
        }
    }

    class InvoicingDay
    {
        public int Day { get; set; }
        public double Invoicing { get; set; }
    }
}
