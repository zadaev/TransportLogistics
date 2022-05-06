
namespace TransportLogistika.BL
{
    /// <summary>
    ///  Class for working with the database
    /// </summary>
    public class WorkWithTLDB
    {
        public delegate void ActionHandler(string message);
        public static event ActionHandler? Notify;

        /// <summary>
        /// Choose what to do
        /// </summary>
        public static void GMethod()
        {
            Console.WriteLine("\n1.Создать \n2.Поиск \n3.Удалить");

            switch (Console.ReadLine())
            {
                case "1": Create(); break;
                case "2": Read(); break;
                case "3": Delete(); break;
            }

        }

        public static void Create()
        {
            Console.WriteLine("Кем вы являетесь? \n1.Водитель \n2.Компания \n3.Клиент \n4.Truck");
            string? whoIs = Console.ReadLine();

            switch (whoIs)
            {
                case "1":
                    {
                        #region Принимаем данные

                        Console.WriteLine("Введите имя");
                        var FistName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(FistName))
                            throw new ArgumentNullException("Имя не может быть пустым или null", nameof(FistName));

                        Console.WriteLine("Введите фамилию");
                        var LastName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(LastName))
                            throw new ArgumentNullException("Фамилия не может быть пустым или null", nameof(LastName));

                        Console.WriteLine("Введите номер телефона");
                        var PhoneNumber_1 = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(PhoneNumber_1))
                            throw new ArgumentNullException("Номер телефона не может быть пустым", nameof(PhoneNumber_1));

                        Console.WriteLine("Введите Email");
                        var Email = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(Email))
                            throw new ArgumentNullException("Email не может быть пустым", nameof(Email));


