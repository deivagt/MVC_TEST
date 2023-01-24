using CLASS_MODELS_TEST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_MVC.ViewModels
{
    public class EditarVehiculoViewModel
    {
        public vehiculosModel vehiculo { get; set; }
        public List<estadoModel> estados { get; set; }
    }
}