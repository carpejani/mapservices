using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walliny.Models
{
    public class OfferServices
    {
        public int Id_tb_offer_services { get; set; }
        public int Id_tb_users { get; set; }
        public string Estimation { get; set; }
        public string Price { get; set; }
        public int Id_Services { get; set; }
    }
}
