using SQLite;

namespace Naruto.Models
{
    public class MNaruto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Clan { get; set; }
        [MaxLength(50)]
        public int Age { get; set; }
        [MaxLength(300)]
        public string Image { get; set; }
        [MaxLength(50)]
        public string Jutsu { get; set; }
        [MaxLength(50)]
        public string Color1 { get; set; }
        [MaxLength(50)]
        public string Color2 { get; set; }
        [MaxLength(50)]
        public string Color3 { get; set; }
    }
}


//Name 
//Clan 
//Age
//Jutsu
//Image 
//Color1 
//Color2 
