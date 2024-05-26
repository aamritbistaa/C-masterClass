namespace TestLibrary
{
    public class Manager : Employee
    {
        public string GetAllName()
        {
            return $"{FirstName}, {LastName},{formerLastName}";
        
        }
    }
}
