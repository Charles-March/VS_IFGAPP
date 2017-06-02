using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using static Android.Views.View;
using Android.Views;
using InfApp;
using Android.Util;
using Android.Content.PM;

namespace Inforges_Application
{
    [Activity(Label = "Inforges Application", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Landscape, Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity {

        Button MainToIn;
        Button MainToPick;
        Button MainToRelocate;
        Button MainToToFact;

        Button InBack;
        Button InValidate;

        EditText InEditText;
        TextView InTextView;

        string FinalItemID;
        int FinalQuantity;
        float FinalPriceUnit;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Set our view from the "main" layout resource
            Activate_main();
        }
        #region MainDisplay
        void Activate_main()
        {
            SetContentView(Resource.Layout.Main);
            MainToIn = FindViewById<Button>(Resource.Id.MainToInButton);
            MainToPick = FindViewById<Button>(Resource.Id.MainToPickButton);
            MainToRelocate = FindViewById<Button>(Resource.Id.MainToRelocateButton);
            MainToToFact = FindViewById<Button>(Resource.Id.MainToToFactButton);

            MainToIn.Click += delegate
            {
                Activate_in_ID();
            };


        }
        #endregion

        #region SQLFunc
        /*     SQL FUNCTIONS   */
        bool CheckValideID(string itemID)
        {
            return true;
        }

        string ReturnDescription(string itemID)
        {
            if (itemID == "01") return "coucou";
            else return "aurevoir";
        }
        /*#####################*/
#endregion


        void Activate_in_ID()
        {

            SetContentView(Resource.Layout.InMainWindow);
            InValidate = FindViewById<Button>(Resource.Id.InItemIdValidation);
            InEditText = FindViewById<EditText>(Resource.Id.EditTextItemID);

            InBack.Click += delegate
            {
                Activate_main();
            };

            InValidate.Click += delegate
            {
                if (FindViewById<EditText>(Resource.Id.EditTextItemID).Text != "")
                {

                    string itemID = InEditText.Text;
                    string s;
                        if (CheckValideID(itemID))
                        {
                            s = GetString(Resource.String.ValidationDescrInText) + " " + ReturnDescription(itemID) + "?";
                            AlertDialog.Builder ConfirmDescr = new AlertDialog.Builder(this);
                            ConfirmDescr.SetTitle(GetString(Resource.String.ValidationTitle));

                            ConfirmDescr.SetMessage(s);

                            ConfirmDescr.SetPositiveButton(GetString(Resource.String.Yes), (senderAlertConfirmDescr, argsConfirmDescr) => {
                                FinalItemID = itemID;
                                In_Quantity();
                            });

                            ConfirmDescr.SetNegativeButton(GetString(Resource.String.Cancel), (senderAlertConfirmDescr, argsConfirmDescr) => {
                               //IF NOT
                            });

                            Dialog dialogConfirmDescr = ConfirmDescr.Create();
                            dialogConfirmDescr.Show();
                        }
                }
            };
        }

        void In_Quantity()
        {
            SetContentView(Resource.Layout.InMainWindow);
            InTextView.Text = GetString(Resource.String.ItemQuantityText);
            InEditText.Text = "";
            InEditText.InputType = Android.Text.InputTypes.ClassNumber;

            InValidate = FindViewById<Button>(Resource.Id.InItemIdValidation);

            InValidate.Click += delegate
            {
                if (InEditText.Text != "")
                {
                    FinalQuantity = int.Parse(InEditText.Text);
                    In_Price();
                }
            };

        }

        void In_Price()
        {
            SetContentView(Resource.Layout.InMainWindow);
            InTextView.Text = GetString(Resource.String.ItemPriceUnitText);
            InEditText.Text = "";
            InEditText.InputType = Android.Text.InputTypes.NumberFlagDecimal;

            InValidate = FindViewById<Button>(Resource.Id.InItemIdValidation);

            InValidate.Click += delegate
            {
                if (InEditText.Text != "")
                {

                    FinalPriceUnit = int.Parse(InEditText.Text);
              
                }
            };
        }
    }

}

