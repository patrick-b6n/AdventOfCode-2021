using System.IO;
using System.Reflection;

namespace AdventOfCode2021;

public static class TestHelper
{
    public static string ReadEmbeddedFile(Assembly assembly, string filePath)
    {
        var name = $"{assembly.GetName().Name}.{filePath}";

        using (var stream = assembly.GetManifestResourceStream(name))
        {
            if (stream == null)
            {
                throw new FileNotFoundException();
            }

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}