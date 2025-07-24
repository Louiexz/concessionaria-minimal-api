namespace API.Model {
    public class Vehicle {
        protected int id;
        protected string type;
        protected string mark;
        protected string model;
        protected int year;

        public Vehicle() {}

        public Vehicle(int id, string type, string mark, string model, int year) {
            this.id = id;
            this.type = type;
            this.mark = mark;
            this.model = model;
            this.year = year;
        }

        public int GetId() { return this.id; }
        public string GetVehicleType() { return this.type; }
        public string GetMark() { return mark; }
        public string GetModel() { return model; }
        public int GetYear() { return year; }

        public void SetVehicleType(string type) { this.type = type; }
        public void SetMark(string mark) { this.mark = mark; }
        public void SetModel(string model) { this.model = model; }
        public void SetYear(int year) { this.year = year; }
    } 
}
