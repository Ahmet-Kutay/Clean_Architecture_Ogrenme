using CleanArchitecture.Domain.Abstraction;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Car : Entity
    {
        public String Name { get; set; }
        public string Model {  get; set; }
        public int EnginePower { get; set; }


    }
}
