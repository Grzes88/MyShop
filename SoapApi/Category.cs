using System.Runtime.Serialization;

namespace SoapApi;

[DataContract]
public class Category
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Name { get; set; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
