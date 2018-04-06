using ProgParty.CookSousVide.Core.Attribute;
using System;
using System.Reflection;

namespace ProgParty.CookSousVide.Core.Extension
{
    public static class EnumExtention
    {
        public static string GetName(this Enum value)
        {
            FieldInfo field = value.GetFieldInfo();
            if (field == null)
                return null;

            var attr = System.Attribute.GetCustomAttribute(field, typeof(EnumNameAttribute)) as EnumNameAttribute;
            return attr?.Description;
        }

     
        private static FieldInfo GetFieldInfo(this IConvertible value)
        {
            System.Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
                return null;

            FieldInfo field = type.GetField(name);
            return field;
        }
    }
}