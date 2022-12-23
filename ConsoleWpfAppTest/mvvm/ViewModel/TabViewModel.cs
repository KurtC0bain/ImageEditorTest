using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ConsoleWpfAppTest.mvvm.Enums;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace ConsoleWpfAppTest.mvvm.ViewModel
{
    public class TabViewModel : ViewModelBase
    {
        public event EventHandler CanExecuteChanged;

        public TabViewModel()
        {
            ScanCommand = new RelayCommand<Window>(GetImage, CanExecute);
        }
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

        private ImageSource _image;
        public ImageSource Image
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    Set(() => Image, ref _image, value);
                }
            }
        }

        private string _size;
        public string Size
        {
            get => _size;
            set
            {
                if (_size != value)
                {
                    Set(() => Size, ref _size, value);
                }
            }
        }

        private ViewMode _viewerMode;
        public ViewMode ViewerMode
        {
            get => _viewerMode;
            set
            {
                if (_viewerMode != value)
                {
                    Set(() => ViewerMode, ref _viewerMode, value);
                }
            }
        }


        public ICommand ScanCommand { get; }

        public bool CanExecute(Window? window) => ViewerMode == ViewMode.WithoutImage;

        public void GetImage(Window? window)
        {
            var path = this.StartGetImageFunc();

            if (path is null || !File.Exists(path))
            {
                MessageBox.Show("Помилка отримання зображення", "Помилка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            Image = new BitmapImage(new Uri(path, UriKind.Absolute));
            _viewerMode = ViewMode.WithImage;
        }

        private string StartGetImageFunc()
        {
            var path = "D:\\UNITY-BARS\\repos\\wpfchrometabs-mvvm\\Demo\\Resources\\kitten.jpg";
            return path;

        }
    }
}
