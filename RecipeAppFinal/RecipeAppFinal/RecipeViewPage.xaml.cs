using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeAppFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeViewPage : ContentPage
    {
        public RecipeViewPage(Recipe recipe)
        {
            InitializeComponent();
            BindingContext = recipe;
        }
        
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe)BindingContext;
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            appDatabaseContext.Recipes.Update(recipe);
            await appDatabaseContext.SaveChangesAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe)BindingContext;
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            appDatabaseContext.Recipes.Remove(recipe);
            await appDatabaseContext.SaveChangesAsync();
            await Navigation.PopAsync();
        }
    }
}