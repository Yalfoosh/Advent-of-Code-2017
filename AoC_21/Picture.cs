using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_21
{
    public class Picture
    {
        private Dictionary<string, string> _rules;

        public Picture(string[] rules)
        {
            _rules 
        }

        private void EstablishRules(string[] rulebook)
        {
            Regex Separator = new Regex(@"\s+=>\s+");

            for (int i = 0; i < rulebook.Length; ++i)
            {
                var Sections = Separator.Split(rulebook[i]);
                var PixelatedRule = RuleToPixel(Sections[0]);

                for (int j = 0; j < PixelatedRule.Length; ++i)
                {

                }
            }
        }

        public string[] RuleToPixel(string rule) => new Regex(@"/").Split(rule);
        public string PixelToRule(string[] pixel)
        {
            string toRet = "";

            for (int i = 0; i < pixel.Length; ++i)
            {
                toRet += pixel[i];

                if (i + 1 < pixel.Length)
                    toRet += "/";
            }

            return toRet;
        }

        public string[] RotatePixelRight(string[] pixel)
        {
            string[] toRet = new string[pixel.Length];


        }
    }
}
