namespace SuperHeroApiDotNet7.Models
{
    public class SuperHeroModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Place { get; set; } = string.Empty;

        //to add these properties use prop tab
    }
}
