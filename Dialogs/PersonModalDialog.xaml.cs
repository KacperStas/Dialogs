using System.Windows;

namespace PersonManager
{
    // A popup window used for both Adding and Editing a single person
    public partial class PersonModalDialog : Window
    {
        // Stores the person that was created or edited so the main window can read it
        public Person ResultPerson { get; private set; }

        // Constructor: Sets up the window. Handles both "Add" (default) and "Edit" modes.
        public PersonModalDialog(string title = "Add Person", string actionButtonContent = "Add", Person personToEdit = null)
        {
            InitializeComponent(); // Loads the UI design
            
            // Customize text based on whether we are adding or editing
            this.Title = title;
            ActionButton.Content = actionButtonContent;

            // If we are editing, pre-fill the text boxes with the existing person's data
            if (personToEdit != null)
            {
                TxtFirstName.Text = personToEdit.FirstName;
                TxtLastName.Text = personToEdit.LastName;
                TxtBirthYear.Text = personToEdit.BirthYear.ToString();
                TxtCity.Text = personToEdit.City;
            }
        }

        // Triggered when the user clicks the action button (Add/Edit/OK)
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the typed birth year is a valid number
            if (int.TryParse(TxtBirthYear.Text, out int year))
            {
                // Create a final Person object with all the details
                ResultPerson = new Person(
                    TxtFirstName.Text.Trim(),
                    TxtLastName.Text.Trim(),
                    year,
                    TxtCity.Text.Trim()
                );

                this.DialogResult = true; // Signals success and closes the dialog
            }
            else
            {
                // Show an error if the year is invalid
                MessageBox.Show("Please enter a valid birth year.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Triggered when the user clicks the Cancel button
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false; // Closes the dialog without saving
        }
    }
}