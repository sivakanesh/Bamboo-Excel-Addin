using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BambooExcel.Helpers
{
    static class IOHelper
    {

        public static int ReplaceText(FileInfo file, string findString, string replaceWithString, bool caseSensitive, bool spoofReplacement)
        {
            int matchCount = 0;
            string fileText = File.ReadAllText(Path.Combine(file.DirectoryName, file.Name));

            RegexOptions rxo;
            if (caseSensitive)
            {
                rxo = RegexOptions.IgnorePatternWhitespace;
            }
            else
            {
                rxo = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;
            }

            string newText = Regex.Replace(fileText, findString,
                (match) =>
                {
                    matchCount++;
                    return match.Result(replaceWithString);
                }, rxo);

            if (!spoofReplacement)
            {
                File.WriteAllText(Path.Combine(file.DirectoryName, file.Name), newText);
            }
            return matchCount;
        }

        public static string i2s(int ch){
            string str = Convert.ToChar(ch).ToString();
            return str;
            
        }


        
        //Append 1D array to multi D as a new column (Not as additional rows)
        public static void Append1DArrayToMultiDArray(ref string[,] originalArray, string[] oneDArray)
        {
            //TODO check the number of columns in the 1d array and throw error if there are more than one column
            //TODO check the number of rows in the 1d array and throw error if it's different to the multi D array

            var newArray = new string[originalArray.GetLength(0), originalArray.GetLength(1) + 1];

            for (int i = 0; i < originalArray.GetLength(0); i++)
            {
                for (int j = 0; j < originalArray.GetLength(1); j++)
                {
                    newArray[i, j] = originalArray[i, j];
                }
                newArray[i, newArray.GetLength(1)-1] = oneDArray[i];
            }
            originalArray = newArray;
        }

    }
}
