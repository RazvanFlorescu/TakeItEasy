using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
