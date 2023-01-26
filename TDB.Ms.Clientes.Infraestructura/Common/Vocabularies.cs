using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDB.Ms.Producto.Infraestructura.Common
{
    public static class Vocabularies
    {
        private static readonly Lazy<Vocabulary> Instance;

        public static Vocabulary Default => Instance.Value;

        static Vocabularies()
        {
            Instance = new Lazy<Vocabulary>(new Func<Vocabulary>(BuildDefault), LazyThreadSafetyMode.PublicationOnly);
        }

        private static Vocabulary BuildDefault()
        {
            Vocabulary vocabulary = new Vocabulary();
            vocabulary.AddPlural("$", "s");
            vocabulary.AddPlural("s$", "s");
            vocabulary.AddPlural("(ax|test)is$", "$1es");
            vocabulary.AddPlural("(octop|vir|alumn|fung|cact|foc|hippopotam|radi|stimul|syllab|nucle)us$", "$1i");
            vocabulary.AddPlural("(alias|bias|iris|status|campus|apparatus|virus|walrus|trellis)$", "$1es");
            vocabulary.AddPlural("(buffal|tomat|volcan|ech|embarg|her|mosquit|potat|torped|vet)o$", "$1oes");
            vocabulary.AddPlural("([dti])um$", "$1a");
            vocabulary.AddPlural("sis$", "ses");
            vocabulary.AddPlural("(?:([^f])fe|([lr])f)$", "$1$2ves");
            vocabulary.AddPlural("(hive)$", "$1s");
            vocabulary.AddPlural("([^aeiouy]|qu)y$", "$1ies");
            vocabulary.AddPlural("(x|ch|ss|sh)$", "$1es");
            vocabulary.AddPlural("(matr|vert|ind|d)ix|ex$", "$1ices");
            vocabulary.AddPlural("([m|l])ouse$", "$1ice");
            vocabulary.AddPlural("^(ox)$", "$1en");
            vocabulary.AddPlural("(quiz)$", "$1zes");
            vocabulary.AddPlural("(buz|blit|walt)z$", "$1zes");
            vocabulary.AddPlural("(hoo|lea|loa|thie)f$", "$1ves");
            vocabulary.AddPlural("(alumn|alg|larv|vertebr)a$", "$1ae");
            vocabulary.AddPlural("(criteri|phenomen)on$", "$1a");
            vocabulary.AddSingular("s$", "");
            vocabulary.AddSingular("(n)ews$", "$1ews");
            vocabulary.AddSingular("([dti])a$", "$1um");
            vocabulary.AddSingular("(analy|ba|diagno|parenthe|progno|synop|the|ellip|empha|neuro|oa|paraly)ses$", "$1sis");
            vocabulary.AddSingular("([^f])ves$", "$1fe");
            vocabulary.AddSingular("(hive)s$", "$1");
            vocabulary.AddSingular("(tive)s$", "$1");
            vocabulary.AddSingular("([lr]|hoo|lea|loa|thie)ves$", "$1f");
            vocabulary.AddSingular("(^zomb)?([^aeiouy]|qu)ies$", "$2y");
            vocabulary.AddSingular("(s)eries$", "$1eries");
            vocabulary.AddSingular("(m)ovies$", "$1ovie");
            vocabulary.AddSingular("(x|ch|ss|sh)es$", "$1");
            vocabulary.AddSingular("([m|l])ice$", "$1ouse");
            vocabulary.AddSingular("(o)es$", "$1");
            vocabulary.AddSingular("(shoe)s$", "$1");
            vocabulary.AddSingular("(cris|ax|test)es$", "$1is");
            vocabulary.AddSingular("(octop|vir|alumn|fung|cact|foc|hippopotam|radi|stimul|syllab|nucle)i$", "$1us");
            vocabulary.AddSingular("(alias|bias|iris|status|campus|apparatus|virus|walrus|trellis)es$", "$1");
            vocabulary.AddSingular("^(ox)en", "$1");
            vocabulary.AddSingular("(matr|d)ices$", "$1ix");
            vocabulary.AddSingular("(vert|ind)ices$", "$1ex");
            vocabulary.AddSingular("(quiz)zes$", "$1");
            vocabulary.AddSingular("(buz|blit|walt)zes$", "$1z");
            vocabulary.AddSingular("(alumn|alg|larv|vertebr)ae$", "$1a");
            vocabulary.AddSingular("(criteri|phenomen)a$", "$1on");
            vocabulary.AddIrregular("person", "people");
            vocabulary.AddIrregular("man", "men");
            vocabulary.AddIrregular("child", "children");
            vocabulary.AddIrregular("sex", "sexes");
            vocabulary.AddIrregular("move", "moves");
            vocabulary.AddIrregular("goose", "geese");
            vocabulary.AddIrregular("wave", "waves");
            vocabulary.AddIrregular("die", "dice");
            vocabulary.AddIrregular("foot", "feet");
            vocabulary.AddIrregular("tooth", "teeth");
            vocabulary.AddIrregular("curriculum", "curricula");
            vocabulary.AddIrregular("database", "databases");
            vocabulary.AddIrregular("zombie", "zombies");
            vocabulary.AddIrregular("is", "are", matchEnding: false);
            vocabulary.AddIrregular("that", "those", matchEnding: false);
            vocabulary.AddIrregular("this", "these", matchEnding: false);
            vocabulary.AddIrregular("bus", "buses", matchEnding: false);
            vocabulary.AddUncountable("equipment");
            vocabulary.AddUncountable("information");
            vocabulary.AddUncountable("rice");
            vocabulary.AddUncountable("money");
            vocabulary.AddUncountable("species");
            vocabulary.AddUncountable("series");
            vocabulary.AddUncountable("fish");
            vocabulary.AddUncountable("sheep");
            vocabulary.AddUncountable("deer");
            vocabulary.AddUncountable("aircraft");
            vocabulary.AddUncountable("oz");
            vocabulary.AddUncountable("tsp");
            vocabulary.AddUncountable("tbsp");
            vocabulary.AddUncountable("ml");
            vocabulary.AddUncountable("l");
            vocabulary.AddUncountable("water");
            vocabulary.AddUncountable("waters");
            vocabulary.AddUncountable("semen");
            vocabulary.AddUncountable("sperm");
            vocabulary.AddUncountable("bison");
            vocabulary.AddUncountable("grass");
            vocabulary.AddUncountable("hair");
            vocabulary.AddUncountable("mud");
            vocabulary.AddUncountable("elk");
            vocabulary.AddUncountable("luggage");
            vocabulary.AddUncountable("moose");
            vocabulary.AddUncountable("offspring");
            vocabulary.AddUncountable("salmon");
            vocabulary.AddUncountable("shrimp");
            vocabulary.AddUncountable("someone");
            vocabulary.AddUncountable("swine");
            vocabulary.AddUncountable("trout");
            vocabulary.AddUncountable("tuna");
            vocabulary.AddUncountable("corps");
            vocabulary.AddUncountable("scissors");
            vocabulary.AddUncountable("means");
            return vocabulary;
        }
    }
}
