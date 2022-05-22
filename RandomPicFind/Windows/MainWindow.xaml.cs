using Newtonsoft.Json;
using RandomPicFind.Classes;
using System;
using System.Net;
using System.Text;
using System.Windows;

namespace RandomPicFind.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new();
        SaveFile saveFile = new();
        string gifLink, webmLink;
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel properties = (MainViewModel)DataContext;
            try
            {
                Rootobject context = null;
                using (WebClient web = new WebClient())
                {
                    web.Encoding = Encoding.UTF8;
                    WordObject wordObject = new();
                    bool go = true;
                    do
                    {
                        string word = await wordObject.FindRandomWordAsync();
                        string response = web.DownloadString(@$"https://g.tenor.com/v1/search?q={word}&key=LIVDSRZULELA&limit=1000");
                        context = JsonConvert.DeserializeObject<Rootobject>(response);
                        int gifCount = context.results.Length - 1;
                        if (gifCount > 0)
                        {
                            //Get random object
                            var result = context.results[random.Next(gifCount)];
                            //Get gif url
                            gifLink = result.media[0].gif.url;
                            //Get webm url
                            webmLink = result.media[0].webm.url;
                            //Check webm access
                            if (webmLink == null) properties.WebmBtnEnable = false;
                            else properties.WebmBtnEnable = true;



                            properties.ImageUrl = gifLink;
                            go = false;
                        }
                    }
                    while (go);


                    //var bgcolor = context.results[1].media[0].gif.dims;
                    //В историю идёт: 
                    //var previewImg = context.results[1].media[0].gif.preview; //превьюшка
                    //var bgcolor3 = context.results[1].media[0].gif.size; //вес в байтах
                    //var bgcolor5 = context.results[1].tags[0];
                    //var bgcolor7 = context.results[1].title; 
                    //var bgcolor8 = context.results[1].hasaudio; //есть ли звук
                    //var bgcolor9 = context.results[1].content_rating;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
        private void WebmSaveBtn_Click(object sender, RoutedEventArgs e) =>
            saveFile.SaveFileInFolder("webm", webmLink);
        
        private void GifSaveBtn_Click(object sender, RoutedEventArgs e) =>
            saveFile.SaveFileInFolder("gif", gifLink);
    }
}
