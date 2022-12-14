using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWpfAppTest.mvvm.ViewModel
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Create run time view services and models
            SimpleIoc.Default.Register<IViewModelMainWindow, ViewModelMainWindow>();

        }


        public IViewModelMainWindow ViewModelMainWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IViewModelMainWindow>();
            }
        }


    }
}
