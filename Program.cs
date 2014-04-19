using System;
using System.Configuration;
using System.Windows.Forms;

namespace GuidToClipboard
{
    class Program
    {
        [System.STAThread]
        static void Main(string[] args)
        {
            var format = "";

            if (args.Length > 0)
            {
                format = args[0];
            }

            if (format.Contains("?"))
            {
                ShowAboutBox();
                return;
            }

            if (IsValid(format))
            {
                WriteGuidToClipboard(format);
                return;
            }

            try
            {
                format = (string)(new AppSettingsReader().GetValue("Format", typeof(string)));
            }
            catch (InvalidOperationException)
            {
            }
        
            if (!IsValid(format))
            {
                format = "";
            }
            
            WriteGuidToClipboard(format);
        }

        private static void ShowAboutBox()
        {
            new AboutBox().ShowDialog();
        }

        private static bool IsValid(string format)
        {
            if (format == "")
            {
                return false;
            }

            if (format.Length > 1)
            {
                return false;
            }

            if (!"NDBPX".Contains(format))
            {
                return false;
            }

            return true;
        }

        private static void WriteGuidToClipboard(string format)
        {
            Clipboard.SetText(System.Guid.NewGuid().ToString(format));
        }
    }
}
