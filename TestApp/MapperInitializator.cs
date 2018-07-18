using System;
using System.Collections.Generic;
using System.Text;
using HometaskEntity.BLL.Service;

namespace TestApp
{
    public class MapperInitializator
    {
        private static bool isInitialize = false;
        public static void Initialize()
        {
            if (!isInitialize)
            {
                AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile(new MapperService()));
            }
            isInitialize = true;
        }
    }
}
