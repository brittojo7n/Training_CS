namespace Training_CS
{
    public class Factorial
    {
        public int Fact(int num)
        {
            return num == 0 ? 1 : num * Fact(num - 1);
        }
    }
}
