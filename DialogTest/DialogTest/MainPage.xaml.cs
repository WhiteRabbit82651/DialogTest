using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DialogTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            button1.Clicked += ShowTextDialog;
            button2.Clicked += ShowPasswdDialog;
        }
        
        /// <summary>
        /// Textボタンを押下した場合に、Text入力のダイアログを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ShowTextDialog(object sender, EventArgs e)
        {
            // ダイアログを同期して生成する
            var result = await DependencyService.Get<IDialog>().Show("設定ダイアログ", "接続タイムアウト時間", "OK", "Cancel", false);
            label.Text = string.Format("{0}:{1}", result.PressedButtonTitle, result.Text);
        }

        /// <summary>
        /// Passボタンを押下した場合に、Pass入力のダイアログを表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ShowPasswdDialog(object sender, EventArgs e)
        {
            var result = await DependencyService.Get<IDialog>().Show("Password", "Please enter password.", "OK", "Cancel", true);
            label.Text = string.Format("{0}:{1}", result.PressedButtonTitle, result.Text);
        }
    }
}
