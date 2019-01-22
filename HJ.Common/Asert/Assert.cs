using System.Collections.Generic;

namespace HJ.Common.Asert
{
    public static class Assert
    {
        public static bool IsNull<T>(this IList<T> source)
        {
            return (source != null && source.Count != 0) 
                ? true : false;
        }
    }
}