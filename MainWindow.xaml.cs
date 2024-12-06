using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Data_Manager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static List<string> Genders = new List<string>()
		{
			"Férfi",
			"Nő"
		};

		public MainWindow()
		{
			InitializeComponent();
			gender.ItemsSource = Genders;
			gender.SelectedIndex = 0;

			User.LoadUsers();
		}

		private void Submit(object sender, RoutedEventArgs e)
		{
			User user = new User(name.Text, email.Text, address.Text, phoneNumber.Text, int.Parse(age.Text), gender.Text, comment.Text);
			User.AddUser(user);

			ListWindow listWindow = new ListWindow();
			listWindow.Show();
			this.Close();
		}

		private bool ValidateData()
		{
			if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(age.Text) || string.IsNullOrEmpty(gender.Text) || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(address.Text) || string.IsNullOrEmpty(phoneNumber.Text))
			{
				return false;
			}

			if (name.Text.Length < 3) return false;
			if (phoneNumber.Text.Length < 8) return false;

			Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
			if (!emailRegex.IsMatch(email.Text)) return false;

			return true;
		}

		private void HadleInput(object sender, TextChangedEventArgs e)
		{
			if (ValidateData()) submit.IsEnabled = true;
			else submit.IsEnabled = false;
		}
		private void HandleGenderChange(object sender, SelectionChangedEventArgs e)
		{
			if (ValidateData()) submit.IsEnabled = true;
			else submit.IsEnabled = false;
		}

		private void OnlyAllowNumbers(object sender, TextCompositionEventArgs e)
		{
			Regex nums = new Regex("[^0-9]+");
			e.Handled = nums.IsMatch(e.Text);
		}
	}
}