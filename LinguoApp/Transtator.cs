using System.Collections.Generic;

namespace LinguoApp
{
	public static class Transtator
	{
		private static Dictionary<char, char> SimpleReplace = new Dictionary<char, char>
		{
			{ 'Ą', 'Ѫ' }, { 'a', 'ѫ' },

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