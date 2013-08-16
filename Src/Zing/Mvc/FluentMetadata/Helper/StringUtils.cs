namespace Zing.Mvc
{
    using System.Collections.Generic;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Splits upper case word to a string with spaces
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [ContractAnnotation("\"null=>null\""), CanBeNull]
        public static string SplitUpperCaseToString(this string source)
        {
            if (source == null)
            {
                return null;
            }
            return string.Join(" ", SplitUpperCaseToWords(source));
        }

        /// <summary>
        /// Splits upper case word to a array of words
        /// </summary>
        [NotNull]
        public static string[] SplitUpperCaseToWords(this string source)
        {
            if (source == null)
            {
                return new string[] { };
            }

            if (source.Length == 0)
            {
                return new[] { string.Empty };
            }

            var words = new List<string>();
            var wordStartIndex = 0;

            var letters = source.ToCharArray();
            var previousChar = char.MinValue;

            // skip the first letter. we don't care what case it is
            for (var i = 1; i < letters.Length; i++)
            {
                if (char.IsUpper(letters[i]) && !char.IsUpper(previousChar) && !char.IsWhiteSpace(previousChar))
                {
                    // grab everything before the current index
                    words.Add(new string(letters, wordStartIndex, i - wordStartIndex));
                    wordStartIndex = i;
                }
                previousChar = letters[i];
            }

            // get last word
            words.Add(new string(letters, wordStartIndex, letters.Length - wordStartIndex));

            return words.ToArray();
        }
    }
}
