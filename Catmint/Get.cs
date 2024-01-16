using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catmint
{
    static class Get
    {
        public static int Value { get; set; }//для передачи айди из войти в аккаунт, для Edit
        public static int forLogIn { get; set; }//входит (ToLoginCheck)
        public static int LoggedIn { get; set; }//вошел (Details)
        public static int Privelege { get; set; }//admin или обычный юзер (UsersController ToLoginCheck)
        public static int ID { get; set; }//для user_id

        public static int ifChosen { get; set; }//для Reserv

        
        public static int table_num { get; set; }//для Create Book
        public static DateTime ForBookTime { get; set; }//для Reserv
        public static DateTime BookTime { get; set; }//для Create Book

        public static int ToLetBook { get; set; }//для перенаправления после регистрации/логина на Book
        public static int ToLetCat { get; set; }//для перенаправления после регистрации/логина на Cats
        public static int ToLetComment { get; set; }//для перенаправления после регистрации/логина на Mainpage
    }
}
