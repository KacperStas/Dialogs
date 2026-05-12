using System.Collections.ObjectModel;
using System.Windows;

namespace PersonManager
{
    public partial class MainWindow : Window
    {
        // ObservableCollection automatically notifies the ListBox of additions
        public ObservableCollection<Person> PeopleList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            PeopleList = new ObservableCollection<Person>();
            PeopleListBox.ItemsSource = PeopleList;
        }

        private void AddMultipleBtn_Click(object sender, RoutedEventArgs e)
        {
            ModelessAddWindow modelessDialog = new ModelessAddWindow();
            modelessDialog.Owner = this;
            modelessDialog.PersonAdded += (s, person) => PeopleList.Add(person);
            modelessDialog.Show(); // Modeless call keeps main window accessible
        }

        private void AddSingleBtn_Click(object sender, RoutedEventArgs e)
        {
            PersonModalDialog modal = new PersonModalDialog();
            modal.Owner = this;

            // .ShowDialog() halts execution until the window is closed (Modal behavior)
            if (modal.ShowDialog() == true)
            {
                PeopleList.Add(modal.ResultPerson);
            }
        }
    }
}