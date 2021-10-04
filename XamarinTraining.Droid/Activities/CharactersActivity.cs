using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Bumptech.Glide;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinTraining.Core.Domain;
using XamarinTraining.Core.ViewModels;
using XamarinTraining.Droid.Utils;

namespace XamarinTraining.Droid.Activities
{
    [Activity]
    public class CharactersActivity : ActivityBase
    {
        private CharactersViewModel viewModel;
        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager layoutManager;
        private RecyclerView.Adapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_characters);

            viewModel = SimpleIoc.Default.GetInstance<CharactersViewModel>();
            viewModel.LoadDataAsync();
            
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            adapter = viewModel.Characters.GetRecyclerAdapter(BindViewHolder, CreateViewHolder, null);

            recyclerView.SetAdapter(adapter);

            layoutManager = new LinearLayoutManager(this);

            recyclerView.SetLayoutManager(layoutManager);
        }

        private RecyclerView.ViewHolder CreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.text_row_item, parent, false);

            CharacterViewHolder vh = new CharacterViewHolder(itemView);
            return vh;
        }

        private void BindViewHolder(RecyclerView.ViewHolder holder, Character character, int position)
        {
            CharacterViewHolder viewHolder = holder as CharacterViewHolder;
            viewHolder.TextView.Text = character.Name;
            Glide.With(this).Load("http://goo.gl/gEgYUd").Into(viewHolder.ImageView);
        }
    }

    public class CharactersAdapter : RecyclerView.Adapter
    {
        private readonly IList<Character> characters;
        private readonly Context context;

        public CharactersAdapter(IList<Character> characters, Context context)
        {
            this.characters = characters;
            this.context = context;
        }

        public override int ItemCount => characters.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CharacterViewHolder viewHolder = holder as CharacterViewHolder;
            viewHolder.TextView.Text = characters[position].Name;
            Glide.With(context).Load("http://goo.gl/gEgYUd").Into(viewHolder.ImageView);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.text_row_item, parent, false);

            // Create a ViewHolder to hold view references inside the CardView:
            CharacterViewHolder vh = new CharacterViewHolder(itemView);
            return vh;
        }
    }

    public class CharacterViewHolder : RecyclerView.ViewHolder
    {
        public TextView TextView { get; private set; }
        public ImageView ImageView { get; private set; }

        public CharacterViewHolder(View v) : base(v)
        {
            TextView = (TextView)v.FindViewById(Resource.Id.textView);
            ImageView = (ImageView)v.FindViewById(Resource.Id.imageView);
        }
    }
}