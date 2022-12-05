
namespace Condition.Interface
{
    public interface ICondition
    {
        string Id { get; set; }

        IConditionCallback Check(IConditionArgs iArgs);
    }
}