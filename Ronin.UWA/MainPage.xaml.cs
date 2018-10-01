using Ronin.UWA.Controls;
using Ronin.UWA.Pages;
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

namespace Ronin.UWA
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(
                new Size(
                    320, // Width
                    250 // Height
                    )
                );
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // you can also add items in code behind
            NavView.MenuItems.Add(new NavigationViewItemSeparator());
            NavView.MenuItems.Add(new NavigationViewItem()
            { Content = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content" });

            // set the initial SelectedItem 
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "apps")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            //if (args.IsSettingsInvoked)
            //{
            //    ContentFrame.Navigate(typeof(SettingsPage));
            //}
            //else
            //{
            switch (args.InvokedItem)
            {
                case "Home":
                    ContentFrame.Navigate(typeof(test));
                    break;

                case "Members":
                    ContentFrame.Navigate(typeof(MembersPage));
                    break;

                case "Diary":
                    ContentFrame.Navigate(typeof(DiaryPage));
                    break;

                case "Music":
                    ContentFrame.Navigate(typeof(test));
                    break;

                case "My content":
                    ContentFrame.Navigate(typeof(test));
                    break;
            }
            //}
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            //if (args.IsSettingsSelected)
            //{
            //    ContentFrame.Navigate(typeof(SettingsPage));
            //}
            //else
            //{

            NavigationViewItem item = args.SelectedItem as NavigationViewItem;

            switch (item.Tag)
            {
                case "home":
                    ContentFrame.Navigate(typeof(test));
                    break;


                case "Members":
                    ContentFrame.Navigate(typeof(MembersPage));
                    break;

                case "games":
                    ContentFrame.Navigate(typeof(test));
                    break;

                case "music":
                    ContentFrame.Navigate(typeof(test));
                    break;

                case "content":
                    ContentFrame.Navigate(typeof(test));
                    break;
            }
            //}
        }
    }
}
