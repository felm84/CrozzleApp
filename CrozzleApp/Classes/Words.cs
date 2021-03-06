﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrozzleApp.Classes
{
    class Words
    {
        // Determines if the file is valid
        private bool valid = true;

        /* 
         * List organizes all names 
         * to be used in ValidadeFile
        */
        List<string> words = new List<string>();

        public bool Valid
        {
            get => valid;
            private set => valid = value;
        }

        public Words(string file)
        {
            ReadFile(file);
            ValidateFile();
        }

        #region WORDS METHODS
        private void ReadFile(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
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

                        string[] word = line.Split(new char[] { ',' });
                        // Converts array word into List words;
                        words = word.ToList();
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
            foreach (string word in words)
            {
                if (!CheckWord(word))
                {
                    valid = false;
                    break;
                }
            }
        }

        private bool CheckWord(string word)
        {
            Match match = Regex.Match(word, @"(^[a-zA-Z]\w*$)");
            if (!match.Success)
            {
                Log.logs.Add("Invalid word: " + word);
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
