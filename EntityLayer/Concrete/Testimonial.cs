using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }
        public string Commnets { get; set; }
        public string ClientsImage { get; set; }
        public bool Status { get; set; }
    }
}
