export class TripLocation {
    longitude: number;
    latitude: number;
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
    title: string;
}
