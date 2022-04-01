
namespace TransportLogistika.BL
{
    /// <summary>
    ///  Class for working with the database
    /// </summary>
    public class WorkWithTLDB
    {
        /// <summary>
        /// Choose what to do
        /// </summary>
        public static void GMethod()
        {
            Console.WriteLine("\n1.Создать \n2.Поиск \n3.Изменить \n4.Удалить");

            switch (Console.ReadLine())
            {
                case "1": Create(); break;
                case "2": Read(); break;
                case "3": Update(); break;
                case "4": Delete(); break;
            }

        }

        // Navigation Methods
        public static void Create()
        {
            Create create = new Create();
            Console.WriteLine("Кем вы являетесь? \n1.Водитель \n2.Компания \n3.Клиент \n4.Truck");
            var answer = Console.ReadLine();

            switch (answer)
            {
                case "1": create.Driver(); break;
                case "2": create.Service(); break;
                case "3": create.Customer(); break;
                case "4": create.Truck(); break;
                default:
                    Console.WriteLine("Введите чимло(1, 2 или 3)");
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
                    Console.WriteLine("Введите чимло(1, 2 или 3)");
                    break;
            }
        }
        public static void Update()
        {
            throw new ArgumentNullException("Изменить не работаеть", nameof(Update));
        }
        public static void Delete()
        {
            throw new ArgumentNullException("Удалить не работаеть", nameof(Delete));
        }
    }

    /// <summary>
    /// Create Users and Truck
    /// </summary>
    public class Create
    {
        public void Driver()
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

                Console.WriteLine("Регистратция прошла успешно.");
            }
        }

        public void Service()
        {
            #region Принимаем данные

            Console.WriteLine("Введите название компание");
            var Name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentNullException("Названия компание не может быть пустым", nameof(Name));

            Console.WriteLine("Введите категорию");
            var Category = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Category))
                throw new ArgumentNullException("Категория не может быть пустым", nameof(Category));

            Console.WriteLine("Введите номер телефона");
            var PhoneNumber_1 = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(PhoneNumber_1))
                throw new ArgumentNullException("Номер телефона не может быть пустым", nameof(PhoneNumber_1));

            Console.WriteLine("Введите вебсайт(Если не имеется нажмите Enter)");
            var WebSite = Console.ReadLine();

            Console.WriteLine("Введите Описанию");
            var Message = Console.ReadLine();

            Console.WriteLine("Введите страну");
            var Country = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Country))
                throw new ArgumentNullException("Страна не может быть пустым", nameof(Country));

            Console.WriteLine("Введите с какого областя вы");
            var Region = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Region))
                throw new ArgumentNullException("Область не может быть пустым", nameof(Region));

            #endregion

            using (TLContext db = new TLContext())
            {
                Service service = new Service
                {
                    Name = Name!,
                    Category = Category!,
                    PhoneNumber_1 = PhoneNumber_1!,
                    Website = WebSite!,
                    Message = Message!,
                    Country = Country!,
                    Region = Region!,
                    Addrress = Country + ", " + Region,
                };
                db.Service.Add(service);
                db.SaveChanges();

                Console.WriteLine("Регистратция прошла успешно.");
            }
        }

        public void Truck()
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
                Console.WriteLine("Регистратция прошла успешно.");
            }

        }

        public void Customer()
        {
            #region Принимаем данные

            Console.WriteLine("Введите Имю");
            var FistName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(FistName))
                throw new ArgumentNullException("Имя не может быть пустым", nameof(FistName));

            Console.WriteLine("Введите Фамилию");
            var LastName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentNullException("Фамилия не может быть пустым", nameof(LastName));

            Console.WriteLine("Введите номер телефона");
            var PhoneNumber_1 = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(PhoneNumber_1))
                throw new ArgumentNullException("Номер телефона не может быть пустым", nameof(PhoneNumber_1));

            Console.WriteLine("Введите Email");
            var Email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Email))
                throw new ArgumentNullException("Email не может быть пустым", nameof(Email));

            Console.WriteLine("Введите что ищете");
            var Message = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Message))
                throw new ArgumentNullException("Это поля не может быть пустым", nameof(Message));

            Console.WriteLine("Введите страну");
            var Country = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Country))
                throw new ArgumentNullException("Страна не может быть пустым", nameof(Country));

            Console.WriteLine("Введите с какого областя вы");
            var Region = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(Region))
                throw new ArgumentNullException("Регион не может быть пустым", nameof(Region));

            #endregion

            using (TLContext db = new TLContext())
            {
                var customer = new Customer
                {
                    FirstName = FistName!,
                    LastName = LastName!,
                    PhoneNumber_1 = PhoneNumber_1!,
                    Email = Email!,
                    Message = Message!,
                    Country = Country!,
                    Region = Region!,
                    Addrress = Country + ", " + Region
                };

                db.Customer.Add(customer);
                db.SaveChanges();

                Console.WriteLine("Регистратция прошла успешно.");
            }
        }
    }


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


    public class Update
    {
        public void UpdateDriver() { }
        public void UpdateService() { }
        public void UpdateTruck() { }
        public void UpdateCustomer() { }
    }

    public class Delate
    {
        public void DelateUser() { }
        public void DelateDriver() { }
        public void DeleteService() { }
        public void DeleteTrukc() { }
        public void DeleteCustomer() { }

    }
}
