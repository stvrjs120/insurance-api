using System;

namespace InsuranceAPI.Models
{
    public interface IModifiableEntity
    {
        string Name { get; set; }
    }

    public interface IEntity : IModifiableEntity
    {
        object Id { get; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}
