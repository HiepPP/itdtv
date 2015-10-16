using System;
using System.ComponentModel;
using System.Reflection;

namespace ssc.consulting.switchboard.Infactractures
{
    public static class FunctionExtention
    {
        public static bool IsNull(this object value)
        {
            if (value == null)
                return true;
            return false;
        }

        public static bool IsNotNull(this object value)
        {
            return !value.IsNull();
        }
        public static string GetEnumDescription<TEnum>(this TEnum en)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }

        public static bool IsGuidEmpty(this Guid guid)
        {
            if (guid.IsNull() || guid.Equals(Guid.Empty))
                return true;
            return false;
        }
        public static bool IsGuidNotEmpty(this Guid guid)
        {
            return !IsGuidEmpty(guid);
        }
        public static bool IsGuidNullOrEmpty(this Guid? guid)
        {
            if (guid.IsNull() || guid.Equals(Guid.Empty))
                return true;
            return false;
        }
        public static bool IsGuidNotNullAndEmpty(this Guid? guid)
        {
            return !IsGuidNullOrEmpty(guid);
        }
    }
}