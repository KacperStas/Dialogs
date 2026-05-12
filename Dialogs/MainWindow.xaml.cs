using System.Collections.ObjectModel;
using System.Windows;

namespace PersonManager
{
    // The main window of the application that displays the list of people
    public partial class MainWindow : Window
    {
        // Automatically updates the UI when items are added or removed
        public ObservableCollection<Person> PeopleList { get; set; }

        // Constructor: runs when the window is first opened
        public MainWindow()
        {
            InitializeComponent(); // Loads the UI design
            PeopleList = new ObservableCollection<Person>(); // Creates an empty list
            PeopleListBox.ItemsSource = PeopleList; // Links the list to the UI ListBox
        }

        // Triggered when the "Add (Modeless)" button is clicked
        private void AddMultipleBtn_Click(object sender, RoutedEventArgs e)
        {
            ModelessAddWindow modelessDialog = new ModelessAddWindow();
            modelessDialog.Owner = this; // Sets the main window as the owner
            
            // Listen for the PersonAdded event from the dialog and add the new person to the list
            modelessDialog.PersonAdded += (s, person) => PeopleList.Add(person);
            
            modelessDialog.Show(); // Opens dialog but lets you still use the main window
        }

        // Triggered when the "Add Single (Modal)" button is clicked
        private void AddSingleBtn_Click(object sender, RoutedEventArgs e)
        {
            PersonModalDialog modal = new PersonModalDialog();
            modal.Owner = this;

            // Halts main window execution until this dialog is closed
            if (modal.ShowDialog() == true)
            {
                // If the user clicked OK, add the newly created person to our list
                PeopleList.Add(modal.ResultPerson);
            }
        }

        // Triggered when the "Edit Selected" button is clicked
        private void EditSelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            // Check if the user has actually selected someone from the list
            if (PeopleListBox.SelectedItem is Person selectedPerson)
            {
                int selectedIndex = PeopleListBox.SelectedIndex; // Remember their position in the list

                // Open the dialog in "Edit mode" with the selected person's current details
                PersonModalDialog editModal = new PersonModalDialog("Edit Person", "Edit", selectedPerson);
                editModal.Owner = this;

                // Wait for the user to finish editing
                if (editModal.ShowDialog() == true)
                {
                    // Update the list with the edited data
                    PeopleList[selectedIndex] = editModal.ResultPerson;
                }
            }
            else
            {
                // Warn the user if they didn't select anyone before clicking Edit
                MessageBox.Show("Please select a person to edit.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}