﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWpfAppTest.mvvm.ViewModel
{
    public interface IViewModelMainWindow
    {
        bool CanMoveTabs { get; set; }
        bool ShowAddButton { get; set; }
    }
}
