using System.Text.RegularExpressions;

class auxRegexLib
{
    // Looks in 'inputStr' and replaces substrings that match 'pattern' with 'replacement'
    public static string replaceMatches(string inputStr, string pattern, string replacement)
    {
        Regex rgx = new Regex(pattern);
        string result = rgx.Replace(inputStr, replacement);
        return result;
    }

    // Returns the first occurrence of 'expr' in 'inputStr'
    public static string getFirstMatch(string inputStr, string expr)
    {
        string result = "";
        MatchCollection mc = Regex.Matches(inputStr, expr);

        foreach (Match m in mc)
        {
            result = m.Value;
            break;
        }

        return result;
    }

    // Finds a substring that matches 'expr' in 'str1', then moves it to 'str2'. The substring that matched the
    // expression 'expr' is removed from 'str1'
    public static bool transferMatch(ref string str1, ref string str2, string expr)
    {
        string match = auxRegexLib.getFirstMatch(str1, expr);
        str1 = auxRegexLib.replaceMatches(str1, expr, "");
        str2 += match;
        if (match == "") return false;
        else return true;
    }
}
