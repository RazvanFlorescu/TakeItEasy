using System;

namespace CommonTypes
{
    public enum LocationType
    {
        Origin = 0,
        Destination = 1,
        WayPoint = 2
    }

    public enum AvailableMode
    {
        Public = 0,
        Private = 1,
        OnlyFriends = 2
    }

    public enum StatusJoining
    {
        Requested = 0,
        Accepted = 1,
        Rejected = 2
    }

    public enum NotificationType
    {
        RequestVacation = 0,
        AcceptRequestVacation = 1,
        RejectRequestVacation = 2
    }
}
