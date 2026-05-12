using System;
using System.Windows;

namespace PersonManager
{
    public partial class ModelessAddWindow : Window
    {
        public event EventHandler<Person> PersonAdded;

        public ModelessAddWindow()
        {
            InitializeComponent();
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

                // Raise event to notify parent window
                PersonAdded?.Invoke(this, newPerson);

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