using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamirTask1
{
    public static class AddressPatternParser
    {
        private static readonly List<string> Patterns = new List<string>()
        {
            "mənzil","m","mən","men","MƏNZİL_",
            "m_","mən_","MƏNZİL","E","EV","EV_",
            "ev"
        };

        public static List<AddressPatternObject> GetAddressPatterns(string address)
        {
            List<AddressPatternObject> results = new List<AddressPatternObject>();
            for (int i = 0; i < Patterns.Count; i++)
            {
                var result = Match(address, Patterns[i]);
                if (result != null)
                {
                    var patternObject = CreateAddressPatternObject(result);
                    results.Add(patternObject);
                }
            }
            return results;
        }

        private static string Match(string source, string pattern)
        {
            var words = source.Split(' ');
            string result = null;
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (words[i] == pattern)
                {
                    int num;
                    var isInteger = int.TryParse(words[i + 1], out num);
                    result = isInteger ?pattern + " " + words[i + 1] : null;
                }
            }
            return result;
        }

        private static AddressPatternObject CreateAddressPatternObject(string patternVal)
        {
            var patternPart = patternVal.Split(' ').First();
            var pattern = string.Format("[{0} \"rəqəm\"]", patternPart);
            AddressPatternObject addressPatternObject = new AddressPatternObject() 
            { 
                PatternName = pattern,
                PatternValue = patternVal
            };
            return addressPatternObject;
        }
    }
}
