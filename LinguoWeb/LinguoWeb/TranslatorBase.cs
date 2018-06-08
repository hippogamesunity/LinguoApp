using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LinguoWeb
{
	public abstract class TranslatorBase
	{
		private static readonly Dictionary<int, string> Romans = new Dictionary<int, string>();

		protected static string ReplaceRomanNumbers(string result)
		{
			foreach (Match match in Regex.Matches(result, @" ([IÎVX]+)(\W+|$)"))
			{
				var hash = match.Groups[1].GetHashCode();

				if (!Romans.ContainsKey(hash)) Romans.Add(hash, match.Groups[1].Value);

				result = result.Replace(match.Groups[1].Value, "[#" + hash + "]");
			}

			return result;
		}

		protected static string RestoreRomanNumbers(string result)
		{
			foreach (Match match in Regex.Matches(result, @"\[#(\d+)\]"))
			{
				result = result.Replace(match.Groups[0].Value, Romans[int.Parse(match.Groups[1].Value)]);
			}

			return result;
		}
	}
}