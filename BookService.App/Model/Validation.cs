using System.Linq;

namespace BookService.App.Model
{
    public class Validation
    {
        public bool IsNegative(int value)
        {
            if (value < 0)
                return true;
            else
                return false;
        }

        public bool IsAllAlphabet(string value)
        {
            if (value.All(x => char.IsLetter(x) || char.IsWhiteSpace(x)))
                return true;
            else
                return false;
        }
    }
}
