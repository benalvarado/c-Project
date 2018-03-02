using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BSW_Tool_Kit
{
    /// <summary>
    /// To Parse the White Spaces in a string and replace them with ?
    /// A file path may have white space such as "c:\Program Files" 
    /// Powershell does NOT allow White space unless it is encapsulated in "" or the White Space is replaced with a ? wild card.
    /// </summary>
    class WhiteSpaceParsing
    {
        public static string parsedResult(string result_holder)
        {
            string value = string.Empty;

            string pattern = "\\s+";
            string replacement = "?";
            Regex rgx = new Regex(pattern);
            string parsedStuff = rgx.Replace(result_holder, replacement);
            value = parsedStuff;
            return value;
        }

    }
}
