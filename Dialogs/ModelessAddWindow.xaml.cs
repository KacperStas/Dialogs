using System.Windows;

namespace PersonManager
{
    public partial class ModelessAddWindow : Window
    {
        private MainWindow _mainWindow;

        public ModelessAddWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TxtBirthYear.Text, out int year))
            {
                var newPerson = new Person(
                    TxtFirstName.Text.Trim(),
                    TxtLastName.Text.Trim(),
                    year,
                    TxtCity.Text.Trim()
                );

                // Instantly append to the main window list
                _mainWindow.PeopleList.Add(newPerson);

                // Clear input fields for the next entry
                TxtFirstName.Clear();
                TxtLastName.Clear();
                TxtBirthYear.Clear();
                TxtCity.Clear();
                TxtFirstName.Focus();
            }
            else
            {
                MessageBox.Show("Please enter a valid birth year.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}