using AutoMapper;
using MVC.Models;
using MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                
            });
            Mapper = config.CreateMapper();
        }
    }
}