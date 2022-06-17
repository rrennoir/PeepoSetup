using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace PeepoSetup.Helpers;

public static class JsonHelper
{
    public static T? LoadJson<T>(string path)
    {

        if (!File.Exists(path))
        {
            return default;
        }

        var jsonText = File.ReadAllText(path);

        T? data = default;
        try
        {
            data = JsonConvert.DeserializeObject<T>(jsonText);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return data;
    }
}
