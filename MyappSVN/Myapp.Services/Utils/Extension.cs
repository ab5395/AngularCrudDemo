using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Myapp.Services.Utils
{
	public static class EnumerationExtension
	{
		public static string Description(this Enum value)
		{
			var field = value.GetType().GetField(value.ToString());
			var attributes = field.GetCustomAttributes(false);

			dynamic displayAttribute = null;

			if (attributes.Any())
			{
				displayAttribute = attributes.ElementAt(0);
			}

			return displayAttribute?.Description ?? null;
		}

		public static string DescriptionAttr<T>(this T source)
		{
			var fi = source.GetType().GetField(source.ToString());

			var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute), false);

			if (attributes != null && attributes.Length > 0) return attributes[0].Description;
			else return source.ToString();
		}
	}
}
