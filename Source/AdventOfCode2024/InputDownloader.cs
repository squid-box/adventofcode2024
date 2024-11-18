﻿namespace AdventOfCode2024;

using System;
using System.IO;
using System.Net;
using System.Net.Http;

using AdventOfCode2024.Utils.Extensions;

using Spectre.Console;

/// <summary>
/// Utility for downloading daily input.
/// </summary>
public class InputDownloader : IDisposable
{
    private const string SessionCookieFilename = "session.cookie";
    private readonly string _inputFolder = Path.Combine("..", "..", "Inputs");
    private readonly HttpClientHandler _httpClientHandler;

    public InputDownloader()
    {
        if (!File.Exists(SessionCookieFilename))
        {
            AnsiConsole.MarkupLine($"[red]Unable to find session cookie file \"{SessionCookieFilename}\", unable to download input automatically.[/]");
            return;
        }

        _httpClientHandler = new HttpClientHandler();
        _httpClientHandler.CookieContainer.Add(new Cookie("session", File.ReadAllText(SessionCookieFilename), "/", "adventofcode.com"));
    }

    /// <inheritdoc />
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _httpClientHandler?.Dispose();
    }

    public void DownloadDay(int day)
    {
        var year = DateTime.Today.Year;
        var inputFilePath = Path.Combine(_inputFolder, $"{day}.input");

        // Invalid day, or file already exists: Abort.
        if (!day.IsWithin(1, 25) || File.Exists(inputFilePath) || _httpClientHandler == null || DateTime.Today < new DateTime(year, 12, day))
        {
            return;
        }

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(inputFilePath));

            using var httpClient = new HttpClient(_httpClientHandler);
            var input = httpClient.GetStringAsync($"https://adventofcode.com/{year}/day/{day}/input").Result;
            File.WriteAllText(inputFilePath, input);
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error while downloading input for {day}: {ex.GetType()}: {ex.Message}[/]");
        }
    }
}