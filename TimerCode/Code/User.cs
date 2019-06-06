
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TimerCode.Code
{
    [Serializable]
    public class User
    {
        internal User()
        {
 
        } // empty user pattern

        public User(int id,String username ,SecureString password,string name, string lname)
        {
            this.id = id;
            this.Username = username ?? throw new ArgumentNullException(nameof(username));
            this.Password = password ?? throw new ArgumentNullException(nameof(password));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.lname = lname ?? throw new ArgumentNullException(nameof(lname));
        }
        //private SecureString fill_password(string password)
        //{
        //    unsafe
        //    {


        //        try
        //        {

        //            var ptr = Marshal.StringToBSTR(password);
        //            return new SecureString((Char*)ptr, password.Length);
        //        }
        //        finally
        //        {

        //        }
        //}

        //}
        public Int32 id { get; set; }

        public String name { get; set; }
        public String lname { get; set; }
        
        public String Username { get; set; }
        [NonSerialized]
        public SecureString Password;
    }
}
