namespace Training_CS.Classes
{
    public class Factorial
    {
        public int Fact(int num)
        {
            return num == 0 ? 1 : num * Fact(num - 1);
        }
    }
}
