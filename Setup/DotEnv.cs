namespace Majorro.Common.Setup;

public static class DotEnv
{
    public static bool TryLoad(string filePath = "../../.env")
    {
        if (!File.Exists(filePath))
            return false;

        var lines = File.ReadAllLines(filePath)
            .Where(x => !string.IsNullOrWhiteSpace(x) && !x.StartsWith('#'));

        foreach (var line in lines)
        {
            var parts = line.Split(
                '=',
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                continue;

            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }

        return true;
    }
}