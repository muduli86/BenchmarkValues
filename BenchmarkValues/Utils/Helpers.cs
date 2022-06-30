using System.IO;
using System.Reflection;

namespace BenchmarkValues.Utils
{
    internal static class Helpers
    {
        public static string BuildResponse(string resourceFileName) {
            using var stream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream($"BenchmarkValues.Mocks.{resourceFileName}");
            if (stream == null)
                throw new FileNotFoundException("Embedded file not found. " +
                                                "Check from file properties that the file build action is " +
                                                "'Embedded resource'", resourceFileName);

            using var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();

            return result;
        }
    }
}