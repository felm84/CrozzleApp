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
            readFile(file);
        }

        #region ENCAPSULATION
        public int MinNumberUniqWords
        {
            get => minNumberUniqWords;
            set => checkMinNumber(value);
        }

        public int MaxNumberUniqWords
        {
            get => maxNumberUniqWords;
            set => checkMaxNumber(value, minNumberUniqWords);
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
            set => checkColorData(value);
        }

        public string BgColorNonEmpty
        {
            get => bgColorNonEmpty;
            set => checkColorData(value);
        }

        public int MinNumberRows
        {
            get => minNumberRows;
            set => checkMinNumber(value);
        }

        public int MaxNumberRows
        {
            get => maxNumberRows;
            set => checkMaxNumber(value, minNumberRows);
        }

        public int MinNumberCol
        {
            get => minNumberCol;
            set => checkMinNumber(value);
        }

        public int MaxNumberCol
        {
            get => maxNumberCol;
            set => checkMaxNumber(value, minNumberCol);
        }

        public int MinHorzWords
        {
            get => minHorzWords;
            set => checkMinNumber(value);
        }

        public int MaxHorzWords
        {
            get => maxHorzWords;
            set => checkMaxNumber(value, minHorzWords);
        }

        public int MinVertWords
        {
            get => minVertWords;
            set => checkMinNumber(value);
        }

        public int MaxVertWords
        {
            get => maxVertWords;
            set => checkMaxNumber(value, minVertWords);
        }

        public int MinInterHorzWords
        {
            get => minInterHorzWords;
            set => checkMinNumber(value);
        }

        public int MaxInterHorzWords
        {
            get => maxInterHorzWords;
            set => checkMaxNumber(value, minInterHorzWords);
        }

        public int MinInterVertWords
        {
            get => minInterVertWords;
            set => checkMinNumber(value);
        }

        public int MaxInterVertWords
        {
            get => maxInterVertWords;
            set => checkMaxNumber(value, minInterVertWords);
        }

        public int MinNumberSameWord
        {
            get => minNumberSameWord;
            set => checkMinNumber(value);
        }

        public int MaxNumberSameWord
        {
            get => maxNumberSameWord;
            set => checkMaxNumber(value, minNumberSameWord);
        }

        public int MinNumberOfGroups
        {
            get => minNumberOfGroups;
            set => checkMinNumber(value);
        }

        public int MaxNumberOfGroups
        {
            get => maxNumberOfGroups;
            set => checkMaxNumber(value, minNumberOfGroups);
        }

        public int PointsPerWord
        {
            get => pointsPerWord;
            set => checkMinNumber(value);
        }

        public string InterPointsPerLetter
        {
            get => interPointsPerLetter;
            //TODO Implement an array list to check each pair of letters and points
            set => interPointsPerLetter = value;
        }

        public string NonInterPointsPerLetter
        {
            get => nonInterPointsPerLetter;
            //TODO Implement an array list to check each pair of letters and points
            set => nonInterPointsPerLetter = value;
        }

        #endregion

        // @checkMinNumber checks any int value for Minimum number data.
        private int checkMinNumber(int value)
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

        private int checkMaxNumber(int value, int minNumber)
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

        private string checkColorData(string value)
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
        public void readFile(string file)
        {

        }

        public void validateFile()
        {

        }

        #endregion
    }
}
