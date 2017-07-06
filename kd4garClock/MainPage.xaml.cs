using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace kd4garClock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer dispatcherTimer;
       
        SaveSettings Settings;

        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        //public void SnoozeButtonSetup()
        //{
        //    snoozeButton = new AppBarButton();
        //    snoozeButton.Icon = new SymbolIcon(Symbol.Mute);
        //    snoozeButton.Name = "btnSnooze";
        //    snoozeButton.Label = "SNOOZE!";
        //    snoozeButton.Click += SnoozeBarButton_Click;
        //    snoozeButton.Foreground = new SolidColorBrush(Colors.Red);

        //}

        public MainPage()
        {
            this.InitializeComponent();
            Settings = new SaveSettings();
            // mainTime.Text = DateTime.Now.ToString("t");
            DispatcherTimerSetup();
            // SnoozeButtonSetup();
            App.AlarmSound = new MediaElement();

        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            if (Settings.Show24Hour)
            {
                mainTime.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mainTime.Text = DateTime.Now.ToString("T");
            }

            mainDate.Text = DateTime.Now.ToString("D");
        }
        private async void SoundAlarm()
        {
            var folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            var file = await folder.GetFileAsync("Wake-up-sounds.mp3");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            App.AlarmSound.SetSource(stream, "");
            App.AlarmSound.Play();
            btnStopAlarm.Visibility = Visibility.Visible;
        }
        void AlarmBarButton_Click(object sender, RoutedEventArgs e)
        {
            //TESTING
            SoundAlarm();


        }

        void TurnOffAlarm_Click(object sender, RoutedEventArgs e)
        {
            App.AlarmSound.Stop();
            btnStopAlarm.Visibility = Visibility.Collapsed;

        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.ApplicationModel.Core.CoreApplication.Exit();
        }

        
    }

}
