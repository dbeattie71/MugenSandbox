using Foundation;
using MugenMvvmToolkit;
using MugenMvvmToolkit.iOS;
using MugenMvvmToolkit.iOS.Infrastructure;
using MugenSandbox.Core;
using UIKit;

namespace MugenSandbox.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        private const string RootViewControllerKey = "RootViewControllerKey";
        private TouchBootstrapperBase _bootstrapper;

        public override UIWindow Window { get; set; }

        public override void DidDecodeRestorableState(UIApplication application, NSCoder coder)
        {
            var controller = (UIViewController) coder.DecodeObject(RootViewControllerKey);
            if (controller != null)
                Window.RootViewController = controller;
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            //Window = new UIWindow(UIScreen.MainScreen.Bounds);

            // If you have defined a root view controller, set it here:
            // Window.RootViewController = myViewController;

            // make the window visible
            //Window.MakeKeyAndVisible();

            if (Window.RootViewController == null)
                _bootstrapper.Start();

            // make the window visible
            Window.MakeKeyAndVisible();

            return true;
        }

        public override UIViewController GetViewController(
            UIApplication application,
            string[] restorationIdentifierComponents, NSCoder coder)
        {
            return PlatformExtensions.ApplicationStateManager.GetViewController(restorationIdentifierComponents, coder);
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override bool ShouldRestoreApplicationState(UIApplication application, NSCoder coder)
        {
            return true;
        }

        public override bool ShouldSaveApplicationState(UIApplication application, NSCoder coder)
        {
            return true;
        }

        public override void WillEncodeRestorableState(UIApplication application, NSCoder coder)
        {
            if (Window.RootViewController != null)
                coder.Encode(Window.RootViewController, RootViewControllerKey);
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override bool WillFinishLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            _bootstrapper = new Bootstrapper<App>(Window, new AutofacContainer());
            _bootstrapper.Initialize();
            return true;
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}