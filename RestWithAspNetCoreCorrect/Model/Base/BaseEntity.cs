﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RestWithAspNetCoreCorrect.Model.Base
{
    //Contrato entre atributos e a estrutura da tabela
    [DataContract]
    public class BaseEntity
    {
        public long id { get; set; }
    }
}
