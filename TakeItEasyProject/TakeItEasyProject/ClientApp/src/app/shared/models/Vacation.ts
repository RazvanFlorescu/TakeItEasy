export class TripLocation {
    longitude: string;
    latitude: string;
}

export class Vacation {
    entityId?: string;
    imageId?: string;
    image?: string;
    description: string;
    startPoint: TripLocation;
    endPoint: TripLocation;
    startDate: Date;
    endDate: Date;
}