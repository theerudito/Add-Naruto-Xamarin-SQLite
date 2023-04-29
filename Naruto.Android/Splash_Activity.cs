using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;


namespace Naruto.Droid
{
    [Activity(Label = "Naruto", Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class Splash_Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}