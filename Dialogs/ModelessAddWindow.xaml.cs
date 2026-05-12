using System;
using System.Windows;

namespace PersonManager
{
    // A window that stays open and lets you add multiple people without blocking the main app
    public partial class ModelessAddWindow : Window
    {
        // An event that other windows can listen to when a new person is created
        public event EventHandler<Person> PersonAdded;

        // Constructor: runs when the window is first opened
        public ModelessAddWindow()
        {
            InitializeComponent(); // Loads the UI design
        }

        // Triggered when the user clicks the "Add" button
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // Make sure the birth year typed in is actually a number
            if (int.TryParse(TxtBirthYear.Text, out int year))
            {
                // Create a new Person object with the typed text (trim removes extra spaces)
                var newPerson = new Person(
                    TxtFirstName.Text.Trim(),
                    TxtLastName.Text.Trim(),
                    year,
                    TxtCity.Text.Trim()
                );

                // Notify the main window to add this person
                PersonAdded?.Invoke(this, newPerson);

                // Reset fields for the next input
                TxtFirstName.Clear();
                TxtLastName.Clear();
                TxtBirthYear.Clear();
                TxtCity.Clear();
                
                // Put the typing cursor back in the first name box automatically
                TxtFirstName.Focus();
            }
            else
            {
                // Show an error if they typed text instead of a number for the year
                MessageBox.Show("Please enter a valid birth year.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Triggered when the user clicks the "Close" button
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Closes the window
        }
    }
}