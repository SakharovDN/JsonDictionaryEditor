using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDictionaryEditor
{
    public class JsonDictionary
    {
        public Dictionary<string, string> Words { get; set; }

        public Dictionary<string, string> Open(string fileName)
        {
            string dictionaryContent = File.ReadAllText(fileName);
            Words = JsonConvert.DeserializeObject<Dictionary<string, string>>(dictionaryContent);
            return Words;
        }

        public void Save(string fileName)
        {
            string dictionary = JsonConvert.SerializeObject(Words, Formatting.Indented);
            File.WriteAllText(fileName, dictionary);
        }

    }
}
