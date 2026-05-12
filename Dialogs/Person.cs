namespace PersonManager
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public string City { get; set; }

        public Person(string firstName, string lastName, int birthYear, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            City = city;
        }

        // Required by Point 1: Determines how the object is displayed in the ListBox
        public override string ToString()
        {
            return $"{FirstName} {LastName} (born: {BirthYear}), {City}";
        }
    }
}