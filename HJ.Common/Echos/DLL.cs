using System.Reflection;

namespace HJ.Common.Echos
{
    public static class DLL
    {
        private static object _object;

        public static Assembly LoadDLL(string path)
        {
            return Assembly.LoadFrom(path);
        }

        public static object ClassName(this Assembly dll, string nameSpaceAndclassName)
        {
            _object = dll.CreateInstance(nameSpaceAndclassName);
            return _object;
        }

        public static MethodInfo MethodName(this object classInstance, string methodName)
        {
            return classInstance.GetType().GetMethod(methodName);
        }

        public static object Run(this MethodInfo method)
        {
            return method.Invoke(_object, null);
        }

        public static object Run(this MethodInfo method, object[] objects)
        {
            return method.Invoke(_object, objects);
        }
    }
}