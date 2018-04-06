using System.ComponentModel;

namespace ProgParty.CookSousVide.Core.Attribute
{
    public class EnumNameAttribute : DescriptionAttribute
    {
        public EnumNameAttribute(string name)
            : base(name)
        {
        }
    }
}
