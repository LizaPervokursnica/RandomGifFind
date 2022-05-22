using System.Collections.Generic;
using System.Net;

namespace RandomPicFind.Classes;
public class SaveFile
{
    /// <summary>
    /// This method downloads and saves the file by link.
    /// </summary>
    /// <param name="format">File format</param>
    /// <param name="link">File link</param>
    public void SaveFileInFolder(string format, string link)
    {
        Dictionary<string, string> formatFilter = new()
            {
                 {"gif", "Image Files(*.GIF)|*.GIF|All files (*.*)|*.*"},
                 {"webm", "Image Files(*.WEBM)|*.WEBM|All files (*.*)|*.*"}
            };

        // Default file name, file extension, filter files by extension
        Microsoft.Win32.SaveFileDialog dlg = new()
        { FileName = "Random", DefaultExt = $".{format}", Filter = formatFilter[format] };

        // Process save file dialog box results
        if (dlg.ShowDialog() == true)
        {
            //Save file in folder
            using (WebClient web = new())
                web.DownloadFile(link, dlg.FileName);
        }
    }
}