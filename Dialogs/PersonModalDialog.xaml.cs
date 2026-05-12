using System.Windows;

namespace PersonManager
{
    public partial class PersonModalDialog : Window
    {
        public Person ResultPerson { get; private set; }

        public PersonModalDialog(string title = "Add Person", string actionButtonContent = "Add", Person personToEdit = null)
        {
            InitializeComponent();
            this.Title = title;
            ActionButton.Content = actionButtonContent;

            if (personToEdit != null)
            {
                TxtFirstName.Text = personToEdit.FirstName;
                TxtLastName.Text = personToEdit.LastName;
                TxtBirthYear.Text = personToEdit.BirthYear.ToString();
                TxtCity.Text = personToEdit.City;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TxtBirthYear.Text, out int year))
            {
                ResultPerson = new Person(
                    TxtFirstName.Text.Trim(),
                    TxtLastName.Text.Trim(),
                    year,
                    TxtCity.Text.Trim()
                );

                this.DialogResult = true; // Signals OK to close modal successfully
            }
            else
            {
                MessageBox.Show("Please enter a valid birth year.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false; // Closes without saving
        }
    }
}