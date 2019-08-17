using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walliny.Models
{
    public class Request
    {

          //public int Id_Services { get; set; }
          public int Id_tb_tipo_services { get; set; }
          public string Id_tb_users { get; set; }
          public string Lat_start_user { get; set; }
          public string Log_end_user { get; set; }
          public string Estimation { get; set; }
          public string Data_request { get; set; }
          public string Status { get; set; }
          public string InputEntry { get; set; }

    }
}
