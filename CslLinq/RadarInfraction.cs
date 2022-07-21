using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslLinq
{
    public class RadarInfraction
    {


        public RadarInfraction()
        {

        }

        public int departement { get; set; }
        public string? dateMiseEnService { get; set; }
        public string? voie { get; set; }
        public string? sensCirculation { get; set; }

        public int nbreInfraction { get; set; }


    }

}
