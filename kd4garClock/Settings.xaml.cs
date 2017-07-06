using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace kd4garClock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {

        SaveSettings settings;
        public Settings()
        {
            this.InitializeComponent();
            settings = new SaveSettings();
            sw24hour.IsOn = settings.Show24Hour;
        }

        void AlarmBarButton_Click(object sender, RoutedEventArgs e)
        {
           

        }


        void TurnOffAlarm_Click(object sender, RoutedEventArgs e)
        {
            App.AlarmSound.Stop();
            btnStopAlarm.Visibility = Visibility.Collapsed;

        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            settings.Show24Hour = sw24hour.IsOn;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void WifIButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        
    }
}
