using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using PeepoSetup.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using PeepoSetup.Helpers;
using PeepoSetup.Types.Exceptions;
using Serilog;

namespace PeepoSetup.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel
{
    [ObservableProperty] private RealValueSetup? _setup1;

    [ObservableProperty] private RealValueSetup? _setup2;

    [ObservableProperty] private string? _setup1Name;

    [ObservableProperty] private string? _setup2Name;

    public string? AppVersion { get; } = Assembly.GetExecutingAssembly().GetName().Version?.ToString();

    [RelayCommand]
    private void LoadSetup1()
    {
        var path = ShowFileSelection();
        if (path is null or "") return;

        try
        {
            Setup1 = SetupConverter.LoadSetup(path);
            Setup1Name = Path.GetFileNameWithoutExtension(path);
        }
        catch (CarDataNotFoundException)
        {
            ShowAndLogError("Failed to load car data, the car isn't supported yet");
        }
        catch (LoadSetupException)
        {
            ShowAndLogError("Failed to load setup file, the file had an invalid format");
        }
        catch (Exception e)
        {
            ShowAndLogError(e);
        }
    }

    [RelayCommand]
    private void LoadSetup2()
    {
        var path = ShowFileSelection();
        if (path is null or "") return;

        try
        {
            Setup2 = SetupConverter.LoadSetup(path);
            Setup2Name = Path.GetFileNameWithoutExtension(path);
        }
        catch (Exception e)
        {
            ShowAndLogError(e);
        }
    }

    private static string? ShowFileSelection()
    {
        var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var setupFolder = Path.Combine(documentsFolder, "Assetto Corsa Competizione", "Setups");

        var initialFolder = Directory.Exists(setupFolder) ? setupFolder : documentsFolder;

        var dialog = new OpenFileDialog
        {
            InitialDirectory = initialFolder,
            Filter = "JSON files | *.json"
        };

        return dialog.ShowDialog() == true ? dialog.FileName : null;
    }

    private static void ShowAndLogError(Exception e)
    {
        var text = $"{e.Message}\n{e.StackTrace?.Split("\n").FirstOrDefault()}";
        Log.Debug("{Error}", text);
        MessageBox.Show(text, "Unexpected error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    private static void ShowAndLogError(string message, string caption = "Error")
    {
        Log.Debug("{Error}", message);
        MessageBox.Show($"{message}", caption, MessageBoxButton.OK, MessageBoxImage.Error);
    }
}