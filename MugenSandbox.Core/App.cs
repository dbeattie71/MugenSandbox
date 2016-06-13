using System;
using MugenMvvmToolkit;
using MugenSandbox.Core.ViewModels;

namespace MugenSandbox.Core
{
    public class App : MvvmApplication
    {
        public override Type GetStartViewModelType()
        {
            return typeof (MainViewModel);
        }
    }
}