namespace MiniProject_UnitTests
{
    public class Calculations
    {

        public double Add (double first, double second)
        {
            return (dynamic)first + second;
        }
        public double Substract(double first, double second)
        {
           
                return first-second;
           
        }
        public double Multiply(double first, double second)
        {
            return first * second;
        }
        public double Divide(double first, double second)
        {
            if(second == 0)
            {
                return 0;
            }
                return first / second;
        }
    }
}
