﻿using System;
using System.IO;
using PeepoSetup.ViewModels;
using System.Windows;
using AutoUpdaterDotNET;
using PeepoSetup.Helpers;
using Serilog;

namespace PeepoSetup
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int MaxLogFiles = 5;
        
        protected override void OnStartup(StartupEventArgs e)
        {
            Current.Exit += OnApplicationExit;
            
            var logDir= AppFolder.CreateFolder("logs");
            
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Debug()
                .WriteTo.File(Path.Combine(logDir, $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log"))
                .CreateLogger();

            DeleteOldLogsFiles(logDir);
            
            Log.Information("PeepoSetup starting");
            
            AutoUpdater.Start("http://13.38.87.128/update.xml");

            MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(),
            };
            
            MainWindow.Show();
            Log.Information("PeepoSetup started");
        
            base.OnStartup(e);
        }

        private static void DeleteOldLogsFiles(string logDir)
        {
            var files = Directory.GetFiles(logDir);
            if (files.Length < MaxLogFiles) return;
            
            foreach (var file in files[..^MaxLogFiles])
            {
                Log.Information($"Deleting log file: {file}");   
                File.Delete(file);
            }
        }

        private static void OnApplicationExit(object? obj, ExitEventArgs args)
        {
            Log.Information("PeepoSetup closed");
            Log.CloseAndFlush();
        }
    }
}