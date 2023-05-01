using System;
using System.IO;

namespace Naruto.DataBase
{
    public class DB
    {
        //public SQLite.SQLiteConnection myconnection;

        public DB()
        {
            //myconnection = new SQLite.SQLiteConnection(GetLocalFilePath("naturo.db3"));
        }

        private string GetLocalFilePath(string dbFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(path, dbFileName);
            return dbPath;
        }

        //public SQLite.SQLiteConnection openConnection()
        //{
        //    return myconnection;
        //}
    }
}