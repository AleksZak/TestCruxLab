namespace TestCruxLab
{
    public class PasswordValidationProvider
    {
        public int GetListOfValidPasswords(List<PasswordValidationString> validationStrings)
        {
            var result = new List<bool>();

            foreach (PasswordValidationString validationString in validationStrings)
            {
                var count = validationString.Password.Count(x => x == validationString.Symbol);

                result.Add(validationString.CountRange.Any(x => x == count));
            }

            return result.Count(x => x == true);
        }

        public List<PasswordValidationString> ParseTextFile(string path)
        {
            var validationStrings = new List<PasswordValidationString>();

            var stringList = File.ReadAllLines(path).ToList();
           
            if (stringList.Count < 1)
            {
                throw new Exception("File is empty");
            }

            foreach (var str in stringList)
            {
                var password = str.Split(":").Last();
                var numsList = str.Split(":").First().Remove(0, 2).Split("-") ?? throw new Exception("Uncorrect format");
                var intList = new List<int>();

                for (var i = int.Parse(numsList.First()); i <= int.Parse(numsList.Last()); i++)
                {
                    intList.Add(i);
                }

                validationStrings.Add(new PasswordValidationString { Symbol = str.First(), CountRange = intList, Password = password });
            }

            return validationStrings;
        }
    }
}
