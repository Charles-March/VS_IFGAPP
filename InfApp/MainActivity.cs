using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using static Android.Views.View;
using Android.Views;
using InfApp;

namespace Inforges_Application
{
    [Activity(Label = "Inforges Application", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {

        Button MainToIn;
        Button MainToPick;
        Button MainToRelocate;
        Button MainToToFact;

        Button InBack;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Set our view from the "main" layout resource
            Activate_main();
        }

        void Activate_main()
        {

            SetContentView(Resource.Layout.Main);
            MainToIn = FindViewById<Button>(Resource.Id.MainToInButton);
            MainToPick = FindViewById<Button>(Resource.Id.MainToPickButton);
            MainToRelocate = FindViewById<Button>(Resource.Id.MainToRelocateButton);
            MainToToFact = FindViewById<Button>(Resource.Id.MainToToFactButton);

            MainToIn.Click += delegate
            {
                Activate_in();

            };


        }

        void Activate_in()
        {
            SetContentView(Resource.Layout.InMainWindow);
            InBack = FindViewById<Button>(Resource.Id.InToMain);
            InBack.Click += delegate
            {
                Activate_main();
            };
        }
    }

}

