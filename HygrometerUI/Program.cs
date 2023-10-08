using HygrometerBL;
using System.Globalization;

//CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
Console.WriteLine("Добро пожаловать в приложение Hygrometer.\n");
string inputString = "";
Console.WriteLine("1. Определить относительную влажность воздуха психометрическим методом.");
Console.WriteLine("quit - Выход из программы.");

NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
{
    NumberDecimalSeparator = ".",
};

while (inputString != "quit")
{
    Console.Write("\nВведите команду: ");
    inputString = Console.ReadLine();

    switch (inputString)
    {
        case "1":
            Console.WriteLine("\nОпределение относительной влажности воздуха психометрическим методом.");
            double dryT, wetT;
            while (true)
            {
                Console.Write("Введите показание сухого термометра: ");
                if (double.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, numberFormatInfo,  out dryT))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод! Повторите ввод.");
                }
            }
            while (true)
            {
                Console.Write("Введите показание смоченного термометра: ");
                if (double.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, numberFormatInfo, out wetT))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод! Повторите ввод.");
                }
            }

            Hygrometer.PsychometricMethod(dryT, wetT, out double relativeHumidity);
            Console.WriteLine($"Относительная влажность воздуха: {relativeHumidity}%");
            break;
        default:
            break;
    }
}
