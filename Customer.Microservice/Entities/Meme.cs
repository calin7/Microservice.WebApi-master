using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Entities
{

    public class Meme : BaseEntity
    {
        public string TopText { get; set; }
        public string BottomText { get; set; }

    }
}
