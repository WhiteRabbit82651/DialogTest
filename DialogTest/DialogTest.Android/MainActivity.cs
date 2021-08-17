using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Text;
using Java.Lang;
using Android.Widget;
using Android.Views.InputMethods;
using Android.Content;

namespace DialogTest.Droid
{
    [Activity(Label = "DialogTest", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, Android.Text.ITextWatcher
    {
        public static object aaa;
        public static object editText;
        public static InputMethodManager inputMethodManager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            aaa = this;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void AfterTextChanged(IEditable s)
        {
            //var editText = new EditText((global::Android.Content.Context)MainActivity.aaa);
            //editText.FindViewById(999);
            //editText.Text = "Hello world";
            //string msg = string.Format("EditText id = 999 の文字列 = {0}", editText.Text);
            //Toast.MakeText(Application.Context, msg, ToastLength.Long).Show();



            // 書き換えはしないとのことなので、ここはコメントアウト
            //string msg = string.Format("EditTextの文字列 = {0}", ((EditText)editText).Text);
            //Toast.MakeText(Application.Context, msg, ToastLength.Long).Show();


            //if (s.Length() > 0)
            //{
            //    // 想定桁数を超えている場合は、強制的に300に書き直す
            //    if(s.Length() > 3)
            //    {
            //        s.Clear();
            //        s.Append("300");
            //    }
            //    //string msg = string.Format("入力した文字 = {0}", s.CharAt(s.Length() - 1));
            //    //Toast.MakeText(Application.Context, msg, ToastLength.Long).Show();
            //}
            
            
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
            //Toast.MakeText(Application.Context, "BeforeTextChanged", ToastLength.Long).Show();
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            //Toast.MakeText(Application.Context, "OnTextChanged", ToastLength.Long).Show();
        }
    }
    
}