using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using ChromeTabs;
using ConsoleWpfAppTest.mvvm.UserControls;
using ConsoleWpfAppTest.mvvm.ViewModel;
using static System.Windows.PresentationSource;

namespace ConsoleWpfAppTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(Uri imageUri)
        {
            this.DataContext = new ViewModelMainWindow();
            ImageControll controll = new ImageControll(imageUri);
            this.Resources.Add("controll", controll);
            InitializeComponent();
        }
    }
}
