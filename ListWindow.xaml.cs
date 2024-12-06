using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Data_Manager
{
	/// <summary>
	/// Interaction logic for List.xaml
	/// </summary>
	public partial class ListWindow : Window
	{
		public ListWindow()
		{
			InitializeComponent();
			users.ItemsSource = User.Users;
		}

		private void Back(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close();
		}

		private void HandleUsersClick(object sender, MouseButtonEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Biztosan törlöd ezt a felhasználót?", "Felhasználó Törlése", MessageBoxButton.YesNo);
			if (result == MessageBoxResult.No) return;

			User.RemoveUser((User)users.SelectedItem);
			users.Items.Refresh();
		}
	}
}
