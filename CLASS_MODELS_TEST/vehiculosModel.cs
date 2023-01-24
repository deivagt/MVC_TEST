using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLASS_MODELS_TEST
{
    public class vehiculosModel
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string color { get; set; }

        public int modelo { get; set; }

        public decimal precio { get; set; }

        public DateTime fechaRec { get; set; }
        public int idEstado { get; set; }
        public string estado { get; set; }
    }
}
