namespace DeliveryService.Domain.Enums;

public enum DeliveryStatus
{
    Pending = 1,
    Assigned = 2,
    PickedUp = 3,
    OutForDelivery = 4,
    Delivered = 5,
    Failed = 6,
    Cancelled = 7
}