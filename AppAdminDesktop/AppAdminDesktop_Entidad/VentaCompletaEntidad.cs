﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norah_API.Models.Entidad
{
    public class VentaCompletaEntidad
    {
        public int ID_VENTA { get; set; }
        public System.DateTime FECHA_VENTA { get; set; }
        public double MONTO { get; set; }
        public double IVA { get; set; }
        public Nullable<int> DIAS_TARDA { get; set; }
        public double COSTO_ENVIO { get; set; }
        public String ESTADO_ENVIO { get; set; }
        public Nullable<int> ID_DIRECCION { get; set; }
        public int ID_USURIO { get; set; }
        public String  ESTADO_VENTA { get; set; }
        public String METODO_PAGO { get; set; }
        public Nullable<double> SATISFACION { get; set; }
        public string OBSERVACIONES { get; set; }
        public Nullable<int> COMO_REGALO { get; set; }
        public String COD_DES { get; set; }
        public String COD_AFILIADO { get; set; }
        public string CODIGO_RASTREO { get; set; }
        public int ESTADO { get; set; }
        public String IMAGEN { get; set; }
        public List<DetalleVentaCompleto> detalles { get; set; }
    }
}