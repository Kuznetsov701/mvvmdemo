using System.Linq;

namespace MVVM.Demo3
{
    public static class Extensions
    {
        public static bool In<T>(this T self, params T[] p)
        {
            return p.Contains(self);
        }

        public static string AsSymbol(this Operation op)
        {
            switch (op)
            {
                case Operation.Sum: return "+";
                case Operation.Difference: return "-";
                case Operation.Division: return "/";
                case Operation.Multiplication: return "*";
            }
            return null;
        }
    }
}
