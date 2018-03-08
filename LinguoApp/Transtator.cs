using System.Collections.Generic;

namespace LinguoApp
{
	public static class Transtator
	{
		private static Dictionary<string, string> SimpleReplace = new Dictionary<string, string>
		{
			{ "Szcz", "Щ" }, { "szcz", "щ" },

            { "Ą", "Ѫ" }, { "ą", "ѫ" },
		};

		public static string Translate(string input)
		{
			var result = input;

			foreach (var entry in SimpleReplace)
			{
				result = result.Replace(entry.Key, entry.Value);
			}

			return result;
		}
	}
}