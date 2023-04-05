
using Microsoft.EntityFrameworkCore;
using Naruto.Models;
using System;
using System.IO;
using Xamarin.Forms;

namespace Naruto.Context
{
    public class Application_Context : DbContext
    {
        private const string DatabaseName = "Naruto.db3";

        public DbSet<MNaruto> Naruto { get; set; }

        public Application_Context()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String databasePath;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", DatabaseName);
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DatabaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}
