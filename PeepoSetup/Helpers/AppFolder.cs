using System;
using System.IO;

namespace PeepoSetup.Helpers;

public static class AppFolder
{
    private const string AppName = "PeepoSetup";
    public static string Location { get; } = CreateAppFolder();

    public static string CreateFolder(string name)
    {
        return Directory.CreateDirectory(Path.Combine(Location, name)).FullName;
    }

    public static bool DirectoryExist(string name)
    {
        return Directory.Exists(Path.Combine(Location, name));
    }

    private static string CreateAppFolder()
    {
        var localData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var folder = Path.Combine(localData, AppName);
        Directory.CreateDirectory(folder);
        return folder;
    }
}