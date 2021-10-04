using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinTraining.Core.ViewModels;

namespace XamarinTraining.Droid.Activities
{
    [Activity]
    class AboutActivity : ActivityBase
    {
        private EditText editText;
        private TextView textView;
        private Button saveButton;
        private AboutViewModel viewModel;
        private TextView dataContent;
        private Binding binding1, binding2, binding3;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_about);
            editText = FindViewById<EditText>(Resource.Id.editText);
            textView = FindViewById<TextView>(Resource.Id.textView);
            saveButton = FindViewById<Button>(Resource.Id.saveButton);
            dataContent = FindViewById<TextView>(Resource.Id.dataContent);

            viewModel = SimpleIoc.Default.GetInstance<AboutViewModel>();
            binding1 = this.SetBinding(() => viewModel.AboutTitle, () => editText.Text, BindingMode.TwoWay);
            binding2 = this.SetBinding(() => editText.Text, () => textView.Text);
            binding3 = this.SetBinding(() => viewModel.DataContent, () => dataContent.Text);
            saveButton.SetCommand(viewModel.SaveDataCommand);
        }
    }
}