export class TripNotification {
    entityId?: string;
    vacationId: string;
    authorId: string;
    receiverId: string;
    text?: string;
    isViewed?: boolean;
    lastChangedDate?: Date;
    userPicture?: string;
    notificationType?: NotificationType
}

export enum NotificationType
{
    requestVacation = 0,
    acceptRequestVacation = 1,
    rejectRequestVacation = 2,
    startVacation = 3,
    endVacation = 4,
    wishItem = 5
}