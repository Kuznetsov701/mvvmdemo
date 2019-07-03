using System.Linq;

namespace MVVM.Demo3
{
    public static class Extensions
    {
        public static bool In<T>(this T self, params T[] p)
        {
            return p.Contains(self);
        } 
    }
}
