﻿using Cars.Core.Domain;
using Cars.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> DetailAsync(Guid id);
        Task<Car> Update(CarDto dto);
    }
}
