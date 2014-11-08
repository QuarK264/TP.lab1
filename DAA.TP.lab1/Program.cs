namespace DAA.TP.lab1
{
    using System;

    class Program
    {
        /// <summary>
        /// Ввод пользовательского ПО
        /// </summary>
        /// <returns>Результаты ввода</returns>
        private static Software InputSoft()
        {
            Console.WriteLine("Введите имя желаемого ПО. Внимание, программа работает только с антивирусами, ОС, САПР и мультимедиа ПО.");
            Console.Write("Имя ПО: ");
            string name = Console.ReadLine();//имя может быть обсолютно любым, поэтому никаких дополнительных методов
            SoftwareType type = InputType();
            float price = InputPrice();
            return new Software(name, type, price);
        }

        /// <summary>
        /// Реализует корректный ввод типа ПО.
        /// </summary>
        /// <returns>Возвращает один из возможных типов</returns>
        private static SoftwareType InputType()
        {
            string SoftType;
            bool TypeCoincides;
            Console.WriteLine("Пожалуйста укажите тип (английская раскладка). Для ОС введите OS, для антивируса - Antivirus, для САПР - CAD, для мультимедиа - multimedia");
            do
            {
                SoftType = Console.ReadLine();
                foreach (string EnumSoftType in Enum.GetNames(typeof(SoftwareType)))
                {
                    TypeCoincides = SoftType == EnumSoftType;
                    if (TypeCoincides)
                    {
                        return (SoftwareType)Enum.Parse(typeof(SoftwareType), SoftType);                        
                    }
                }
            }
            while (true);
        }

        /// <summary>
        /// Реализует корректный ввод цены
        /// </summary>
        /// <returns>Возвращает цену вещественного типа</returns>
        private static float InputPrice()
        {
            Console.WriteLine("Пожалуйста укажите цену ПО");
            string price;
            float Price;
            do//исключаем буквы
            {
                price = Console.ReadLine();
            }
            while (!float.TryParse(price, out Price));
            Price = float.Parse(price);
            if (Price < 0)//исключаем значения меньше ноля
            {
                InputPrice();
            }
            return Price;
        }

        /// <summary>
        /// Осуществляется вывод результатов работы программы на экран.
        /// </summary>
        /// <param name="compNT">Результат сравнения стандартного и пользовательского ПО по типам и именам</param>
        /// <param name="compNTP">Результат сравнения стандартного и пользовательского ПО по типам, именам и ценам</param>
        private static void Output(bool compNT, string compNTP)//из экземпляра класса можно потом поля класса вызвать
        {
            Console.WriteLine("Результаты первого сравнения с учётом имён и типов:\n{0}", compNT);
            Console.WriteLine("Результаты второго сравнения с учётом имён, типов и цен:\n{0}", compNTP);
            Console.WriteLine("Вы хотите стравнить два других ПО?\nДля подтвержения введите Y (Yes), для отказа N (No).");
            RepeatProgram();
        }

        /// <summary>
        /// Метод даёт возможность сравнить ещё одно ПО с текущим вызовом Main при утвердительном ответе
        /// </summary>
        private static void RepeatProgram()
        {
            string Answer;
            do
            {
                Answer = Console.ReadLine().ToUpper();
                if (Answer == "Y" || Answer == "N")
                {
                    break;
                }
            }
            while (true);

            if (Answer == "Y")
            {
                Main();
            }
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        static void Main()
        {
            Software FirstSoft = new Software();
            Software SecondSoft = InputSoft();
            bool CompareNameType = FirstSoft.Compare(SecondSoft.Name, SecondSoft.SoftType);
            string CompareNameTypePrice = FirstSoft.Compare(SecondSoft.Name, SecondSoft.SoftType, SecondSoft.Price);
            Output(CompareNameType, CompareNameTypePrice);
        }

    }
}
