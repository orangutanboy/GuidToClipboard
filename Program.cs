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
                new AboutBox().ShowDialog();
                return;
            }

            if (format.Length > 1)
            {
                format = "";
            }

            if (!"NDBPX".Contains(format))
            {
                format = "";
            }

            if (format == "")
            {
                try
                {
                    format = (string)(new AppSettingsReader().GetValue("Format", typeof(string)));
                }
                catch (InvalidOperationException)
                { 
                }
            }

            Clipboard.SetText(System.Guid.NewGuid().ToString(format));
        }
    }
}
