using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeospatialProject.Models
{
    public class Sismo
    {
        public double magnitud { get; set; }
        public double profundidad { get; set; }
        public string departamento { get; set; }
        public int anio { get; set; }
    }
}