export class TripLocation {
    longitude: number;
    latitude: number;
    placeId?: string;
    locationType?: LocationType;
    address: string;
}

export enum AvailableMode {
    Public = 0,
    Private = 1 ,
    OnlyFriends = 2
}

export class Vacation {
    entityId?: string;
    authorId?: string;
    description: string;
    startDate: Date;
    endDate: Date;
    title: string;
    availableMode: AvailableMode;
    vacationPoints: TripLocation[];
    imageId?: string;
    image?: string;
    lastChangedDate?: Date
}

export enum LocationType {
    origin = 0,
    destination = 1,
    wayPoint = 2
  }

export class VacationJoining {
    vacationId: string;
    userId: string;
    statusJoining?: StatusJoining;
}

export enum StatusJoining {
    requested = 0,
    accepted = 1,
    rejected = 2
}
