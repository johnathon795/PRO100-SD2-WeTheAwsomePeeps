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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TheAwesomeClicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //upgradesListBox.ItemsSource = GetUpgradeButtons();
        }

        //Creates and organizes data fields from upgrade list and returns the formatted buttons
        public List<Button> GetUpgradeButtons()
        {
            List<Button> buttons = new List<Button>();
            foreach (Button b in buttons)
            {
                
            }

            return buttons;
        }

        private void Clicker_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
