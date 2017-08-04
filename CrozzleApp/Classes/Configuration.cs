using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrozzleApp.Classes
{
    class Configuration
    {
        #region PRIVATE VARIABLES
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
        }

        #region ENCAPSULATION
        public int MinNumberUniqWords
        {
            get => minNumberUniqWords;
            private set => CheckMinNumber(value);
        }

        public int MaxNumberUniqWords
        {
            get => maxNumberUniqWords;
            private set => CheckMaxNumber(value, minNumberUniqWords);
        }

        public string InvalidCrozzleScore
        {
            get => invalidCrozzleScore;
            set
            {
                if (value.GetType() == typeof(string))
                {
                    invalidCrozzleScore = value;
                }
                else
                {
                    //TODO Implement error
                }
            }
        }

        public bool Uppercase
        {
            get => uppercase;
            set
            {
                if (value.GetType() == typeof(bool))
                {
                    uppercase = value;
                }
                else
                {
                    //TODO Implement error
                }

            }
        }

        public string BgColorEmpty
        {
            get => bgColorEmpty;
            private set => CheckColorData(value);
        }

        public string BgColorNonEmpty
        {
            get => bgColorNonEmpty;
            private set => CheckColorData(value);
        }

        public int MinNumberRows
        {
            get => minNumberRows;
            private set => CheckMinNumber(value);
        }

        public int MaxNumberRows
        {
            get => maxNumberRows;
            private set => CheckMaxNumber(value, minNumberRows);
        }

        public int MinNumberCol
        {
            get => minNumberCol;
            private set => CheckMinNumber(value);
        }

        public int MaxNumberCol
        {
            get => maxNumberCol;
            private set => CheckMaxNumber(value, minNumberCol);
        }

        public int MinHorzWords
        {
            get => minHorzWords;
            private set => CheckMinNumber(value);
        }

        public int MaxHorzWords
        {
            get => maxHorzWords;
            private set => CheckMaxNumber(value, minHorzWords);
        }

        public int MinVertWords
        {
            get => minVertWords;
            private set => CheckMinNumber(value);
        }

        public int MaxVertWords
        {
            get => maxVertWords;
            private set => CheckMaxNumber(value, minVertWords);
        }

        public int MinInterHorzWords
        {
            get => minInterHorzWords;
            private set => CheckMinNumber(value);
        }

        public int MaxInterHorzWords
        {
            get => maxInterHorzWords;
            private set => CheckMaxNumber(value, minInterHorzWords);
        }

        public int MinInterVertWords
        {
            get => minInterVertWords;
            private set => CheckMinNumber(value);
        }

        public int MaxInterVertWords
        {
            get => maxInterVertWords;
            private set => CheckMaxNumber(value, minInterVertWords);
        }

        public int MinNumberSameWord
        {
            get => minNumberSameWord;
            private set => CheckMinNumber(value);
        }

        public int MaxNumberSameWord
        {
            get => maxNumberSameWord;
            private set => CheckMaxNumber(value, minNumberSameWord);
        }

        public int MinNumberOfGroups
        {
            get => minNumberOfGroups;
            private set => CheckMinNumber(value);
        }

        public int MaxNumberOfGroups
        {
            get => maxNumberOfGroups;
            private set => CheckMaxNumber(value, minNumberOfGroups);
        }

        public int PointsPerWord
        {
            get => pointsPerWord;
            private set => CheckMinNumber(value);
        }

        public string InterPointsPerLetter
        {
            get => interPointsPerLetter;
            //TODO Implement an array list to check each pair of letters and points
            private set => interPointsPerLetter = value;
        }

        public string NonInterPointsPerLetter
        {
            get => nonInterPointsPerLetter;
            //TODO Implement an array list to check each pair of letters and points
            private set => nonInterPointsPerLetter = value;
        }

        #endregion

        // @checkMinNumber checks any int value for Minimum number data.
        private int CheckMinNumber(int value)
        {
            if ((value.GetType() == typeof(int)) && (value > 0))
            {
                return value;
            }
            else
            {
                return -1;
            }
        }

        private int CheckMaxNumber(int value, int minNumber)
        {
            if ((value.GetType() == typeof(int)) && (value > minNumber))
            {
                return value;
            }
            else
            {
                return -1;
            }
        }

        private string CheckColorData(string value)
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
                return "Error";
            }
        }

        #region CONFIGURATION METHODS
        public void ReadFile(string file)
        {

        }

        public void ValidateFile()
        {

        }

        #endregion
    }
}
