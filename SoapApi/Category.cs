using System.Runtime.Serialization;

namespace SoapApi;

[DataContract]
public class Category
{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public string Name { get; set; }

    public Category(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
