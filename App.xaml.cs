using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Register.Model;
using Register.Wpf;

namespace Register
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static StoreDB storeDB = new StoreDB();
        public static StoreDB StoreDB { get { return storeDB; } }

        private static Moves moves = new Moves();
        public static Moves Moves { get { return moves; } }

        private static Answers answers = new Answers();
        public static Answers Answers { get { return answers; } }

        internal static Messenger Messenger
        {
           get { return _messenger; }
        }
        readonly static Messenger _messenger = new Messenger();

        public static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    }
}
