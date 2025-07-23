using System;
using System.Collections.Generic;
using Model;

namespace Services {
    public class UserManager {
        public UserManager() {}

        private static List<User> users = new List<User>();

        public List<User> GetUsers() {
            return users;
        }

        public User GetUser(int id) {
            return users[id];
        }

        public bool Login(string email, string password) {
            foreach (var user in users) {
                if(user.GetEmail()  == email & user.GetPassword() == password) {
                    return true;
                }
            }
            return false;
        }

        public User UpdateUser(int id, string? email, string? password) {
            var user = this.GetUser(id);

            user.SetEmail(string.IsNullOrWhiteSpace(email) ? user.GetEmail() : email);
            user.SetPassword(string.IsNullOrWhiteSpace(password) ? user.GetPassword() : password);

            users[id] = user;

            return user;
        }

        public void CreateUser(string email, string password) {
            users.Add(new User(users.Count, email, password));
        }

        public void DeleteUser(int id){
            users.RemoveAt(id);
        }
    }
}