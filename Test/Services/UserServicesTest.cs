using API.Services;

namespace Test.Services {	
	[TestClass]
	public class UserServicesTest {
		protected dynamic manager = new UserManager();

		[TestInitialize]
		public void Init()
		{
		    CleanUsers();
		}


		public void CleanUsers() {
			var listUsers = manager.GetUsers();

			for (int i = listUsers.Count - 1; i >= 0; i--)
			{
			    manager.DeleteUser(i);
			}
		}

		[TestMethod]
		public void TestCreateUser() {
			manager.CreateUser("example@gmail.com", "fiat!2");

			var listUsers = manager.GetUsers();

			Assert.IsTrue(listUsers.Count >= 1);
		}

		[TestMethod]
		public void TestGetUser() {
			manager.CreateUser("example@gmail.com", "fiat!2");

			var user = manager.GetUser(0);

			Assert.AreEqual("example@gmail.com", user.GetEmail());
			Assert.AreEqual("fiat!2", user.GetPassword());
		}

		[TestMethod]
		public void TestGetAllUsers() {
			manager.CreateUser("example@gmail.com", "fiat!2");

			var listUsers = manager.GetUsers();

			Assert.IsFalse(listUsers.Count <= 0);
		}

		[TestMethod]
		public void TestUpdateUser() {
			manager.CreateUser("teste@gmail.com", "fiat!1");

			var user = manager.UpdateUser(0, "example@gmail.com", "chevrolet!1");

			Assert.AreEqual("example@gmail.com", user.GetEmail());
			Assert.AreNotEqual("fiat!2", user.GetPassword());
		}

		[TestMethod]
		public void TestPartialUpdateUser() {
			manager.CreateUser("example@gmail.com", "fiat!2");

			var user = manager.UpdateUser(0, "", null);

			Assert.AreNotEqual("", user.GetEmail());
			Assert.AreNotEqual(null, user.GetPassword());
		}

		[TestMethod]
		public void TestDeleteUser() {
			manager.CreateUser("example@gmail.com", "fiat!2");

			manager.DeleteUser(0);

			var listUsers = manager.GetUsers();

			Assert.AreEqual(0, listUsers.Count);
		}
	}
}