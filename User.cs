using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Data_Manager
{
	public class User
	{
		public static List<User> Users = new List<User>();
		public string Name { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public int Age { get; set; }
		public string Gender { get; set; }

		public string Comment { get; set; }

		public User(string name, string email, string address, string phoneNumber, int age, string gender, string comment = "")
		{
			this.Name = name;
			this.Email = email;
			this.Address = address;
			this.PhoneNumber = phoneNumber;
			this.Age = age;
			this.Gender = gender;
			this.Comment = comment;
		}

		public override string ToString()
		{
			return $"{this.Name} - {this.Address}";
		}

		public static void AddUser(User user)
		{
			Users.Add(user);
			using (StreamWriter writer = new StreamWriter("users.txt", true))
			{
				writer.WriteLine($"{user.Name};{user.Email};{user.Address};{user.PhoneNumber};{user.Age};{user.Gender};{user.Comment}");
			}
		}

		public static void LoadUsers()
		{
			Users.Clear();

			if (!File.Exists("users.txt"))
			{
				File.Create("users.txt");
				return;
			}

			List<string> lines = File.ReadAllLines("users.txt").ToList();

			foreach (string line in lines)
			{
				string[] parts = line.Split(';');
				if (parts.Length < 6) throw new ArgumentException("not enough data");

				User user = new User(parts[0], parts[1], parts[2], parts[3], int.Parse(parts[4]), parts[5], parts[6]);
				Users.Add(user);
			}
		}

		public static void RemoveUser(User user)
		{
			Users.Remove(user);
			File.WriteAllLines("users.txt", Users.Select(u => $"{u.Name};{u.Email};{u.Address};{u.PhoneNumber};{u.Age};{u.Gender};{u.Comment}"));
		}
	}
}
