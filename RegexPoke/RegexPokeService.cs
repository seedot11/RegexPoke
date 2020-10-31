using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace RegexPoke
{
    public class RegexPokeService
    {
        public static string RegexResults(string[] args)
        {
            var names = GetAllPokemonNames();           
            var regexes = new List<Tuple<Regex, List<string>>>();
            var returnString = string.Empty;

            if (args != null && args.Any())
                foreach (var arg in args)
                {
                    regexes.Add(new Tuple<Regex, List<string>>(new Regex(arg.ToLower()), new List<string>()));
                }
            else
            {
                regexes.Add(new Tuple<Regex, List<string>>(new Regex("(^[wi].+f$)"), new List<string>()));
            }

            foreach (var name in names)
            {
                foreach (var regex in regexes)
                {
                    if (regex.Item1.IsMatch(name))
                        regex.Item2.Add(name);
                }
            }

            foreach (var regex in regexes)
            {
                returnString += $"{regex.Item1}: [{string.Join(',', regex.Item2)}]\n";
            }

            return returnString;
        }

        public static IEnumerable<string> GetAllPokemonNames()
        {
            var assembly = Assembly.GetExecutingAssembly();

            using Stream stream = assembly.GetManifestResourceStream(@"RegexPoke.pokemonnames.json");
            using StreamReader r = new StreamReader(stream);
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<string>>(json);
        }
    }

}
