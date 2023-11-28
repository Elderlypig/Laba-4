using System;
using System.IO;
using System.Globalization;

namespace РекурсивнаяСумма
{
    class Program
    {
        static void Main(string[] args)
        {
            double epsilon;
            СчитатьДанные(out epsilon);
            РешитьЗадачу(epsilon);
        }

        static void СчитатьДанные(out double epsilon)
        {
            epsilon = 0.0;
            using (StreamReader inputFile = new StreamReader("Inlet.in"))
            {

                string inputLine = inputFile.ReadLine() ?? "";
                if (!double.TryParse(inputLine, NumberStyles.Float, CultureInfo.InvariantCulture, out epsilon))
                {
                    Console.WriteLine("Не удалось преобразовать '{0}' в число с плавающей запятой.", inputLine);
                    return;
                }
            }
        }

        static void РешитьЗадачу(double epsilon)
        {
            double сумма = РекурсивныйРасчетСуммы(1, epsilon, 1.0 / 9.0); // Начинаем с n=1 и первого слагаемого ряда
            try
            {
                using (StreamWriter outputFile = new StreamWriter("Outlet.out"))
                {
                    outputFile.Write(сумма);
                }
                Console.WriteLine("Результат успешно записан в файл Outlet.out.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при записи результата в файл Outlet.out: " + ex.Message);
            }
        }

        static double РекурсивныйРасчетСуммы(int n, double epsilon, double слагаемое)
        {
            if (Math.Abs(слагаемое) < epsilon)
                return 0.0;
            else
                return слагаемое + РекурсивныйРасчетСуммы(n + 1, epsilon, 1.0 / (Math.Pow(4, n) + Math.Pow(5, n + 2)));
        }
    }
}
