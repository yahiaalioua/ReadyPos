using System;
using Android.App;
using Android.OS;
using AndroidX.AppCompat.App;
using Android.Widget;
using Xamarin.Forms;
using ReadyPos.Services;
using Button = Android.Widget.Button;

namespace ReadyPos
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            var DeviceIdentificationService = DependencyService.Get<IDeviceIdentifierService>();
            //den metode sletter den identifier som har blitt registrert i appen preferences.
            // kun for debugging.
            DeviceIdentificationService.ClearIdentifierFromApplication();

            DeviceIdentificationService.SetDeviceUniqueIdentifier();
            DeviceIdentificationService.SetBindedIdentifier();
            string deviceId = DeviceIdentificationService.GetDeviceUniqueIdentifier();

            var textView = FindViewById<TextView>(Resource.Id.textView2);
            textView.Text = deviceId;
            var verifyButton = FindViewById<Button>(Resource.Id.button1);
            verifyButton.Click += VerifyIdentifier;
        }
        private void VerifyIdentifier(object sender, EventArgs e)
        {

            var textView3=FindViewById<TextView>(Resource.Id.textView3);
            var DeviceIdentificationService = DependencyService.Get<IDeviceIdentifierService>();
            textView3.Text=DeviceIdentificationService.VerifyIdentifier();
        }
	}
}
