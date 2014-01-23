using System;
using System.Net;
using System.Text;

namespace TCC2.API
{
    public static class RequestLogHelper
    {
        public static void LogRequestURL(string type, Uri uri)
        {
            LogNewLine();
            Log.Instance.WriteCurrentDateTime();
            Log.Instance.WriteLine(type + " REQUEST");
            Log.Instance.WriteLineFormatted("URL: {0}", MaskPassword(uri.ToString()));
        }

        public static void LogRequestParameters(WebHeaderCollection headers)
        {
            foreach (string key in headers)
            {
                Log.Instance.WriteLineFormatted("{0}: {1}", key, headers[key]);
            }
        }

        public static void LogRequestParameter(string line)
        {
            LogNewLine();
            Log.Instance.WriteLine(MaskPassword(line));
        }

        public static void LogResponseTitle()
        {
            LogNewLine();
            Log.Instance.WriteCurrentDateTime();
            Log.Instance.WriteLine("RESPONSE");
        }

        public static void LogBytes(byte[] buffer, int offset, int count)
        {
            Log.Instance.Write(buffer, offset, count);
        }

        public static void LogNewLine()
        {
            Log.Instance.Write("\n");
        }

        static string MaskPassword(string line)
        {
            const string passwordKey = "password=";
            int index = line.IndexOf(passwordKey, StringComparison.Ordinal);
            if (index < 0)
                return line;

            index += passwordKey.Length;

            StringBuilder result = new StringBuilder(line, 0, index, line.Length);

            for (int i = index; i < line.Length; ++i)
            {
                if (line[i] == '&')
                {
                    result.Append(line, i, line.Length - i);
                    break;
                }
                result.Append('*');
            }

            return result.ToString();
        }
    }
}
