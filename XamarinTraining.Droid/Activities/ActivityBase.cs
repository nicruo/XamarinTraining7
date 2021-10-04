using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinTraining.Droid.Activities
{
    public class ActivityBase : AppCompatActivity
    {
        /// <summary>
        /// The activity that is currently in the foreground.
        /// </summary>
        public static ActivityBase CurrentActivity
        {
            get;
            private set;
        }

        internal string ActivityKey
        {
            get;
            private set;
        }

        internal static string NextPageKey
        {
            get;
            set;
        }

        /// <summary>
        /// If possible, discards the current page and displays the previous page
        /// on the navigation stack.
        /// </summary>
        public static void GoBack()
        {
            if (CurrentActivity != null)
            {
                CurrentActivity.OnBackPressed();
            }
        }

        /// <summary>
        /// Overrides <see cref="Activity.OnResume"/>. If you override
        /// this method in your own Activities, make sure to call
        /// base.OnResume to allow the <see cref="NavigationService"/>
        /// to work properly.
        /// </summary>
        protected override void OnResume()
        {
            CurrentActivity = this;

            if (string.IsNullOrEmpty(ActivityKey))
            {
                ActivityKey = NextPageKey;
                NextPageKey = null;
            }

            base.OnResume();
        }
    }
}