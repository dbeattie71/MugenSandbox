using System;
using Foundation;
using MugenMvvmToolkit.Attributes;
using MugenMvvmToolkit.iOS.Views;
using MugenSandbox.Core.ViewModels;
using UIKit;

namespace MugenSandbox.iOS.Views
{
    [ViewModel(typeof(MainViewModel))]
    public partial class MainView : MvvmViewController
    {
        public MainView() : base("MainView", null)
        {
        }

       

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
        }
    }
}