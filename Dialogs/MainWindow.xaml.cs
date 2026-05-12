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
            // Placeholder for Commit 3
        }

        private void AddSingleBtn_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for Commit 4
        }
    }
}