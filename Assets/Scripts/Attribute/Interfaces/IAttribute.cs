
namespace Attribute.Interfaces
{
    public interface IAttribute
    { 
        string Name { get; set; }
    
        float Min { get; set; }
    
        float Max { get; set; }
    
        float Current { get; set; }    
    }
}