                        Console.WriteLine("Введите категорию");
                        var Category = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(Category))
                            throw new ArgumentNullException("Категория не может быть пустым", nameof(Category));

                        Console.WriteLine("Введите страну");
                        var Country = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(Country))
                            throw new ArgumentNullException("Страна не может быть пустым", nameof(Country));

                        Console.WriteLine("Введите с какого областя вы");
                        var Region = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(Region))
                            throw new ArgumentNullException("Область не может быть пустым", nameof(Region));

                        Console.WriteLine("Если вы добавили машину закрепите его в свой аккаунт \nдля этого отправьте номер машины(Если не добавляли нажмите Enter)");
                        string? numberCar = Console.ReadLine();

                        #endregion

                        using (TLContext db = new TLContext())
                        {
                            var truck = db.Truck.Where(t => t.CarNumber == numberCar).ToList();
                            var driver = new Driver
                            {
                                FistName = FistName,
                                LastName = LastName,
                                PhoneNumber_1 = PhoneNumber_1,
                                Email = Email,
                                Category = Category,
                                Country = Country,
                                Region = Region,
                                Address = Country + " " + Region,
                                Truck = truck
                            };

                            db.Driver.Add(driver);
                            db.SaveChanges();

                            Notify?.Invoke($"Регистратция прошла успешно {FistName}");
                        }
                    }
                    break;

                case "2":
                    {
                        #region Принимаем данные

                        Console.WriteLine("Введите название компание");
                        string? ServiceName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(ServiceName))
                            throw new ArgumentNullException("Названия компание не может быть пустым", nameof(ServiceName));

                        Console.WriteLine("Введите категорию");
                        string? ServiceCategory = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(ServiceCategory))
                            throw new ArgumentNullException("Категория не может быть пустым", nameof(ServiceCategory));

                        Console.WriteLine("Введите номер телефона");
                        string? ServicePhoneNumber_1 = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(ServicePhoneNumber_1))
                            throw new ArgumentNullException("Номер телефона не может быть пустым", nameof(ServicePhoneNumber_1));

                        Console.WriteLine("Введите вебсайт (Если не имеется нажмите Enter)");
                        string? ServiceWebSite = Console.ReadLine();

                        Console.WriteLine("Введите Описанию (Необязательно");
                        string? ServiceMessage = Console.ReadLine();

                        Console.WriteLine("Введите страну");
                        string? ServiceCountry = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(ServiceCountry))
                            throw new ArgumentNullException("Страна не может быть пустым", nameof(ServiceCountry));

                        Console.WriteLine("Введите с какого областя вы");
                        string? ServiceRegion = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(ServiceRegion))
                            throw new ArgumentNullException("Область не может быть пустым", nameof(ServiceRegion));

                        #endregion

                        using (TLContext db = new TLContext())
                        {
                            Service service = new Service
                            {
                                Name = ServiceName!,
                                Category = ServiceCategory!,
                                PhoneNumber_1 = ServicePhoneNumber_1!,
                                Website = ServiceWebSite ?? "Неизвестно",
                                Message = ServiceMessage ?? "Неизвестно",
                                Country = ServiceCountry!,
                                Region = ServiceRegion!,
                                Addrress = ServiceCountry + ", " + ServiceRegion,
                            };
                            db.Service.Add(service);
                            db.SaveChanges();

                            Notify?.Invoke($"Регистратция прошла успешно {ServiceName}");
                        }
                    }
                    break;

                case "3":
                    {
                        #region Принимаем данные

                        Console.WriteLine("Введите Имю");
                        string? CustomerFistName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(CustomerFistName))
                            throw new ArgumentNullException("Имя не может быть пустым", nameof(CustomerFistName));

                        Console.WriteLine("Введите Фамилию");
                        string? CustomerLastName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(CustomerLastName))
                            throw new ArgumentNullException("Фамилия не может быть пустым", nameof(CustomerLastName));

                        Console.WriteLine("Введите номер телефона");
                        string? CustomerPhoneNumber_1 = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(CustomerPhoneNumber_1))
                            throw new ArgumentNullException("Номер телефона не может быть пустым", nameof(CustomerPhoneNumber_1));

                        Console.WriteLine("Введите Email");
                        string? CustomerEmail = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(CustomerEmail))
                            throw new ArgumentNullException("Email не может быть пустым", nameof(CustomerEmail));

                        Console.WriteLine("Введите что ищете");
                        string? CustomerMessage = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(CustomerMessage))
                            throw new ArgumentNullException("Это поля не может быть пустым", nameof(CustomerMessage));

                        Console.WriteLine("Введите страну");
                        string? CustomerCountry = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(CustomerCountry))
                            throw new ArgumentNullException("Страна не может быть пустым", nameof(CustomerCountry));

                        Console.WriteLine("Введите с какого областя вы");
                        string? CustomerRegion = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(CustomerRegion))
                            throw new ArgumentNullException("Регион не может быть пустым", nameof(CustomerRegion));

                        #endregion

                        using (TLContext db = new TLContext())
                        {
                            var customer = new Customer
                            {
                                FirstName = CustomerFistName!,
                                LastName = CustomerLastName!,
                                PhoneNumber_1 = CustomerPhoneNumber_1!,
                                Email = CustomerEmail!,
                                Message = CustomerMessage!,
                                Country = CustomerCountry!,
                                Region = CustomerRegion!,
                                Addrress = CustomerCountry + ", " + CustomerRegion
                            };

                            db.Customer.Add(customer);
                            db.SaveChanges();

                            Notify?.Invoke($"Регистратция прошла успешно {CustomerFistName}");
                        }
                    }
                    break;

                case "4":
                    {
                        #region Принимаем данные
                        Console.WriteLine("Введите модель");
                        var CarModel = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(CarModel))
                            throw new ArgumentNullException("Модель не может быть пустым", nameof(CarModel));

                        Console.WriteLine("Введите номер машины");
                        var CarNumber = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(CarNumber))
                            throw new ArgumentNullException("Номер машины не может быть пустым", nameof(CarNumber));

                        Console.WriteLine("Введите тип");
                        var MType = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(MType))
                            throw new ArgumentNullException("Тип не может быть пустым", nameof(MType));

                        Console.WriteLine("Введите категорию");
                        var CarCategory = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(CarCategory))
                            throw new ArgumentNullException("Категория не может быть пустым", nameof(CarCategory));

                        Console.WriteLine("Введите вес");
                        double GrossWeight = Convert.ToDouble(Console.ReadLine());

                        if (double.IsNegative(GrossWeight))
                            throw new ArgumentNullException("Вес не может быть пустым", nameof(GrossWeight));

                        Console.WriteLine("Введите год выхода в формате \"ДД.ММ.ГГГГ\"");
                        DateTime date = Convert.ToDateTime(Console.ReadLine());

                        if (date < DateTime.Parse("01.01.1950") || date >= DateTime.Now)
                            throw new ArgumentException("Невозможная дате выхода", nameof(date));

                        Console.WriteLine("Введите регион");
                        var CarRegion = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(CarRegion))
                            throw new ArgumentNullException("Регион не может быть пустым", nameof(CarRegion));

                        Console.WriteLine("Если у вас есть аккаунт напишите свой номер телефона (Если нету нажмите Enter)");
                        string? PhoneNumber = Console.ReadLine();

                        #endregion

                        using (TLContext db = new TLContext())
                        {
                            var driver = db.Driver.Where(u => u.PhoneNumber_1 == PhoneNumber).ToList();

                            Truck truck = new Truck
                            {
                                CarModel = CarModel!,
                                CarNumber = CarNumber!,
                                MType = MType!,
                                Category = CarCategory!,
                                GrossWeigh = GrossWeight,
                                Year = date,
                                CurrentRegion = CarRegion!,
                                Address = CarRegion!,

                            };
                            truck.Driver = driver;

                            db.Truck.Add(truck);
                            db.SaveChanges();

                            Notify?.Invoke($"Регистратция прошла успешно");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Введите чимло(1, 2, 3 или 4)");
                    break;
            }
        }
        public static void Read()
        {
            Read read = new Read();
            Console.WriteLine("Что ищете? \n1.Водитель \n2.Компания \n3.Клиент \n4.Truck");
            var answer = Console.ReadLine();

            switch (answer)
            {
                case "1": read.Driver(); break;
                case "2": read.Service(); break;
                case "3": read.Customer(); break;
                case "4": read.Truck(); break;
                default:
                    Console.WriteLine("Введите чимло(1, 2, 3 или 4)");
                    break;
            }
        }
        public static void Delete()
        {
            Delate del = new Delate();

            Console.WriteLine("Кого удалить? \n1.Водитель \n2.Компания \n3.Клиент \n4.Truck");
            var answer = Console.ReadLine();

            switch (answer)
            {
                case "1": del.Driver(); break;
                case "2": del.Service(); break;
                case "3": del.Customer(); break;
                case "4": del.Truck(); break;
                default:
                    Console.WriteLine("Введите чимло(1, 2, 3 или 4)");
                    break;
            }

        }
    }

    /// <summary>
    /// Create Users and Truck
    /// </summary>

    /// <summary>
    /// Search by country
    /// </summary>
    public class Read
    {
        public void Driver()
        {
            Console.WriteLine("С какой страны вам нужен водитель?");
            var country = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(country))
                throw new Exception($"Названия страны не может быть пустым");

            using (TLContext db = new TLContext())
            {
                var drivers = db.Driver.Where(d => d.Address.Contains(country)).ToList();

                foreach (var d in drivers)
                {
                    Console.WriteLine(new string('-', 20));

                    Console.WriteLine
                        (
                        $"\nИмя - {d.FistName}" +
                        $"\nФамилия - {d.LastName}" +
                        $"\nНомер телефона - {d.PhoneNumber_1}" +
                        $"\nEmail - {d.Email}" +
                        $"\nКатегория - {d.Category}" +
                        $"\nАдрес - {d.Address}" +
                        $"\n{d.Truck}"
                        );

                    Console.WriteLine(new string('-', 20));
                }
            }

        }
        public void Service()
        {
            Console.WriteLine("С какой страны должен быть компания?");
            var country = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(country))
                throw new Exception($"Названия страны не может быть пустым");

            using (TLContext db = new TLContext())
            {
                var service = db.Service.Where(s => s.Addrress.Contains(country));
                foreach (var s in service)
                {
                    Console.WriteLine(new string('-', 20));

                    Console.WriteLine
                        (
                        $"\nИмя - {s.Name} " +
                        $"\nКатегория - {s.Category}" +
                        $"\nНомер Телефона - {s.PhoneNumber_1}" +
                        $"\nВебсайт - {s.Website}" +
                        $"\nО компании - {s.Message}" +
                        $"\nАдрес - {s.Addrress}"
                        );

                    Console.WriteLine(new string('-', 20));
                }
            }
        }
        public void Truck()
        {
            Console.WriteLine("С какого региона должен быть Truck");
            var region = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(region))
                throw new ArgumentNullException("Названия региона не может быть пустым");

            using (TLContext db = new TLContext())
            {
                var truck = db.Truck.Where(t => t.CurrentRegion.Contains(region!));
                foreach (var t in truck)
                {
                    Console.WriteLine(new string('-', 20));

                    Console.WriteLine
                        (
                        $"\nМодель - {t.CarModel}" +
                        $"\nНомер - {t.CarNumber}" +
                        $"\nТип - {t.MType}" +
                        $"\nКатегория - {t.Category}" +
                        $"\nВес - {t.GrossWeigh}" +
                        $"\nГод - {t.Year}" +
                        $"\nАдрес - {t.Address}" +
                        $"\n{t.Driver}"
                        );

                    Console.WriteLine(new string('-', 20));
                }
            }
        }
        public void Customer()
        {
            Console.WriteLine("С какого региона должен быть клиент");
            var country = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(country))
                Console.WriteLine("Регион не может быть пустым");

            using (TLContext db = new TLContext())
            {
                var customers = db.Customer.Where(c => c.Addrress!.Contains(country!));
                foreach (var c in customers)
                {
                    Console.WriteLine(new string('-', 20));

                    Console.WriteLine
                        (
                        $"Имя - {c.FirstName}" +
                        $"\nФамилия - {c.LastName}" +
                        $"\nНомер телефона - {c.PhoneNumber_1}" +
                        $"\nEmail - {c.Email}" +
                        $"\nОписяния - {c.Message}" +
                        $"\nAдрес - {c.Addrress}"
                        );

                    Console.WriteLine(new String('-', 20));
                }
            }
        }
    }

    /// <summary>
    /// Delete by phone number or car number
    /// </summary>
    public class Delate
    {
        public void Driver()
        {
            Console.WriteLine("Введите номер телефона");
            var phone = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentNullException("Номер телефона не может быть пустым");

            using (TLContext db = new TLContext())
            {
                var driver = db.Driver.Where(d => d.PhoneNumber_1 == phone).FirstOrDefault();

                db.Driver.Remove(driver!);
                db.SaveChanges();
                Console.WriteLine("Дыннае успешно удалены");
            }
        }
        public void Service()
        {
            Console.WriteLine("Введите номер телефона");
            var phone = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentNullException("Номер телефона не может быть пустым");

            using (TLContext db = new TLContext())
            {
                var service = db.Service.Where(d => d.PhoneNumber_1 == phone).FirstOrDefault();

                db.Service.Remove(service!);
                db.SaveChanges();
                Console.WriteLine("Дыннае успешно удалены");
            }
        }
        public void Truck()
        {
            Console.WriteLine("Введите номер машины");
            var carNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(carNumber))
                throw new ArgumentNullException("Номер машины не может быть пустым");

            using (TLContext db = new TLContext())
            {
                var truck = db.Truck.Where(d => d.CarNumber == carNumber).FirstOrDefault();

                db.Truck.Remove(truck!);
                db.SaveChanges();
                Console.WriteLine("Дыннае успешно удалены");
            }
        }
        public void Customer()
        {
            Console.WriteLine("Введите номер телефона");
            var phone = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentNullException("Номер телефона не может быть пустым");

            using (TLContext db = new TLContext())
            {
                var customer = db.Customer.Where(d => d.PhoneNumber_1 == phone).FirstOrDefault();

                db.Customer.Remove(customer!);
                db.SaveChanges();
                Console.WriteLine("Дыннае успешно удалены");
            }
        }

    }
}
