namespace Cat.Data.Models
{
    public class CatData
    {
        public CatData(string name, int age, ClassificationData classification)
        {
            Name = name;
            Age = age;
            Classification = classification;
        }
        public string Name { get; }
        public int Age { get; }
        public ClassificationData Classification { get; }
    }
}