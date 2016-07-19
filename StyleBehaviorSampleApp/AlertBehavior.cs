using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace StyleBehaviorSampleApp
{
    public class AlertBehavior : Behavior<Button>
    {
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(AlertBehavior), new PropertyMetadata(null));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        protected override void OnAttached()
        {
            this.AssociatedObject.Click += this.Button_Click;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= this.Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.Message ?? "");
        }

    }
}
