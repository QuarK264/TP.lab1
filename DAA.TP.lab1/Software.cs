namespace DAA.TP.lab1
{
    using System;

    /// <summary>
    /// Хранение информации о ПО и их сравнение
    /// </summary>
    class Software
    {
        /// <summary>
        /// Имя ПО, используется в методах сравнения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена ПО, используется в методах сравнения
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Тип ПО, используется в методах сравнения
        /// </summary>
        public SoftwareType SoftType { get; set; }

        /// <summary>
        /// Конструктор класса, инициализирует стандартный экземпляр класса
        /// </summary>
        public Software()
        {
            this.Name = "Dr. Web";
            this.SoftType = SoftwareType.Antivirus;
            this.Price = 2000;
        }

        /// <summary>
        /// Конструктор класса Software, инициализирующий ПО, введённое пользователем
        /// </summary>
        /// <param name="name">Имя. Фактиески используется имя, указанное пользователем</param>
        /// <param name="type">Тип. Фактиески используется тип, указанный пользователем</param>
        /// <param name="price">Цена. Фактиески используется цена, указанная пользователем</param>        
        public Software(string name, SoftwareType type, float price)
        {
            this.Name = name;
            this.SoftType = type;
            this.Price = price;
        }

        /// <summary>
        /// Сравниваются имена и типы, если всё совпадает - ПО совпадают.
        /// </summary>
        /// <param name="SoftName">Имя введённого ПО</param>
        /// <param name="SoftType">Тип введённого ПО</param>
        /// <returns>Возвращает совпадают стандартное и введённое ПО или нет</returns>
        public bool Compare(string SoftName,SoftwareType SoftType)
        {
            return CompareNames(SoftName) && CompareTypes(SoftType);
        }

        /// <summary>
        /// Сравнение ПО по именам, типам и ценам
        /// </summary>
        /// <param name="SoftName">Имя введённого ПО</param>
        /// <param name="SoftType">Тип введённого ПО</param>
        /// <param name="SoftPrice">Цена введённого ПО</param>
        /// <returns>Результат сравнения стандартного и пользовательского по именам, типам и ценам</returns>
        public string Compare(string SoftName, SoftwareType SoftType, float SoftPrice)
        {
            string compNT = Compare(SoftName, SoftType).ToString();
            string compPrices = ComparePrice(SoftPrice);
            return compNT + ", " + compPrices;
        }

        /// <summary>
        /// Сравнение цен
        /// </summary>
        /// <param name="SoftPrice">Цена введённого ПО</param>
        /// <returns>Возвращает совпадают цены или нет</returns>
        private string ComparePrice(float SoftPrice)
        {
            if (this.Price == SoftPrice)
            {
                return "цены равны";
            }
            else
            {
                if (this.Price > SoftPrice)
                {
                    return "цена первого ПО больше цены второго";
                }
                else
                {
                    return "цена второго ПО больше цены первого";
                }
            }
        }

        /// <summary>
        /// Сравнение имён
        /// </summary>
        /// <param name="SoftName">Имя введённого ПО</param>
        /// <returns>Возвращает совпадают имена или нет</returns>
        private bool CompareNames(string SoftName)
        {
            return this.Name.Equals(SoftName);
        }

        /// <summary>
        /// Сравнение типов
        /// </summary>
        /// <param name="SoftType">Тип введённого ПО</param>
        /// <returns>Возвращает совпадают типы или нет</returns>
        private bool CompareTypes(SoftwareType SoftType)
        {
            return this.SoftType.Equals(SoftType);
        }
    }
}
