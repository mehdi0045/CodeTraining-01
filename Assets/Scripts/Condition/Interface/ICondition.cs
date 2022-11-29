namespace ConditionSystem
{
    public interface ICondition 
    {
        string Id{get; set;}

        IConditionCallback Check(IConditionArgs iArgs);
    }
}
