using Newtonsoft.Json;
using Ronin.Obj;
using Ronin.UWA.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Ronin.UWA.Controls
{
    public sealed partial class MembersControl : UserControl, INotifyPropertyChanged
    {
        public event ItemClickEventHandler ItemClick;
        //CollectionViewSource membersCollection = new CollectionViewSource() { IsSourceGrouped= true,   };

        public object SelectedItem
        {
            get
            {
                return lstMembers.SelectedItem;
            }
            set
            {
                lstMembers.SelectedItem = value;
            }
        }

        //public ListViewSelectionMode SelectionMode { get { return lstMembers.SelectionMode; } set { lstMembers.SelectionMode = value; } }


        public ListViewSelectionMode SelectionMode
        {
            get { return (ListViewSelectionMode)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); lstMembers.SelectionMode = value; }
        }

        // Using a DependencyProperty as the backing store for SelectionMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectionModeProperty =
            DependencyProperty.Register("SelectionMode", typeof(ListViewSelectionMode), typeof(MembersControl), null);



        public IEnumerable<Member> Items { get {return (IEnumerable<Member>)GetValue(ItemsProperty); } set {SetValue(ItemsProperty,value); } }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(MembersControl), null);
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(IEnumerable<Member>), typeof(MembersControl), null);

        //Windows.Web.Http.HttpResponseMessage operProg;
        //ObservableCollection<Member> _members = new ObservableCollection<Member>();

        public MembersControl()
        {
            this.InitializeComponent();
            //lstMembers.ItemsSource = _members;
            //var operProg = App.HttpClient.GetAsync(new Uri(App.BaseApiUrl + "Member"), Windows.Web.Http.HttpCompletionOption.ResponseContentRead);
            //operProg.Completed = (x, y) =>
            //{
            //    var JSONResult = x.GetResults();
            //    var ms = JsonConvert.DeserializeObject<IEnumerable<Member>>(JSONResult.Content.ToString());

            //    lstMembers.ItemsSource = ms;
            //};            
            LoadData();
        }

        public async void LoadData()
        {
            progress1.Visibility = Visibility.Visible;
            Items = await RESTApiClient.GetAsync<Member>();
            //lstMembers.ItemsSource = Items;
            //var ttt = from t in Items
            //                    group t by t.LastName.Substring(0, 1) into g
            //                    orderby g.Key
            //                    select g;
            membersCVS.Source = Items.GroupBy(x => x.LastName.Substring(0, 1).ToUpper());
            //membersCVS.Source = Items.GroupBy(x => x.Name.Substring(0, 1).ToUpper(), (alphabet, subList) => new { Alphabet = alphabet, SubList = subList.OrderBy(x => x.Name).ToList() })                .OrderBy(x => x.Alphabet);
            progress1.Visibility = Visibility.Collapsed;
        }

        private void LstMembers_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ItemClick != null)
                ItemClick(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void LstMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
        }

        public void AddMember()
        {

        }

    }
}
