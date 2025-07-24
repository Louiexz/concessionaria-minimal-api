using System;
using System.Collections.Generic;
using API.Model;

namespace API.Services {
    public class UserManager {
        public UserManager() {}

        private static List<User> users = new List<User>();

        public List<User> GetUsers() {
            return users;
        }

        public User GetUser(int id) {
            return users.Find(user => user.GetId() == id);
        }

        public bool Login(string email, string password) {
            if (users.Find(user => user.GetEmail() == email) != null
                && users.Find(user => user.GetPassword() == password) != null) return true;
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