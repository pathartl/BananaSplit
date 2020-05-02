using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace BananaSplit.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<string> GetDisplayNames(this Type @enum)
        {
            var displayNames = new List<string>();
            var fields = @enum.GetFields();
            var enumFields = fields.Where(f => f.DeclaringType.Name == f.FieldType.Name);

            foreach (var field in enumFields)
            {
                try
                {
                    displayNames.Add(field.GetCustomAttribute<DisplayAttribute>().Name);
                }
                catch {
                    displayNames.Add(field.Name);
                }
            }

            return displayNames;
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            try
            {
                return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName();
            }
            catch
            {
                return enumValue.ToString();
            }
        }

        
    }
}
