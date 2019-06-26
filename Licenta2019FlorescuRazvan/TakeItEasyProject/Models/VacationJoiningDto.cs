using CommonTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class VacationJoiningDto : BaseDto
    {
        public string VacationId { get; set; }
        public string UserId { get; set; }
        public StatusJoining StatusJoining { get; set; }
    }
}
