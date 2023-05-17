string[] arguments = Environment.GetCommandLineArgs();

if (arguments.Length < 3)
{
    Console.WriteLine("NOT ENOUGH ARGUMENTS");
    Console.WriteLine(
        "USE THIS TEMPLATE TO START THE PROGRAM:" +
        "\n[dotnet run] [copy from] [copy to] [OPTIONAL: files extension (ex: .txt, .exe)]");
    Environment.ExitCode = 1;
    return;
}

string copyFrom = arguments[1];
string copyTo = arguments[2];
int copiedFiles = 0;

if (!Directory.Exists(copyFrom))
{
    Console.WriteLine($"A [copy from] DIRECTORY DOES NOT EXIST - {copyFrom}");
    Environment.ExitCode = 1;
    return;
}
else if (!Directory.Exists(copyTo))
{
    Console.WriteLine($"A [copy to] DIRECTORY DOES NOT EXIST - {copyTo}");
    Environment.ExitCode = 1;
    return;
}

if (arguments.Length == 3)
{
    string[] filesToCopy = Directory.GetFiles(copyFrom);

    if (filesToCopy.Length == 0)
    {
        Console.WriteLine("[copy from] DIRECTORY IS EMPTY");
        Environment.ExitCode = 0;
        return;
    }

    foreach (string file in filesToCopy)
    {
        File.Copy(file, Path.Combine(copyTo, Path.GetFileName(file)));
        copiedFiles++;
    }
    Console.WriteLine($"{copiedFiles} FILES COPIED SUCCESSFULLY");
    Environment.ExitCode = 0;
    return;
}
else if (arguments.Length == 4)
{
    string extension = arguments[3];
    string[] filesToCopy = Directory.GetFiles(copyFrom, $"*{extension}");

    if (filesToCopy.Length == 0)
    {
        Console.WriteLine(
            $"[copy from] DIRECTORY DOES NOT CONTAIN ANY FILES WITH {extension} EXTENSION");
        Environment.ExitCode = 0;
        return;
    }

    foreach (string file in filesToCopy)
    {
        File.Copy(file, Path.Combine(copyTo, Path.GetFileName(file)));
        copiedFiles++;
    }
    Console.WriteLine($"{copiedFiles} FILES COPIED SUCCESSFULLY");
    Environment.ExitCode = 0;
    return;
}
else
{
    Console.WriteLine("TOO MANY AGRUMENTS");
    Environment.ExitCode = 0;
    return;
}
