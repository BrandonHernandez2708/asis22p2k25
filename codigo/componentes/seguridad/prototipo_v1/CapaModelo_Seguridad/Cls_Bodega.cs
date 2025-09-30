using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_Seguridad
{
    class Cls_Bodega
    {
        public int codigo_vodega { get; set; }
        public string nombre_bodega { get; set; }

       
       public bool estatus_bodega { get; set; }


        public Cls_Bodega() { }

        public Cls_Bodega(int codigo_vodega, string nombre_bodega,  bool estatus_bodega)
        {
            this.codigo_vodega = codigo_vodega;
            this.nombre_bodega = nombre_bodega;
            this.estatus_bodega = estatus_bodega;
         
        }
    }
}
    

