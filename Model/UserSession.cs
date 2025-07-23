namespace Model {
    public class UserSession
    {
        public bool IsLogged { get; set; } = false;
        protected int UserId { get; set; } = -1;
    }
}