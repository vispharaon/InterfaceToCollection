using InterfaceToCollection.Model;
using System.Collections.Generic;

namespace InterfaceToCollection.TestData
{
    public class UserTestData
    {
        public static List<Users> UsersData()
        {
            return new List<Users>(){
                new Users{
                    Id = 1,
                    Username = "male",
                    Password = "male"
                },
                new Users
                {
                    Id = 2,
                    Username = "female",
                    Password = "female"
                }
            };
        }        
    }
}
