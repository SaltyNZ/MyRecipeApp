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
    public partial class RecipeEntryPage : ContentPage
    {
        public RecipeEntryPage()
        {
            InitializeComponent();
            BindingContext = new Recipe();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe) BindingContext;
            recipe.ID = Guid.NewGuid().ToString();
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            await appDatabaseContext.Recipes.AddAsync(recipe);
            await appDatabaseContext.SaveChangesAsync();
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}