﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CadenaDAL
    {
        public string cadena { get; set; }

        public CadenaDAL()
        {
            cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        }
    }
}
