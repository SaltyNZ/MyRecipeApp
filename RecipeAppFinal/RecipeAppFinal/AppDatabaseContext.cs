using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace RecipeAppFinal
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext()
        {
            this.Database.EnsureCreated();
            SaveChangesAsync();
        }
        public DbSet<Recipe> Recipes { get; set; }

        private readonly string DbName = "myRecipes.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = string.Empty;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", DbName);
                    break;
                case Device.Android:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DbName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
