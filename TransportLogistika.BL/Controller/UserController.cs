 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TransportLogistika.BL
{
    /*
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        public User User { get; set; }

        public UserController(string userLogin,string userPassword)
        {
            // TODO: Проверка

            var user = new User(userLogin,userPassword);
            this.User = user ?? throw new ArgumentNullException("Ползователь не может быть равен Null", nameof(user));
        }

         XmlSerializer serializer = new XmlSerializer(typeof(User));

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            using (var fs = new FileStream("users.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Почучить данные пользовотеля.
        /// </summary>
        public UserController ()
        {
            using (var fs = new FileStream("users.xml", FileMode.OpenOrCreate))
            {

                User = serializer.Deserialize(fs) as User ?? throw new ArgumentNullException("Ползователя нету",nameof(User));
            }
        }
    }
    */

}
