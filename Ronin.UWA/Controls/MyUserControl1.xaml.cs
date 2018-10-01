using Ronin.Obj;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Ronin.UWA.Controls
{
    public sealed partial class MyUserControl1 : UserControl
    {
        public Member MemberData
        {
            get { return (Member)GetValue(MemberProperty); }
            set
            {
                SetValue(MemberProperty, value);
                DataContext = value;
            
            }
        }

        // Using a DependencyProperty as the backing store for Member.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MemberProperty =
            DependencyProperty.Register("Member", typeof(Member), typeof(MemberDetailsControl), null);

        public MyUserControl1()
        {
            this.InitializeComponent();
        }
    }
}
