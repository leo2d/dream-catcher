using DreamCatcher.Domain.UserAgg;
using System.Web;

namespace DreamCatcher.Domain.SharedKernel.Helpers
{
    public class SessionHelper
    {
        private const string userKey = "User";
        //public User User
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["User"] != null)
        //        {
        //            return (User)HttpContext.Current.Session["User"];
        //        }

        //        return null;
        //    }
        //}

        public static void Setuser(User user)
        {
            HttpContext.Current.Session[userKey] = user;
        }

        public static User Getuser()
        {

            return (null != HttpContext.Current.Session[userKey]) 
                ? (User)HttpContext.Current.Session[userKey] 
                : null;

        }

        public static bool UserLogged()
        {
            return null != HttpContext.Current.Session[userKey];
        }

        public static void RemoveUser()
        {
            HttpContext.Current.Session[userKey] = null;
            HttpContext.Current.Session.Remove(userKey);
        }


    }
}
