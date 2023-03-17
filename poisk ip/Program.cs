using System.Text.RegularExpressions;
internal class Program
{
    static string path = "C:/Users/DELL/Desktop/145.txt";
    private static void Main(string[] args)
    {

        StreamReader fIn = new(path);

        string buffer;

        buffer = fIn.ReadToEnd();

        Console.WriteLine(buffer);

        Regex regexIp = new(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");

        Console.WriteLine("Истинные айпишники:");

        MatchCollection matches = regexIp.Matches(buffer);
        if (matches.Count > 0)
            foreach (Match match in matches.Cast<Match>())
                Console.WriteLine(match.Value);
        else
            Console.WriteLine("Совпадений не найдено");

        fIn.Close();
    }
}