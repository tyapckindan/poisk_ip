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

        Regex regexIp = new(@"\b(?:(?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.){3}(?:25[0-5]|2[0-4]\d|[01]?\d\d?)\b");

        Console.WriteLine("Истинные айпишники: ");

        MatchCollection matches = regexIp.Matches(buffer);
        if (matches.Count > 0)
            foreach (Match match in matches.Cast<Match>())
                Console.WriteLine(match.Value);
        else
            Console.WriteLine("Совпадений не найдено");


        Regex regexMask255 = new(@"(^255\.|\.255\.|\.255$)");
        Regex regexMask0 = new(@"(^0\.|\.0\.|\.0$)");

        Console.WriteLine("\nМаска: ");
        List<string> ip = new();
        for(int i = 0; i < matches.Count; i++) ip.Add(matches[i].Value);

        for(int i = 0; i < ip.Count;i++)
            if (!regexMask255.IsMatch(ip[i]) | !regexMask0.IsMatch(ip[i]))
            {
                ip.RemoveAt(i);
                i--;
            }

        foreach (string mask in ip) Console.WriteLine(mask);

        fIn.Close();
    }
}