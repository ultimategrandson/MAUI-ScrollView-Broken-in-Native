using Foundation;
using MauiApp1;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;
using UIKit;

namespace iOSApp1
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow? Window
        {
            get;
            set;
        }

        public MauiContext Context
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            // create a UIViewController with a single UILabel
            //var vc = new UIViewController();
            //vc.View!.AddSubview(new UILabel(Window!.Frame)
            //{
            //    BackgroundColor = UIColor.SystemBackground,
            //    TextAlignment = UITextAlignment.Center,
            //    Text = "Hello, iOS!",
            //    AutoresizingMask = UIViewAutoresizing.All,
            //});
            //Window.RootViewController = vc;



            var mauiApp = MauiApp.CreateBuilder()
                .UseMauiEmbedding<Microsoft.Maui.Controls.Application>();

            var app = mauiApp.Build();

            Context = new MauiContext(app.Services);

            var page = new NewPage1();
            
            Window.RootViewController = page.ToUIViewController(Context);

            //// make the window visible
            Window.MakeKeyAndVisible();

            return true;
        }
    }
}