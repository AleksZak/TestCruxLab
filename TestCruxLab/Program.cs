using TestCruxLab;

var provider = new PasswordValidationProvider();

var parsedTxt = provider.ParseTextFile("cruxlabtxt.txt");

var count = provider.GetListOfValidPasswords(parsedTxt);

Console.WriteLine($"Password matches {count} times");

Console.ReadLine();