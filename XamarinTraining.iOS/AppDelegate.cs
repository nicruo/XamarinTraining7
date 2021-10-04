using Foundation;
using GalaSoft.MvvmLight.Ioc;
using UIKit;
using XamarinTraining.Core.Services;
using XamarinTraining.Core.ViewModels;
using XamarinTraining.iOS.Services;

namespace XamarinTraining.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = new HomeViewController();
            Window.MakeKeyAndVisible();

            SimpleIoc.Default.Register<IDataService, DataService>();
            SimpleIoc.Default.Register<IToastService>(() => new ToastService(Window.RootViewController));
            SimpleIoc.Default.Register<HomeViewModel>();

            return true;
        }
    }
}