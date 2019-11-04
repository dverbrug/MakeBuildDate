using System;
using System.IO;
using System.Globalization;

namespace MakeBuildDate
{
    class Program
    {
        static private readonly string[] lines = {
            "0using System;",
            "0namespace BuildInfo",
            "0{",
            "0   public static partial class Constants",
            "0   {",
            "1       public static DateTime CompilationTimestampUtc {{ get {{ return new DateTime({0}L, DateTimeKind.Utc); }} }}",
            "2       public static DateTime CompilationTimestampLocal {{ get {{ return new DateTime({0}L, DateTimeKind.Local); }} }}",
            "0   }",
            "0}"
            };

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine($"Use {System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName} -- Output-file-path");
            }
            else
            {
                string output_file_name = args[0];
                string utcTime = DateTime.UtcNow.Ticks.ToString(CultureInfo.InvariantCulture);
                string localTime = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);

                Console.WriteLine($"Writing build date file to {Path.GetFullPath(output_file_name)}");

                // Write the string array to a new file named "WriteLines.txt".
                using (StreamWriter outputFile = new StreamWriter(output_file_name))
                {
                    foreach (string line in lines)
                    {
                        switch (line[0])
                        {
                            case '0': outputFile.WriteLine(line.Substring(1)); break;
                            case '1': outputFile.WriteLine(string.Format(CultureInfo.InvariantCulture, line.Substring(1), utcTime)); break;
                            case '2': outputFile.WriteLine(string.Format(CultureInfo.InvariantCulture, line.Substring(1), localTime)); break;
                        }
                    }
                }
                Console.WriteLine("Build date file written");
            }
        }
    }
}
