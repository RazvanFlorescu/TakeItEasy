using System;

namespace Entities
{
    public class User : BaseEntity
    {
        public Guid? ImageId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
