using Ronin.Obj;
using Ronin.UWA.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Ronin.UWA.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditMemberPage : Page
    {
        public string[] GenderValues = Enum.GetNames(typeof(Gender));

        public Status[] MemberStatus = new Status[]
        {new Status() { Id =1  ,Name ="Attivo" },
new Status() { Id =2  ,Name ="Decaduto"},
new Status() { Id =3  ,Name ="Deceduto"},
new Status() { Id =4  ,Name ="Espulso" }
        };

        public bool isNew { get; set; } = false;


        public EditMemberPage()
        {
            this.InitializeComponent();

        }

        public Member Member
        {
            get { return (Member)GetValue(MemberProperty); }
            set { SetValue(MemberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Member.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MemberProperty =
            DependencyProperty.Register("Member", typeof(Member), typeof(EditMemberPage), null);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isNew)
            {
                var retVal = RESTApiClient.PostAsync<Member>(Member);
            }
            else {
                var retVal = RESTApiClient.PutAsync<Member>(Member);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Parameter is item ID
            //Item = new Member() { Name = "Test", LastName = "Test" };//ItemViewModel.FromItem(ItemsDataSource.GetItemById((int)e.Parameter));
            if (e.Parameter != null)
                if (e.Parameter.GetType() == typeof(Member))
                    Member = (Member)e.Parameter;
            if (Member == null)
            {
                Member = new Member() { Address = new Address() };
                isNew = true;
            }
            var backStack = Frame.BackStack;
            var backStackCount = backStack.Count;

            if (backStackCount > 0)
            {
                var masterPageEntry = backStack[backStackCount - 1];
                backStack.RemoveAt(backStackCount - 1);

                // Doctor the navigation parameter for the master page so it
                // will show the correct item in the side-by-side view.
                var modifiedEntry = new PageStackEntry(
                    masterPageEntry.SourcePageType,
                    Member.Id,
                    masterPageEntry.NavigationTransitionInfo
                    );
                backStack.Add(modifiedEntry);
            }

            // Register for hardware and software back request from the system
            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += EditMemberPage_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            SystemNavigationManager systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested -= EditMemberPage_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void EditMemberPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            // Mark event as handled so we don't get bounced out of the app.
            e.Handled = true;

            OnBackRequested();
        }

        private void OnBackRequested()
        {
            // Page above us will be our master view.
            // Make sure we are using the "drill out" animation in this transition.

            Frame.GoBack(new DrillInNavigationTransitionInfo());
        }
    }
}
