namespace ClassLibrary
{
    public class DisplayMessage
    {
        public string Greeting(string FirstName,int hourOfTheDay)
        {
            //DataAccess da = new DataAccess();
            //da.WriteToDb("MyData");
            if (hourOfTheDay < 5)
            {
                return $"Go to bed {FirstName}";
            }
            else if (hourOfTheDay < 12)
            {
                return $"Good morning {FirstName}";
            }
            else if (hourOfTheDay <18)
            {
                return $"Good afternoon {FirstName}";
            }
            else
            {
                return $"Good evening {FirstName}";
            }
        }
    }
}
