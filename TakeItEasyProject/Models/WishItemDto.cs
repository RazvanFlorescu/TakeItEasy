﻿namespace Models
{
    public class WishItemDto : BaseDto
    {
        public string AuthorId { get; set; }
        public LocationDto Location { get; set; }
    }
}
