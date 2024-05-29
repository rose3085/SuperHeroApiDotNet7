namespace SuperHeroApiDotNet7.Models
{
    public class SuperHeroModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

       // public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Place { get; set; } 

        //to add these properties use prop tab


        public bool IsDeleted { get; set; }

    }
}
