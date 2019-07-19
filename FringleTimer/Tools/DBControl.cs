using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimerCode.Code;

namespace FringleTimer.Model.DB
{
    // THERE IS NO NEED FOR THAT ANYMORE 
    //static class DBControl
    //{
    //    public static (User, bool) GetUser(String username, String password)
    //    {
    //        String connectionstring = App.MySqlConStr;
            
    //        // empty user
    //        // used internalsvisibleto attribute
    //        User user = new User();
    //        // getting connection and getting reader out of the query
    //        using (var connection = new MySqlConnection(connectionstring))
    //        {
    //            // here goes query
    //            var command = new MySqlCommand($"CALL GetUser('{username}', '{password}', '{GetLocalIPAddress()}');", connection);
    //            connection.Open();
    //            var reader = command.ExecuteReader();
    //            int read = 0;
    //            // reading properties one by one
    //            while (reader.Read())
    //            {
                    
    //                read++;
    //                user.id = reader.GetInt32(0);
    //                user.Username = reader.GetString(1);
    //                user.Password = reader.GetString(2).ToSecureString();
    //                user.name = reader.GetString(3);
    //                user.lname = reader.GetString(4);
    //            }
    //            if (read == 0)
    //            {
    //                return (null, false);
    //            }
    //            // last user in the database query is returned
    //        }
    //        return (user, true);
    //    }
    //    public static async Task<(User, bool)> GetUserAsync(String username, String password)
    //    {
    //        String connectionstring = App.MySqlConStr;

    //        // empty user
    //        // used internalsvisibleto attribute
    //        User user = new User();
    //        // getting connection and getting reader out of the query
    //        using (var connection = new MySqlConnection(connectionstring))
    //        {
    //            // here goes query
    //            var command = new MySqlCommand($"CALL GetUser('{username}', '{password}', '{GetLocalIPAddress()}');", connection);
    //            connection.Open();
    //            return await Task.Run<(User,bool)>(() =>
    //            {
    //                var reader = command.ExecuteReader();
    //                int read = 0;
    //                // reading properties one by one
    //                while (reader.Read())
    //                {

    //                    read++;
    //                    user.id = reader.GetInt32(0);
    //                    user.Username = reader.GetString(1);
    //                    user.Password = reader.GetString(2).ToSecureString();
    //                    user.name = reader.GetString(3);
    //                    user.lname = reader.GetString(4);
    //                }
    //                if (read == 0)
    //                {
    //                    return (null, false);
    //                }
    //                return (user, true);
    //            });
    //            // last user in the database query is returned
    //        }
            
    //    }
    //    public static Boolean CheckExistance(String username)
    //    {
    //        String connectionstring = App.MySqlConStr;

    //        // empty user
    //        // used internalsvisibleto attribute
    //        User user = new User();
    //        // getting connection and getting reader out of the query
    //        using (var connection = new MySqlConnection(connectionstring))
    //        {
    //            // here goes query
    //            var command = new MySqlCommand($"CALL CheckExistance('{username}');", connection);
    //            connection.Open();
    //            var reader = command.ExecuteReader();
    //            int read = 0;
    //            // reading properties one by one
    //            while (reader.Read())
    //            {

    //                read++;


    //                if (!reader.IsDBNull(0) && reader.GetInt32(0) != 0)
    //                {
    //                    return true;
    //                }
    //                else return false;
                    
                  
    //            }
    //            if (read == 0) return false;
    //            // last user in the database query is returned
    //        }
    //        return false;
    //    }
    //    public static async Task<Boolean> CheckExistanceAsync(String username)
    //    {
    //        String connectionstring = App.MySqlConStr;

    //        // empty user
    //        // used internalsvisibleto attribute
    //        User user = new User();
    //        // getting connection and getting reader out of the query
    //        return await Task.Run<bool>(()=>
    //        {
    //            using (var connection = new MySqlConnection(connectionstring))
    //            {
    //                // here goes query
    //                var command = new MySqlCommand($"CALL CheckExistance('{username}');", connection);
    //                connection.Open();
    //                var reader = command.ExecuteReader();
    //                int read = 0;
    //                // reading properties one by one
    //                while (reader.Read())
    //                {

    //                    read++;


    //                    if (!reader.IsDBNull(0) && reader.GetInt32(0) != 0)
    //                    {
    //                        return true;
    //                    }
    //                    else return false;


