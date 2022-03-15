using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurrplingCore.Framework.Serialization
{
    internal class TypeUtils
    {
        public static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        public static bool FetchRawGeneric(Type generic, Type toDerive)
        {
            while (toDerive != null && toDerive != typeof(object))
            {
                var cur = toDerive.IsGenericType ? toDerive.GetGenericTypeDefinition() : toDerive;
                if (generic == cur)
                {
                    return true;
                }
                toDerive = toDerive.BaseType;
            }
            return false;
        }
    }
}
