// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MugenSandbox.iOS.Views
{
    [Register ("MainView")]
    partial class MainView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ChangeSomeStringBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SomeStringLb { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ChangeSomeStringBtn != null) {
                ChangeSomeStringBtn.Dispose ();
                ChangeSomeStringBtn = null;
            }

            if (SomeStringLb != null) {
                SomeStringLb.Dispose ();
                SomeStringLb = null;
            }
        }
    }
}