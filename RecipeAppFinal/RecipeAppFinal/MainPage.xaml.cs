using Android.App;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecipeAppFinal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            db = new AppDatabaseContext();
            
        }
        private AppDatabaseContext db;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            RecipesListView.ItemsSource = await db.Recipes.ToListAsync();
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipeEntryPage());
        }

        async void OnRecipeSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (RecipesListView.SelectedItem != null)
            {
                var recipe = e.SelectedItem as Recipe;
                await Navigation.PushAsync(new RecipeViewPage(recipe));
                RecipesListView.SelectedItem = null;
            }
            else
            {
                return;
            }
        }
    }
}
