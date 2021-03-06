﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BuildAnApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // this is a comment
            string name = "Quentin";
            int x = 3;
            x = x * 17;
            double d = Math.PI / 2;
            myLabel.Text = "name is " + name + "\nx is " + x + "\nd is " + d;
 
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int x = 10;
            if (x==10)
            {
                myLabel.Text = "x must be 10";
            }
            else
            {
                myLabel.Text = "x isn't 10";
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            int someValue = 3;
            string name = "Joe";
            if ((someValue==3) && (name =="Joe"))
            {
                myLabel.Text = "x is 3 and the name is Joe";
            }
            myLabel.Text = "this line runs no matter what";
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            int p = 2;
            int count = 0;
            for (int q = 2; q < 32; q*=2)
            {
                while (p<q)
                {
                    p *= 2;
                }
                q = p - q;
                count++;
            }
            myLabel.Text = ""+count;
        }
    }
}
