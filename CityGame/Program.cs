class Program
{
    public static void Main()
    {
        // санкт-Петербург -> гётеборг -> геленджик -> казань -> нижний Новгород -> домодедово -> орёл -> ледокол -> люберцы

        var game = new CityGame.CityGame();
        var res = game.Solve(test, test);

        var test1 = GenerateTest(370);
        var shuf = Shuffle(test1);
        var res2 = game.Solve(shuf, test1);
        var equal = test1.Select((e, i) => i == 0 ? true : test1[i - 1][1] == e[0]).All(x => x);
    }

    private static string[] test =
    {
        "геленджик",
        "домодедово",
        "казань",
        "люберцы",
        "нижний Новгород",
        "орёл",
        "ледокол",
        "санкт-Петербург",
        "гётеборг"
    };

    private static string[] GenerateTest(int count)
    {
        var rnd = new Random((int)DateTime.Now.Ticks);
        var first = (char)rnd.Next('a', 'z' + 1);
        var res = new string[count];
        for (int i = 0; i < count; i++)
        {
            var last = (char)rnd.Next('a', 'z' + 1);
            res[i] = $"{first}{last}";
            first = last;
        }

        return res;
    }

    private static string[] Shuffle(string[] arr)
    {
        var res = arr.ToArray();
        var rnd = new Random((int)DateTime.Now.Ticks);
        for (int i = 0; i < res.Length; i++)
        {
            int j = rnd.Next(0, res.Length);
            (res[i], res[j]) = (res[j], res[i]);
        }

        return res;
    }
}