using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrozzleApp.Classes
{
    class Configuration
    {
        #region PRIVATE VARIABLES
        // Determines if the file is valid
        private bool valid = true;

        /* 
         * List of KeyValuePair organizes key value 
         * pairs to be used in ValidadeFile
         * and ValidadeCrozzle
        */
        private List<KeyValuePair<string, string>> lines = new List<KeyValuePair<string, string>>();

        // Limits on the size of the word list.
        private int minNumberUniqWords;
        private int maxNumberUniqWords;

        // Crozzle Output Configurations.
        private string invalidCrozzleScore;
        private bool uppercase;
        private string style;
        private string bgColorEmpty;
        private string bgColorNonEmpty;

        // Limits on the size of the crozzle grid.
        private int minNumberRows;
        private int maxNumberRows;
        private int minNumberCol;
        private int maxNumberCol;

        /*
         * Limits on the number of horizontal words and
         * vertical words in a crozzle. 
        */
        private int minHorzWords;
        private int maxHorzWords;
        private int minVertWords;
        private int maxVertWords;

        /*
         * Limits on the number of 
         * intersecting vertical words for each horizontal word, and
         * intersecting horizontal words for each vertical word. 
        */
        private int minInterHorzWords;
        private int maxInterHorzWords;
        private int minInterVertWords;
        private int maxInterVertWords;

        // Limits on duplicate words in the crozzle.
        private int minNumberSameWord;
        private int maxNumberSameWord;

        // Limits on the number of valid word groups.
        private int minNumberOfGroups;
        private int maxNumberOfGroups;

        /*
         * Scoring Configurations
         * The number of points per word within the crozzle.
        */
        private int pointsPerWord;

        /* 
         * Points per letter that is at the intersection of
         * a horizontal and vertical word within the crozzle.
        */
        private string interPointsPerLetter;

        /* 
         * Points per letter that is not at the intersection of
         * a horizontal and vertical word within the crozzle.
        */
        private string nonInterPointsPerLetter;

        #endregion

        public Configuration(string file)
        {
            ReadFile(file);
            ValidateFile();
        }

        #region ENCAPSULATION
        public bool Valid
        {
            get => valid;
            private set => valid = value;
        }

        public int MinNumberUniqWords
        {
            get => minNumberUniqWords;
            private set => minNumberUniqWords = value;
        }

        public int MaxNumberUniqWords
        {
            get => maxNumberUniqWords;
            private set => maxNumberUniqWords = value;
        }

        public string InvalidCrozzleScore
        {
            get => invalidCrozzleScore;
            private set => invalidCrozzleScore = value;
        }

        public bool Uppercase
        {
            get => uppercase;
            private set => uppercase = value;
        }

        public string Style
        {
            get => style;
            private set => style = value;
        }

        public string BgColorEmpty
        {
            get => bgColorEmpty;
            private set => bgColorEmpty = value;
        }

        public string BgColorNonEmpty
        {
            get => bgColorNonEmpty;
            private set => bgColorNonEmpty = value;
        }

        public int MinNumberRows
        {
            get => minNumberRows;
            private set => minNumberRows = value;
        }

        public int MaxNumberRows
        {
            get => maxNumberRows;
            private set => maxNumberRows = value;
        }

        public int MinNumberCol
        {
            get => minNumberCol;
            private set => minNumberCol = value;
        }

        public int MaxNumberCol
        {
            get => maxNumberCol;
            private set => maxNumberCol = value;
        }

        public int MinHorzWords
        {
            get => minHorzWords;
            private set => minHorzWords = value;
        }

        public int MaxHorzWords
        {
            get => maxHorzWords;
            private set => maxHorzWords = value;
        }

        public int MinVertWords
        {
            get => minVertWords;
            private set => minVertWords = value;
        }

        public int MaxVertWords
        {
            get => maxVertWords;
            private set => maxVertWords = value;
        }

        public int MinInterHorzWords
        {
            get => minInterHorzWords;
            private set => minInterHorzWords = value;
        }

        public int MaxInterHorzWords
        {
            get => maxInterHorzWords;
            private set => maxInterHorzWords = value;
        }

        public int MinInterVertWords
        {
            get => minInterVertWords;
            private set => minInterVertWords = value;
        }

        public int MaxInterVertWords
        {
            get => maxInterVertWords;
            private set => maxInterVertWords = value;
        }

        public int MinNumberSameWord
        {
            get => minNumberSameWord;
            private set => minNumberSameWord = value;
        }

        public int MaxNumberSameWord
        {
            get => maxNumberSameWord;
            private set => maxNumberSameWord = value;
        }

        public int MinNumberOfGroups
        {
            get => minNumberOfGroups;
            private set => minNumberOfGroups = value;
        }

        public int MaxNumberOfGroups
        {
            get => maxNumberOfGroups;
            private set => maxNumberOfGroups = value;
        }

        public int PointsPerWord
        {
            get => pointsPerWord;
            private set => pointsPerWord = value;
        }

        public string InterPointsPerLetter
        {
            get => interPointsPerLetter;
            private set => interPointsPerLetter = value;
        }

        public string NonInterPointsPerLetter
        {
            get => nonInterPointsPerLetter;
            private set => nonInterPointsPerLetter = value;
        }

        #endregion

        // @CheckMinNumber checks any int value for Minimum number data.
        private int CheckMinNumber(string key, string value)
        {
            int number = 0;
            try
            {
                number = int.Parse(value);
                if (number < 1)
                {
                    // TODO Attach this error to a Window Dialog
                    valid = false;
                    Log.logs.Add(key + " has value smaller than 1: " + number);
                }
            }
            catch (Exception ex)
            {
                valid = false;
                Log.logs.Add(ex.Message);
            }
            return number;
        }

        private int CheckMaxNumber(string key, string value, int minNumber)
        {
            int number = 0;
            try
            {
                number = int.Parse(value);
                if (minNumber == 0)
                {
                    valid = false;
                    Log.logs.Add("Minimum value not available");
                }
                else if (number < 1)
                {
                    // TODO Attach this error to a Window Dialog
                    valid = false;
                    Log.logs.Add(key + " has value smaller than 1: " + number);
                }
                else if (number < minNumber)
                {
                    // TODO Attach this error to a Window Dialog
                    valid = false;
                    Log.logs.Add(key +" has value smaller than " + minNumber + ": " + number);
                }
            }
            catch (Exception ex)
            {
                valid = false;
                Log.logs.Add(ex.Message);
            }
            return number;
        }

        private bool CheckBool(string value)
        {
            bool result = true;
            try
            {
                result = bool.Parse(value);
            }
            catch (Exception ex)
            {
                valid = false;
                Log.logs.Add(ex.Message);
            }

            return result;
        }

        private string CheckColorData(string key, string value)
        {
            // Regex matches value starting with 
            // # then values from a-f or 0-9 within 6 digits
            Match match = Regex.Match(value, @"(^#+[a-f | 0-9]{6})");
            if (match.Success && value.Length == 7)
            {
                return value;
            }
            else
            {
                //TODO Implement error
                valid = false;
                Log.logs.Add(key + " has invalid color value: " + value);
                return "Error: Color not available";
            }
        }

        #region CONFIGURATION METHODS
        private void ReadFile(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Replace("\"", "");

                        line = line.Trim();

                        int index = line.IndexOf(@"//");

                        if (index >= 0)
                        {
                            line = line.Remove(index);
                            line = line.Trim();
                        }
                        if (string.IsNullOrEmpty(line) || line.StartsWith(@"//"))
                        {
                            continue;
                        }

                        string[] keyValuePair = line.Split(new char[] { '=' });

                        /* TODO Fix ReadFile to adapt NON_INTERSECTING_POINTS_PER_LETTER
                         * and INTERSECTING_POINTS_PER_LETTER into another Dictionary.
                        */
                        lines.Add(new KeyValuePair<string, string>(keyValuePair[0], keyValuePair[1]));
                    }
                }
            }
            catch (Exception ex)
            {
                valid = false;
                Log.logs.Add(ex.Message);
            }
        }

        public void ValidateFile()
        {
            foreach (KeyValuePair<string, string> pair in lines)
            {
                switch (pair.Key)
                {
                    case "LOGFILE_NAME":
                        Log.file = pair.Value;
                        break;
                    case "MINIMUM_NUMBER_OF_UNIQUE_WORDS":
                        MinNumberUniqWords = CheckMinNumber(pair.Key, pair.Value);
                        break;
                    case "MAXIMUM_NUMBER_OF_UNIQUE_WORDS":
                        MaxNumberUniqWords = CheckMaxNumber(pair.Key, pair.Value, minNumberUniqWords);
                        break;
                    case "INVALID_CROZZLE_SCORE":
                        InvalidCrozzleScore = pair.Value;
                        break;
                    case "UPPERCASE":
                        Uppercase = CheckBool(pair.Value);
                        break;
                    case "STYLE":
                        Style = pair.Value;
                        break;
                    case "BGCOLOUR_EMPTY_TD":
                        BgColorEmpty = CheckColorData(pair.Key, pair.Value);
                        break;
                    case "BGCOLOUR_NON_EMPTY_TD":
                        BgColorNonEmpty = CheckColorData(pair.Key, pair.Value);
                        break;
                    case "MINIMUM_NUMBER_OF_ROWS":
                        MinNumberRows = CheckMinNumber(pair.Key, pair.Value);
                        break;
                    case "MAXIMUM_NUMBER_OF_ROWS":
                        MaxNumberRows = CheckMaxNumber(pair.Key, pair.Value, minNumberRows);
                        break;
                    case "MINIMUM_NUMBER_OF_COLUMNS":
                        MinNumberCol = CheckMinNumber(pair.Key, pair.Value);
                        break;
                    case "MAXIMUM_NUMBER_OF_COLUMNS":
                        MaxNumberCol = CheckMaxNumber(pair.Key, pair.Value, minNumberCol);
                        break;
                    case "MINIMUM_HORIZONTAL_WORDS":
                        MinHorzWords = CheckMinNumber(pair.Key, pair.Value);
                        break;
                    case "MAXIMUM_HORIZONTAL_WORDS":
                        MaxHorzWords = CheckMaxNumber(pair.Key, pair.Value, minHorzWords);
                        break;
                    case "MINIMUM_VERTICAL_WORDS":
                        MinVertWords = CheckMinNumber(pair.Key, pair.Value);
                        break;
                    case "MAXIMUM_VERTICAL_WORDS":
                        MaxVertWords = CheckMaxNumber(pair.Key, pair.Value, minVertWords);
                        break;
                    case "MINIMUM_INTERSECTIONS_IN_HORIZONTAL_WORDS":
                        MinInterHorzWords = CheckMinNumber(pair.Key, pair.Value);
                        break;
                    case "MAXIMUM_INTERSECTIONS_IN_HORIZONTAL_WORDS":
                        MaxInterHorzWords = CheckMaxNumber(pair.Key, pair.Value, minInterHorzWords);
                        break;
                    case "MINIMUM_INTERSECTIONS_IN_VERTICAL_WORDS":
                        MinInterVertWords = CheckMinNumber(pair.Key, pair.Value);
                        break;
                    case "MAXIMUM_INTERSECTIONS_IN_VERTICAL_WORDS":
                        MaxInterVertWords = CheckMaxNumber(pair.Key, pair.Value, minInterVertWords);
                        break;
                    case "MINIMUM_NUMBER_OF_THE_SAME_WORD":
                        MinNumberSameWord = CheckMinNumber(pair.Key, pair.Value);
                        break;
                    case "MAXIMUM_NUMBER_OF_THE_SAME_WORD":
                        MaxNumberSameWord = CheckMaxNumber(pair.Key, pair.Value, minNumberSameWord);
                        break;
                    case "MINIMUM_NUMBER_OF_GROUPS":
                        MinNumberOfGroups = CheckMinNumber(pair.Key, pair.Value);
                        break;
                    case "MAXIMUM_NUMBER_OF_GROUPS":
                        MaxNumberOfGroups = CheckMaxNumber(pair.Key, pair.Value, minNumberOfGroups);
                        break;
                    case "POINTS_PER_WORD":
                        PointsPerWord = CheckMinNumber(pair.Key, pair.Value);
                        break;
                    case "INTERSECTING_POINTS_PER_LETTER":
                        InterPointsPerLetter = pair.Value;
                        break;
                    case "NON_INTERSECTING_POINTS_PER_LETTER":
                        NonInterPointsPerLetter = pair.Value;
                        break;
                    default:
                        valid = false;
                        Log.logs.Add("Wrong file loaded");
                        break;
                }
            }
        }

        #endregion
    }
}
