using CLASS_MODELS_TEST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_MVC.ViewModels
{
    public class IndexViewModel
    {
        public int estadoSel { get; set; }
        public LinkedList<estadoModel> estados { get; set; }
        public List<vehiculosModel> vehiculos { get; set; }

    }
}