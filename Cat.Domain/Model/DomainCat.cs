namespace Cat.Domain.Model
{
    public class DomainCat
    {
        public DomainCat(string name, int age, Classification classification)
        {
            Name = name;
            Age = age;
            Classification = classification;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public Classification Classification { get; set; }
    }
}