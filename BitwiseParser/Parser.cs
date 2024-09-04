namespace BitwiseParser
{
    static class StringParser
    {
        public static IEnumerable<string> SplitLines(string input) {
            if (string.IsNullOrEmpty(input)) 
            {
                yield break;
            }

            using (StringReader reader = new StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}