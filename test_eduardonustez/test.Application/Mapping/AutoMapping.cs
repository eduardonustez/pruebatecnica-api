using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using test.Domain;
using test.Domain.Entities;
using test.Domain.Enums;

namespace test.Application.Profiles
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Factura, FacturaReturnDTO>()
                .ForMember(tar=>tar.Cliente,opt=>opt.MapFrom(src=>src.Cliente.Nombre));
            CreateMap<FacturaDTO, Factura>()
                .ForMember(tar=>tar.TipoDePago,opt=>opt.MapFrom(src=>(TipoPago) src.TipoDePago));
            CreateMap<FacturaDetalleDTO, FacturaDetalle>();
            CreateMap<Producto, ProductoDTO>().ForMember(
                tar=>tar.ProductoId,options=>options.MapFrom(src=>src.Id));
        }
    }
}