    //                }
    //                if (read == 0) return false;
    //                // last user in the database query is returned
    //            }
    //            return false;
    //        });
    //    }
    //    public static Boolean InsertSolved(Time solved)
    //    {

    //        String connectionstring = App.MySqlConStr;


    //        // creating connection and invoking func
    //        // returns true because of successful operation
    //        using (var connection = new MySqlConnection(connectionstring))
    //        {
                
    //                // here goes query

    //                //var command = new MySqlCommand($"CALL InsertSolved({solved.UserSolved.id <---- mistake}, " +
    //                //    $"'{solved.scramble.ToString(true)}', " +
    //                //    $"'{solved.ToString()}', '{solved.SOT}');", connection);

    //                connection.Open();
    //                //command.ExecuteNonQuery();
    //                return true;

    //            }
                

            

    //        // leaves the exeption to the next stack to handle


    //    }
    //    public static Boolean NewUser(User user)
    //    {
            
    //            String connectionstring = App.MySqlConStr;

    //            if (!users_already(user))
    //            {
    //                // creating connection and invoking func
    //                // returns true because of successful operation
    //                using (var connection = new MySqlConnection(connectionstring))
    //                {
    //                    // here goes query
    //                    var command = new MySqlCommand($"CALL NewUser( " +
    //                        $"'{user.Username}', " +
    //                        $"'{user.Password.SecureStringToPassword()}', '{user.name}', '{user.lname}');", connection);
    //                    connection.Open();
    //                    command.ExecuteNonQuery();
    //                    return true;
    //                }
    //            }
    //            else return false;
          
        

           
    //    }
    //    private static Boolean users_already(User user)
    //    {
            
    //            var v = GetUser(user.Username, user.Password.SecureStringToPassword());
    //            return v.Item2; // if tuple has true, this means that we got out of the db a user value
    //            // if false then we can create a user
            
            
    //    }
    //    ///<summary
    //    // Gets all the times out of DB solved by the current user
    //    ///</summary>
    //    public static IList<Time> GetSolved(this User user)
    //    {
            
    //            String connectionstring = App.MySqlConStr;
    //            List<Time> solved = new List<Time>();
    //            using (var connection = new MySqlConnection(connectionstring))
    //            {
    //                // here goes query
    //                var command = new MySqlCommand($"CALL GetSolved({user.id});", connection);
    //                connection.Open();
    //                using (var reader = command.ExecuteReader())
    //                {
    //                    while (reader.Read())
    //                    {
    //                        String s_scramble = reader.GetString(2); // getting scramble out of db
    //                        String time_solved = reader.GetString(3); // getting time
    //                        var scramble = s_scramble.ToScramble(); // parsing it to TimerCode.Code.Scramble
    //                        Time time = time_solved.ToTime(scramble, user);
    //                        solved.Add(time);
    //                    }
    //                }
    //            }
    //            return solved;
            
    //    }
        
    //    private static string GetLocalIPAddress()
    //    {
    //        var host = Dns.GetHostEntry(Dns.GetHostName());
    //        foreach (var ip in host.AddressList)
    //        {
    //            if (ip.AddressFamily == AddressFamily.InterNetwork)
    //            {
    //                return ip.ToString();
    //            }
    //        }
    //        throw new Exception("No network adapters with an IPv4 address in the system!");
    //    }
    //    // TODO: CREATE METHOD 'CHANGESOLVED' WHERE WE CAN CHANGE A ROW IDENTIFIYING IT WITH A SCRAMBLE, TIME,
    //    // SOT AND SO FORTH
    //}  

    //// USED TO SHARE SOLVED TIMES IN HISTORY WITH THE DB
    //    public class SolvedSyncronizer
    //{
    //    Int32 serialized_in_times = 0;

    //    public SolvedSyncronizer(int serialized_in_times)
    //    {
    //        this.serialized_in_times = serialized_in_times;
    //    }

    //    public async Task Serialize()
    //    {
    //        for (int i = Volatile.Read(ref serialized_in_times); i < Time.History.Count; i++)
    //        {
    //            await Time.History[i].SendToDBAsync();
    //        }
    //        Volatile.Write(ref serialized_in_times, Time.History.Count()); 
    //    }
    //} 
}
