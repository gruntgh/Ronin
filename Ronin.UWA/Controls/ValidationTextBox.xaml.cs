using Microsoft.Toolkit.Uwp.UI.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static Microsoft.Toolkit.Uwp.UI.Extensions.TextBoxRegex;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Ronin.UWA.Controls
{
    public sealed partial class ValidationTextBox : UserControl//, INotifyPropertyChanged
    {
        //          InputScope="TelephoneNumber"



        public InputScope InputScope
        {
            get { return (InputScope)GetValue(InputScopeProperty); }
            set { SetValue(InputScopeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputScopeProperty =
            DependencyProperty.Register("InputScope", typeof(InputScope), typeof(ValidationTextBox), null);



        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceholderText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register("PlaceholderText", typeof(string), typeof(ValidationTextBox), null);




        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ValidationTextBox), null);


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ValidationTextBox), null);



        public ValidationMode ValidationMode
        {get;set;
            //get { return (ValidationMode)GetValue(ValidationModeProperty); }
            //set { SetValue(ValidationModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidationModeProperty =
            DependencyProperty.Register("ValidationMode", typeof(ValidationMode), typeof(ValidationTextBox), null);



        public ValidationType ValidationType
        {
            get { return (ValidationType)GetValue(ValidationTypeProperty); }
            set { SetValue(ValidationTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValidationType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidationTypeProperty =
            DependencyProperty.Register("ValidationType", typeof(ValidationType), typeof(ValidationTextBox), null);



        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsValid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsValidProperty =
            DependencyProperty.Register("IsValid", typeof(bool), typeof(ValidationTextBox), new PropertyMetadata(null, OnPropertyChanged));



        public bool IsNotValidState
        {
            get { return (bool)GetValue(IsNotValidStateProperty); }
            set { SetValue(IsNotValidStateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsNotValidState.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsNotValidStateProperty =
            DependencyProperty.Register("IsNotValidState", typeof(bool), typeof(ValidationTextBox), null);

        protected bool _showValidation = false;

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ValidableTextBox vtb = d as ValidableTextBox;
            bool b = (bool)e.NewValue;

        }



        public string Regex
        {
            get { return (string)GetValue(RegexProperty); }
            set { SetValue(RegexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Regex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RegexProperty =
            DependencyProperty.Register("Regex", typeof(string), typeof(ValidableTextBox), new PropertyMetadata(null));



        public string ValidationMessage
        {
            get { return (string)GetValue(ValidationMessageProperty); }
            set { SetValue(ValidationMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValidationMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidationMessageProperty =
            DependencyProperty.Register("ValidationMessage", typeof(string), typeof(ValidableTextBox), new PropertyMetadata(null));


        //public event PropertyChangedEventHandler PropertyChanged;
        //public void NotifyPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}


        public ValidationTextBox()
        {
            this.InitializeComponent();
            
            
            //TextBoxRegex.SetValidationMode(TextBoxValidated, ValidationMode);
            //TextBoxRegex.SetValidationType(TextBoxValidated, ValidationType);
            //TextBoxRegex.SetRegex(TextBoxValidated, Regex);
            //Add eventhandler here: i want to run this one after TextBoxRegex evalation 
            
        }
               

        private void TextBoxValidated_TextChanged(object sender, TextChangedEventArgs e)
        {            
            if (TextBoxRegex.GetIsValid(TextBoxValidated))
                IsValid = true;
            else
                IsValid = false;
            if (_showValidation)
            {
                IsNotValidState = !IsValid;
            }
        }


        private void TextBoxValidated_GotFocus(object sender, RoutedEventArgs e)
        {
            _showValidation = true;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxRegex.SetValidationMode(TextBoxValidated, ValidationMode);
            TextBoxRegex.SetValidationType(TextBoxValidated, ValidationType);
            TextBoxRegex.SetRegex(TextBoxValidated, Regex);
            TextBoxValidated.TextChanged += TextBoxValidated_TextChanged;
        }
    }
}
