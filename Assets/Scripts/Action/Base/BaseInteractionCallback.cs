
namespace Action
{
    public class BaseInteractionCallback : IInteractionCallBack
    {
        public BaseInteractionCallback(int status)
        {
            Status = status;
        }

        public int Status { get; set; }
    }
}
