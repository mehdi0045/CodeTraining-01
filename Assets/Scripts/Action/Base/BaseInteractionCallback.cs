using Action.Interface;

namespace Action.Base
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
