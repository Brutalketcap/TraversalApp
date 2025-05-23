﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IGuideService : IGenericService<Guide>
    {
        void TChangeToTureByGuid(int id);
        void TChangeToFalseByGuid(int id);
    }
}
