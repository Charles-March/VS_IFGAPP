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
        AutoCompleteTextView InAutoCompleteText;

        string FinalItemID;
        int FinalQuantity;
        float FinalPriceUnit;
        string FinalAccountAux;

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

        string getAccount(string itemID)
        {
            return "X45487D4897-01-001-01";
        }

        IListAdapter getAccountList(string itemID)
        {
            string[] list = new string[2];
            list[0] = "compte1";
            list[1] = "compte2";

            ArrayAdapter adapt = new ArrayAdapter(this, Resource.Layout.AccountListItem,list);
            return adapt;
        }
        /*#####################*/
#endregion


        void Activate_in_ID()
        {

            SetContentView(Resource.Layout.InMainWindow);
            InValidate = FindViewById<Button>(Resource.Id.InItemIdValidation);
            InEditText = FindViewById<EditText>(Resource.Id.InEditTextItemID);
            
            InBack = FindViewById<Button>(Resource.Id.InToMain);
            InBack.Click += delegate
            {
                Activate_main();
            };

            InValidate.Click += delegate
            {
                if (FindViewById<EditText>(Resource.Id.InEditTextItemID).Text != "")
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

            InValidate = FindViewById<Button>(Resource.Id.InItemIdValidation);
            InEditText = FindViewById<EditText>(Resource.Id.InEditTextItemID);
            InTextView = FindViewById<TextView>(Resource.Id.InItemIdText);

            InTextView.Text = GetString(Resource.String.ItemQuantityText);
            InEditText.Text = "";
            InEditText.InputType = Android.Text.InputTypes.ClassNumber;


            InValidate.Click += delegate
            {
                if (InEditText.Text != "")
                {
                    FinalQuantity = int.Parse(InEditText.Text);
                    In_PriceUnit();
                }
            };

        }

        void In_PriceUnit()
        {
            SetContentView(Resource.Layout.InMainWindow);

            InValidate = FindViewById<Button>(Resource.Id.InItemIdValidation);
            InEditText = FindViewById<EditText>(Resource.Id.InEditTextItemID);
            InTextView = FindViewById<TextView>(Resource.Id.InItemIdText);

            InTextView.Text = GetString(Resource.String.ItemPriceUnitText);
            InEditText.Text = "";
            InEditText.InputType = Android.Text.InputTypes.NumberFlagDecimal;

            InValidate = FindViewById<Button>(Resource.Id.InItemIdValidation);

            InValidate.Click += delegate
            {
                if (InEditText.Text != "")
                {
                    FinalPriceUnit = int.Parse(InEditText.Text);
                    In_AccountAux();
                }
            };
        }

        void In_AccountAux()
        {
            SetContentView(Resource.Layout.InMainWindow);

            InAutoCompleteText = FindViewById<AutoCompleteTextView>(Resource.Id.InACT);
            InValidate = FindViewById<Button>(Resource.Id.InItemIdValidation);
            InEditText = FindViewById<EditText>(Resource.Id.InEditTextItemID);
            InTextView = FindViewById<TextView>(Resource.Id.InItemIdText);

            InTextView.Text = GetString(Resource.String.ItemAccountAuxText);

            InAutoCompleteText.SetHeight(InEditText.Height);
            InEditText.SetHeight(0);
            InEditText.Enabled = false;
            InAutoCompleteText.Adapter = getAccountList(FinalItemID);
            InAutoCompleteText.Text = getAccount(FinalItemID);

  

            InValidate.Click += delegate
            {
                if (InEditText.Text != "")
                {
                    FinalAccountAux = InAutoCompleteText.Text;
                    In_AccountAux();
                }
            };
        }






        /*
        InEditText.Text = getAccount(FinalItemID);
        InEditText.InputType = Android.Text.InputTypes.TextFlagAutoComplete;
        */
    }
    }

