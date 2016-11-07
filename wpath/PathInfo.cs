using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpath
{
    internal class PathInfo : DependencyObject
    {
        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register("Path", typeof(string), typeof(PathInfo), new PropertyMetadata(""));

        public ObservableCollection<string> PathList { get; set; }

        public PathInfo()
        {
            var pathvar = Environment.GetEnvironmentVariable("PATH");
            var splitlist = pathvar?.Split(';').ToList();

            PathList = new ObservableCollection<string>(splitlist);
        }
    }
}
