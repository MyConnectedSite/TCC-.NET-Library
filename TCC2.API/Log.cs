using System;
using System.Globalization;
using System.IO;

namespace TCC2.API
{
    class Log : IDisposable
    {
        static Log m_Instance;
        Stream m_Stream;
        bool m_Enabled = false;
        bool m_AlreadyDisposed = false;

        Log()
        {
        }

        public void Dispose()
        {
            if (m_AlreadyDisposed)
                return;

            if (m_Stream != null)
            {
                m_Stream.Dispose();
                m_Stream = null;
            }

            m_AlreadyDisposed = true;
        }

        public static Log Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new Log();

                return m_Instance;
            }
        }

        public bool Enabled
        {
            get { return m_Enabled; }
        }

        public void Enable()
        {
            if (m_Enabled)
                return;

            m_Enabled = true;
            m_Stream = new FileStream("TCC2.API.log.txt", FileMode.Append);
            WriteCurrentDateTime();
            WriteLine("LOGGING STARTED");
        }

        public void Disable()
        {
            if (!m_Enabled)
                return;

            m_Enabled = false;

            if (m_Stream != null)
            {
                WriteLine("LOGGING DISABLED");
                m_Stream.Dispose();
                m_Stream = null;
            }
        }

        public void Write(byte[] buffer)
        {
            Write(buffer, 0, buffer.Length);
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            if (m_Stream == null)
                return; //logging disabled

            m_Stream.Write(buffer, offset, count);
        }

        public void Write(string message)
        {
            WriteString(message);
        }

        public void WriteLine(string message)
        {
            Write(message + "\n");
        }

        public void WriteFormatted(string format, params object[] args)
        {
            Write(String.Format(CultureInfo.InvariantCulture, format, args));
        }

        public void WriteLineFormatted(string format, params object[] args)
        {
            WriteLine(String.Format(CultureInfo.InvariantCulture, format, args));
        }

        public void WriteCurrentDateTime()
        {
            string currentTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            WriteFormatted("[{0}] ", currentTime);
        }

        void WriteString(string message)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(message);
            Write(buffer);
        }
    }
}
