namespace Observer.Core
{
    public enum ObserverEventType
    {
        Interacted = 0,
        ReachInteractable = 1,
        LeaveInteractable = 2,
        UnlockDoor = 3,
        SucceedToUnlockedDoor = 4,
        FailedToUnlockDoor = 5
    }

    public enum InteractableType
    {
        Key = 0,
        Door = 1
    }
}