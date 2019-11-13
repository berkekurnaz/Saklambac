using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saklambac.NetFramework.Helpers
{
    class ConvertValueType
    {
        public static object ConvertObject(string value, string targetTypeName)
        {
            try
            {
                switch (targetTypeName)
                {
                    case "System.Boolean":
                        return bool.Parse(value);
                    case "System.Byte":
                        return byte.Parse(value);
                    case "System.Int16":
                        return short.Parse(value);
                    case "System.Int32":
                        return int.Parse(value);
                    case "System.Int64":
                        return long.Parse(value);
                    case "System.SByte":
                        return sbyte.Parse(value);
                    case "System.UInt16":
                        return ushort.Parse(value);
                    case "System.UInt32":
                        return uint.Parse(value);
                    case "System.UInt64":
                        return ulong.Parse(value);
                    case "System.Single":
                        return float.Parse(value);
                    case "System.Double":
                        return double.Parse(value);
                    case "System.String":
                        return Convert.ToString(value);
                    default:
                        return null;
                }
            }
            catch { return null; }
        }
    }
}
