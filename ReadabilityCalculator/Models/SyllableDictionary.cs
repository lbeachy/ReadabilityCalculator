using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReadabilityCalculator.Models
{
    public class SyllableDictionary
    {

        private SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();

        public SyllableDictionary()
        {
            ReadFile();
        }
        private void ReadFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            // the @ means take whatever is after at as a string literal, otherwise the \ might be compiled as an escape sequence
            currentDirectory += @"\files\dictionary.txt";

            //this using just makes so that the file closes after the block is executed

            using (var streamReader = new StreamReader(currentDirectory))
            {
                string row;
                while ((row = streamReader.ReadLine()) != null)
                {
                    string[] cols = row.Split(',');
                    int.TryParse(cols[1], out int syllables);
                    sortedDictionary.Add(cols[0], syllables);
                }
            }
        }

        public int GetSyllableCount(string word)
        {
            sortedDictionary.TryGetValue(word.ToUpper(), out int syllables);

            return syllables;
        }
    }
}
