using API.Services;

namespace Test.Services {
	[TestClass]	
	public class CarServicesTest {
		protected dynamic concessionaria = new ConcessionariaManager();

		[TestInitialize]
		public void Init()
		{
		    CleanVehicles();
		}

		public void CleanVehicles() {
			var vehicles = concessionaria.GetVehicles();

			for (int i = vehicles.Count - 1; i >= 0; i--)
			{
			    concessionaria.DeleteVehicle(i);
			}
		}

		[TestMethod]
		public void TestCreateVehicle() {
			concessionaria.CreateVehicle("Car", "Fiat", "Uno", 2000);

			var vehicles = concessionaria.GetVehicles();

			Assert.IsTrue(vehicles.Count == 1);
		}

		[TestMethod]
		public void TestGetVehicle() {			
			concessionaria.CreateVehicle("Car", "Fiat", "Uno", 2000);

			var vehicle = concessionaria.GetVehicle(0);

			Assert.AreEqual("Car", vehicle.GetVehicleType());
			Assert.AreNotEqual("Chevrolet", vehicle.GetMark());
			Assert.AreEqual("Uno", vehicle.GetModel());
			Assert.AreNotEqual(1990, vehicle.GetYear());
		}

		[TestMethod]
		public void TestGetAllVehicles() {			
			concessionaria.CreateVehicle("Car", "Fiat", "Uno", 2000);

			var vehicles = concessionaria.GetVehicles();

			Assert.IsTrue(vehicles.Count > 0);
		}

		[TestMethod]
		public void TestUpdateVehicle() {			
			concessionaria.CreateVehicle("Car", "Fiat", "Uno", 2000);

			var vehicle = concessionaria.UpdateVehicle(0, "Car", "Chevrolet", "Chevet", 1990);

			Assert.AreEqual("Car", vehicle.GetVehicleType());
			Assert.AreNotEqual("Fiat", vehicle.GetMark());
			Assert.AreEqual("Chevet", vehicle.GetModel());
			Assert.AreNotEqual(2000, vehicle.GetYear());
		}

		[TestMethod]
		public void TestPartialUpdateVehicle() {			
			concessionaria.CreateVehicle("Car", "Fiat", "Uno", 2000);

			var vehicle = concessionaria.UpdateVehicle(0, "", "Chevrolet", null, 1990);

			Assert.AreNotEqual("", vehicle.GetVehicleType());
			Assert.AreEqual("Chevrolet", vehicle.GetMark());
			Assert.AreNotEqual("", vehicle.GetModel());
			Assert.AreEqual(1990, vehicle.GetYear());
		}

		[TestMethod]
		public void TestDeleteVehicle() {			
			concessionaria.CreateVehicle("Car", "Fiat", "Uno", 2000);			

			Assert.IsTrue(concessionaria.DeleteVehicle(0));
		}
	}
}