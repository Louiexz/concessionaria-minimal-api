namespace Model {
    public class User {
        protected int id;
        protected string email;
        protected string password;

        public User(int id, string email, string password)
        {
            this.id = id;
            this.email = email;
            this.password = password;
        }

        public int GetId() { return id; }
        public string GetEmail() { return email; }
        public string GetPassword() { return password; }

        public void SetEmail(string email) { this.email = email; }
        public void SetPassword(string password) { this.password = password; }
    }
}
