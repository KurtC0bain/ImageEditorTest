using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ConsoleWpfAppTest.mvvm.ViewModel
{
    public abstract class TabBase : ViewModelBase
    {
        private int _tabNumber;
        public int TabNumber
        {
            get => _tabNumber;
            set
            {
                if (_tabNumber != value)
                {
                    Set(() => TabNumber, ref _tabNumber, value);
                }
            }
        }

        private string _tabName;
        public string TabName
        {
            get => _tabName;
            set
            {
                if (_tabName != value)
                {
                    Set(() => TabName, ref _tabName, value);
                }
            }
        }


        private ImageSource _tabIcon;
        public ImageSource TabIcon
        {
            get => _tabIcon;
            set
            {
                if (!Equals(_tabIcon, value))
                {
                    Set(() => TabIcon, ref _tabIcon, value);
                }
            }
        }
    }
}
