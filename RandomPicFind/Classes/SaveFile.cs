using System.Collections.Generic;
using System.Net;

namespace RandomPicFind.Classes
{
    internal class SaveFile
    {
        public void SaveFileInFolder(string format, string link)
        {
            Dictionary<string, string> formatFilter = new()
            {
                 {"gif", "Image Files(*.GIF)|*.GIF|All files (*.*)|*.*"},
                 {"webm", "Image Files(*.WEBM)|*.WEBM|All files (*.*)|*.*"}
            };

            Microsoft.Win32.SaveFileDialog dlg = new();
            dlg.FileName = "Random"; // Default file name
            dlg.DefaultExt = $".{format}"; // Default file extension
            dlg.Filter = formatFilter[format]; // Filter files by extension

            // Show save file dialog box
            bool? result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                //Save gif in folder
                using (WebClient web = new())
                {
                    web.DownloadFile(link, dlg.FileName);
                }
            }
        }
    }
}
