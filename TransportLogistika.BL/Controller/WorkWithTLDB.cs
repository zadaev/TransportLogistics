using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TransportLogistika.BL
{
    /// <summary>
    ///  Class for working with the database
    /// </summary>
    public class WorkWithTLDB
    {

    }
    public class Create
    {
        public static void CreateUser()
        {
            Console.WriteLine("Кем вы являетесь? \n1.Водитель \n2.Компания \n3.Клиент \n4.Truck");
            var answer = Console.ReadLine();

            switch (answer)
            {
                case "1": Driver(); break;
                case "2": Service(); break;
                case "3": Customer(); break;
                case "4": Truck(); break;
                default:
                    Console.WriteLine("Введите чимло(1, 2 или 3)");
                    break;
            }
        }

        public static void Driver()
        {
            #region Принимаем данные

            Console.WriteLine("Вас приветствует приложение TransportLogistics");
            Console.WriteLine("Введите логин пользователя");
            var login = Console.ReadLine();

            Console.WriteLine("Введите пароль пользователя.");
            var password = Console.ReadLine();

            Console.WriteLine("Введите Имю");
            var FistName = Console.ReadLine();

            Console.WriteLine("Введите Фамилию");
            var LastName = Console.ReadLine();

            Console.WriteLine("Введите номер телефона");
            var PhoneNumber_1 = Console.ReadLine();

            Console.WriteLine("Введите Email");
            var Email = Console.ReadLine();

            Console.WriteLine("Введите категорию");
            var Category = Console.ReadLine();

            Console.WriteLine("Введите страну");
            var Country = Console.ReadLine();

            Console.WriteLine("Введите с какого областя вы");
            var Region = Console.ReadLine();

            Console.WriteLine("Если вы добавили машину закрепите его в свой аккаунт \nдля этого отправьте номер машины(Если не добавляли нажмите Enter)");
            string? numberCar = Console.ReadLine();
            #endregion

            using (TLContext db = new TLContext())
            {
                var truck = db.Truck.Where(t => t.CarNumber == numberCar).ToList();
                var user = new User { Login = login!, Password = password! };
                var driver = new Driver
                {
                    FistName = FistName!,
                    LastName = LastName!,
                    PhoneNumber_1 = PhoneNumber_1!,
                    Email = Email!,
                    Category = Category!,
                    Country = Country!,
                    Region = Region!,
                    Address = Country + " " + Region,
                    User = user,
                    Truck = truck
                };
                db.Driver.Add(driver);

                db.SaveChanges();

                Console.WriteLine("Регистратция прошла успешно.");
            }
        }

        public static void Service()
        {
            #region Принимаем данные

            Console.WriteLine("Вас приветствует приложение TransportLogistics");
            Console.WriteLine("Введите логин пользователя");
            var login = Console.ReadLine();

            Console.WriteLine("Введите пароль пользователя.");
            var password = Console.ReadLine();

            Console.WriteLine("Введите название компании");
            var Name = Console.ReadLine();

            Console.WriteLine("Введите категорию");
            var Category = Console.ReadLine();

            Console.WriteLine("Введите номер телефона");
            var PhoneNumber_1 = Console.ReadLine();

            Console.WriteLine("Введите вебсайт(Если не имеется нажмите Enter)");
            var WebSite = Console.ReadLine();

            Console.WriteLine("Введите цену за час");
            var HourPay = Console.ReadLine();

            Console.WriteLine("Введите Описанию");
            var Message = Console.ReadLine();

            Console.WriteLine("Введите страну");
            var Country = Console.ReadLine();

            Console.WriteLine("Введите с какого областя вы");
            var Region = Console.ReadLine();

            #endregion

            using (TLContext db = new TLContext())
            {
                var user = new User { Login = login!, Password = password! };
                Service service = new Service
                {
                    Name = Name!,
                    Category = Category!,
                    PhoneNumber_1 = PhoneNumber_1!,
                    Website = WebSite!,
                    HourPay = HourPay!,
                    Message = Message!,
                    Country = Country!,
                    Region = Region!,

                    User = user
                };
                db.Service.Add(service);
                db.SaveChanges();

                Console.WriteLine("Регистратция прошла успешно.");
            }
        }

        public static void Truck()
        {
            #region Принимаем данные
            Console.WriteLine("Введите модель");
            var CarModel = Console.ReadLine();

            Console.WriteLine("Введите номер ");
            var CarNumber = Console.ReadLine();

            Console.WriteLine("Введите тип");
            var MType = Console.ReadLine();

            Console.WriteLine("Введите категорию");
            var CarCategory = Console.ReadLine();

            Console.WriteLine("Введите вес");
            var GrossWeight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите год выхода");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Введите регион");
            var CarRegion = Console.ReadLine();

            #endregion

            using (TLContext db = new TLContext())
            {
                Truck truck = new Truck
                {
                    CarModel = CarModel!,
                    CarNumber = CarNumber!,
                    MType = MType!,
                    Category = CarCategory!,
                    GrossWeigh = GrossWeight,
                    Year = date,
                    CurrentRegion = CarRegion!,
                    Address = CarRegion!
                };
                db.Truck.Add(truck);
                db.SaveChanges();
                Console.WriteLine("Регистратция прошла успешно.");
            }

        }

        public static void Customer()
        {
            #region Принимаем данные

            Console.WriteLine("Вас приветствует приложение TransportLogistics");
            Console.WriteLine("Введите логин пользователя");
            var login = Console.ReadLine();

            Console.WriteLine("Введите пароль пользователя.");
            var password = Console.ReadLine();

            Console.WriteLine("Введите Имю");
            var FistName = Console.ReadLine();

            Console.WriteLine("Введите Фамилию");
            var LastName = Console.ReadLine();

            Console.WriteLine("Введите номер телефона");
            var PhoneNumber_1 = Console.ReadLine();

            Console.WriteLine("Введите Email");
            var Email = Console.ReadLine();

            Console.WriteLine("Введите что хотели");
            var Message = Console.ReadLine();

            Console.WriteLine("Введите страну");
            var Country = Console.ReadLine();

            Console.WriteLine("Введите с какого областя вы");
            var Region = Console.ReadLine();

            #endregion

            using (TLContext db = new TLContext())
            {
                Customer customer = new Customer
                {
                    FirstName = FistName!,
                    LastName = LastName!,
                    PhoneNumber_1 = PhoneNumber_1!,
                    Email = Email!,
                    Message = Message!,
                    Country = Country!,
                    Region = Region!
                };
                db.Customer.Add(customer);
                db.SaveChanges();

                Console.WriteLine("Регистратция прошла успешно.");
            }
        }
    }
    public class Read
    {
        public static void UserRead()
        {
            Console.WriteLine("Что ищете? \n1.Водитель \n2.Компания \n3.Клиент \n4.Truck");
            var answer = Console.ReadLine();

            switch (answer)
            {
                case "1": Driver(); break;
                case "2": Service(); break;
                case "3": Customer(); break;
                case "4": Truck(); break;
                default:
                    Console.WriteLine("Введите чимло(1, 2 или 3)");
                    break;
            }
        }
        public static void Driver()
        {
            Console.WriteLine("С какой страны вам нужен водитель?");
            var country = Console.ReadLine();

            using (TLContext db = new TLContext())
            {
                var drivers = db.Driver.Where(d => d.Address.Contains(country!));
                foreach (var d in drivers)
                {
                    Console.WriteLine
                        (
                        $"Имя - {d.FistName}" +
                        $"\nФамилия - {d.LastName}" +
                        $"\nНомер телефона - {d.PhoneNumber_1}" +
                        $"\nEmail - {d.Email}" +
                        $"\nКатегория - {d.Category}" +
                        $"\nАдрес - {d.Address}"
                        );

                    Console.WriteLine(new string('-', 20));
                }
            }
        }
        public static void Service()
        {
            Console.WriteLine("С какой страны должен быть компания?");
            var country = Console.ReadLine();

            using (TLContext db = new TLContext())
            {
                var Service = db.Service.Where(s => s.Addrress!.Contains(country!));
                foreach (var s in Service)
                {
                    Console.WriteLine
                        ($"Имя - {s.Name} " +
                        $"\nКатегория - {s.Category}" +
                        $"\nНомер Телефона - {s.PhoneNumber_1}" +
                        $"\nВебсайт - {s.Website}" +
                        $"\nЦена за час - {s.HourPay}" +
                        $"\nО компании - {s.Message}" +
                        $"\nАдрес - {s.Addrress}");

                    Console.WriteLine(new string('-', 20));
                }
            }
        }
        public static void Truck()
        {
            Console.WriteLine("С какого региона должен быть Truck");
            var region = Console.ReadLine();

            using (TLContext db = new TLContext())
            {
                var truck = db.Truck.Where(t => t.CurrentRegion.Contains(region!));
                foreach (var t in truck)
                {
                    Console.WriteLine
                        (
                        $"Модель - {t.CarModel}" +
                        $"\nНомер - {t.CarNumber}" +
                        $"\nТип - {t.MType}" +
                        $"\nКатегория - {t.Category}" +
                        $"\nВес - {t.GrossWeigh}" +
                        $"\nГод - {t.Year}" +
                        $"\nАдрес - {t.Address}"
                        );
                    Console.WriteLine(new string('-', 20));
                }
            }
        }
        public static void Customer()
        {
            Console.WriteLine("С какого региона должен быть клиент");
            var country = Console.ReadLine();

            using (TLContext db = new TLContext())
            {
                var customers = db.Customer.Where(c => c.Country.Contains(country!));
                foreach (var c in customers)
                {
                    Console.WriteLine
                        (
                        $"Имя - {c.FirstName}" +
                        $"Фамилия - {c.LastName}" +
                        $"Номер телефона - {c.PhoneNumber_1}" +
                        $"Email - {c.Email}" +
                        $"Описяния - {c.Message}" +
                        $"Aдрес - {c.Addrress}"
                        );

                    Console.WriteLine(new String('-', 20));
                }
            }
        }
    }
    public class Update
    {
        public void NavigationMethod()
        {

        }
        public void UpdateUser()
        {
            Console.WriteLine("Введите свой логин");
            var login = Console.ReadLine();

            Console.WriteLine("Введите свой пароль");
            var password = Console.ReadLine();

            using (TLContext db = new TLContext())
            {
                var user = db.User.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
                if (user != null)
                {

                    Console.WriteLine("Введите новый логин");
                    var newlogin = Console.ReadLine();

                    db.User.Remove(user.Result!);

                    Console.WriteLine("Введите новый пароль");
                    var newpassword = Console.ReadLine();

                }
                Console.WriteLine();

            }
        }
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
