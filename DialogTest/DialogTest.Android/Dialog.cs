using System.Threading.Tasks;
using Android.App;
using Android.Widget;
using Xamarin.Forms;

using DialogTest;
using DialogTest.Droid;
using CheckBox = Android.Widget.CheckBox;
using Android.Content;
using System;
using Java.Interop;
using Android.Views.InputMethods;

// プラットフォーム側の実装の属性の指定
[assembly: Dependency(typeof(DialogText.Android.Dialog))]
namespace DialogText.Android
{
    public class Dialog : IDialog
    {
        public Task<DialogResult> Show(string title, string message, string accepte, string cancel, bool isPassword = false)
        {
            var tcs = new TaskCompletionSource<DialogResult>();

            // Editを作成する
            MainActivity.editText = new EditText((global::Android.Content.Context)MainActivity.aaa);

            // リスナーを設定。これによりActivityのOnTextChangeが効くようになる
            //((EditText)MainActivity.editText).AddTextChangedListener((global::Android.Text.ITextWatcher)MainActivity.aaa);
            

            if (isPassword)
            {
                ((EditText)MainActivity.editText).InputType = global::Android.Text.InputTypes.TextVariationPassword | global::Android.Text.InputTypes.ClassText;
            }

            AlertDialog dialog = new AlertDialog.Builder((global::Android.Content.Context)MainActivity.aaa)
                .SetTitle(title)
                .SetMessage(message)
                .SetView(((EditText)MainActivity.editText))
                .SetNeutralButton("バージョン情報", (o, e) => tcs.SetResult(new DialogResult
                {
                    // ダミー処理
                    PressedButtonTitle = "バージョン情報",
                    Text = ((EditText)MainActivity.editText).Text
                }))
                .SetNegativeButton(cancel, (o, e) => tcs.SetResult(new DialogResult
                {
                    PressedButtonTitle = cancel,
                    Text = ((EditText)MainActivity.editText).Text
                }))
                .SetPositiveButton(accepte, (o, e) => tcs.SetResult(new DialogResult
                {
                    PressedButtonTitle = accepte,
                    Text = ((EditText)MainActivity.editText).Text
                })).Create();

            dialog.SetOnShowListener(new AlertDialogShowListener(dialog, tcs));


            dialog.Show();

            return tcs.Task;
        }

        /// <summary>
        /// https://teratail.com/questions/145090
        /// 
        /// </summary>
        class AlertDialogShowListener : Java.Lang.Object, IDialogInterfaceOnShowListener
        {
            AlertDialog _dialog;
            private TaskCompletionSource<DialogResult> _tcs;

            internal AlertDialogShowListener(AlertDialog dialog, TaskCompletionSource<DialogResult> tcs)
            {
                _dialog = dialog;
                _tcs = tcs;
            }

            public void OnShow(IDialogInterface dialog)
            {
                // OKボタンの処理を設定
                _dialog.GetButton((int)DialogButtonType.Positive).SetOnClickListener(new PositiveButtonClick(_dialog, _tcs));

                // バージョン情報の処理を設定
                _dialog.GetButton((int)DialogButtonType.Neutral).SetOnClickListener(new NeutralButtonClick(_dialog, _tcs));
            }
        }

        /// <summary>
        /// OKボタンを押下時の動作
        /// 0～300以外が入力された場合にダイアログを閉じないようにするために作成
        /// </summary>
        class PositiveButtonClick : Java.Lang.Object, global::Android.Views.View.IOnClickListener
        {
            AlertDialog _dialog;
            private TaskCompletionSource<DialogResult> _tcs;
            public PositiveButtonClick(AlertDialog dialog, TaskCompletionSource<DialogResult> tcs)
            {
                _dialog = dialog;
                _tcs = tcs;
            }
            public void OnClick(global::Android.Views.View v)
            {
                var Text = ((EditText)MainActivity.editText).Text;

                try
                {
                    int result = Int32.Parse(Text);

                    if(result >= 0 && result <= 300)
                    {
                        // 入力した値が0～300の間であればOK
                        _tcs.SetResult(new DialogResult
                        {
                            PressedButtonTitle = "OK",
                            Text = ((EditText)MainActivity.editText).Text
                        });
                        _dialog.Dismiss();
                    } else
                    {
                        // 入力した値が0～300の間でなければ、処理を終了する(ダイアログを閉じない)
                        // エラーが発生したら、処理を終了する(ダイアログを閉じない)
                        string msg = string.Format("入力した値が0～300の間では無いです。");
                        var ts = Toast.MakeText((global::Android.Content.Context)MainActivity.aaa, msg, ToastLength.Long);
                        ts.SetGravity(global::Android.Views.GravityFlags.Top, 0, 0);
                        ts.Show();
                    }

                }
                catch (Exception e)
                {
                    // エラーが発生したら、処理を終了する(ダイアログを閉じない)
                    string msg = string.Format("何かしらのエラーが発生しました。");
                    var ts = Toast.MakeText((global::Android.Content.Context)MainActivity.aaa, msg, ToastLength.Long);
                    ts.SetGravity(global::Android.Views.GravityFlags.Top, 0, 0);
                    ts.Show();
                }
            }
        }

        /// <summary>
        /// バージョン情報ボタンを押下時の動作
        /// 設定ダイアログを閉じずにバージョンダイアログを開くために作成
        /// </summary>
        class NeutralButtonClick : Java.Lang.Object, global::Android.Views.View.IOnClickListener
        {
            AlertDialog _dialog;
            private TaskCompletionSource<DialogResult> _tcs;
            public NeutralButtonClick(AlertDialog dialog, TaskCompletionSource<DialogResult> tcs)
            {
                _dialog = dialog;
                _tcs = tcs;
            }
            public void OnClick(global::Android.Views.View v)
            {
                // ダイアログを表示する
                string msg = string.Format("ダイアログを表示する");
                var ts = Toast.MakeText((global::Android.Content.Context)MainActivity.aaa, msg, ToastLength.Long);
                ts.SetGravity(global::Android.Views.GravityFlags.Top, 0, 0);
                ts.Show();


                // 利用規約の中身はまだTBD
                TextView textView = new TextView((global::Android.Content.Context)MainActivity.aaa);
                textView.Text = "TBD";

                // ダイアログの表示ダミー
                AlertDialog dialog = new AlertDialog.Builder((global::Android.Content.Context)MainActivity.aaa)
                .SetTitle("バージョン情報")
                .SetMessage("利用規約")
                .SetView(textView)
                .SetNegativeButton("閉じる", (s, a) => { })
                .Create();

                dialog.Show();
            }
        }


    }

}