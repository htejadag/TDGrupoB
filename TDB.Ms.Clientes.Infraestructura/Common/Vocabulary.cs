using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDB.Ms.Producto.Infraestructura.Common
{
    public class Vocabulary
    {
        private class Rule
        {
            private readonly Regex _regex;

            private readonly string _replacement;

            public Rule(string pattern, string replacement)
            {
                _regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                _replacement = replacement;
            }

            public string Apply(string word)
            {
                if (!_regex.IsMatch(word))
                {
                    return null;
                }

                return _regex.Replace(word, _replacement);
            }
        }

        private readonly List<Rule> _plurals = new List<Rule>();

        private readonly List<Rule> _singulars = new List<Rule>();

        private readonly List<string> _uncountables = new List<string>();

        internal Vocabulary()
        {
        }

        public void AddIrregular(string singular, string plural, bool matchEnding = true)
        {
            if (matchEnding)
            {
                AddPlural("(" + singular[0] + ")" + singular.Substring(1) + "$", "$1" + plural.Substring(1));
                AddSingular("(" + plural[0] + ")" + plural.Substring(1) + "$", "$1" + singular.Substring(1));
            }
            else
            {
                AddPlural("^" + singular + "$", plural);
                AddSingular("^" + plural + "$", singular);
            }
        }

        public void AddUncountable(string word)
        {
            _uncountables.Add(word.ToLower());
        }

        public void AddPlural(string rule, string replacement)
        {
            _plurals.Add(new Rule(rule, replacement));
        }

        public void AddSingular(string rule, string replacement)
        {
            _singulars.Add(new Rule(rule, replacement));
        }

        public string Pluralize(string word, bool inputIsKnownToBeSingular = true)
        {
            string text = ApplyRules(_plurals, word);
            if (inputIsKnownToBeSingular)
            {
                return text;
            }

            string text2 = ApplyRules(_singulars, word);
            string text3 = ApplyRules(_plurals, text2);
            if (text2 != null && text2 != word && text2 + "s" != word && text3 == word && text != word)
            {
                return word;
            }

            return text;
        }

        public string Singularize(string word, bool inputIsKnownToBePlural = true)
        {
            string text = ApplyRules(_singulars, word);
            if (inputIsKnownToBePlural)
            {
                return text;
            }

            string text2 = ApplyRules(_plurals, word);
            string text3 = ApplyRules(_singulars, text2);
            if (text2 != word && word + "s" != text2 && text3 == word && text != word)
            {
                return word;
            }

            return text ?? word;
        }

        private string ApplyRules(IList<Rule> rules, string word)
        {
            if (word == null)
            {
                return null;
            }

            if (IsUncountable(word))
            {
                return word;
            }

            string result = word;
            int num = rules.Count - 1;
            while (num >= 0 && (result = rules[num].Apply(word)) == null)
            {
                num--;
            }

            return result;
        }

        private bool IsUncountable(string word)
        {
            return _uncountables.Contains(word.ToLower());
        }
    }
}
