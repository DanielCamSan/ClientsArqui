﻿using AutoMapper;
using Practicando_WEBAPI.Data.Entities;
using Practicando_WEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Data
{
    public class AutoMapperProfile:Profile
    {


        public AutoMapperProfile()
        {
            this.CreateMap <ClientEntity, ClientModel > ()
            .ReverseMap();

            this.CreateMap<ClientModel, ClientEntity>()
                   .ReverseMap();
        }
    }
}
