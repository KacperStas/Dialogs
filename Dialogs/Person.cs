namespace PersonManager
{
    // Represents a single person with their basic details
    public class Person
    {
        // Properties to store the person's information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public string City { get; set; }

        // Constructor: called when creating a new Person object
        public Person(string firstName, string lastName, int birthYear, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            City = city;
        }

        // Formats how the person appears in the ListBox
        public override string ToString()
        {
            return $"{FirstName} {LastName} (born: {BirthYear}), {City}";
        }
    }
}
