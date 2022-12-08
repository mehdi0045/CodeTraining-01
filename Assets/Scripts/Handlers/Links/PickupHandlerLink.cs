using Handlers;

public class PickupHandlerLink : IHandlerLink
{
    private InputHandler inputHandler;

    private PickupHandler pickupHandler;

    public void Link(IController controller)
    {
        inputHandler = controller.GetHandler<InputHandler>();
        pickupHandler = controller.GetHandler<PickupHandler>();

        inputHandler.OnInputPickup += OnInputPickup;
    }

    private void OnInputPickup()
    {
        pickupHandler.PickedUp();
    }
}
