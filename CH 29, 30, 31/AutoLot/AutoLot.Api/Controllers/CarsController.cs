﻿using System.Collections.Generic;
using AutoLot.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using AutoLot.Models.Entities;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Services.Logging;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

namespace AutoLot.Api.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : BaseCrudController<Car, CarsController>
    {
        public CarsController(ICarRepo carRepo, IAppLogging<CarsController> logger) :
            base(carRepo, logger)
        {
        }
        [HttpGet("bymake/{id?}")]
        public ActionResult<IEnumerable<Car>> GetCarsByMake(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                return Ok(((ICarRepo)MainRepo).GetAllBy(id.Value));
            }
            return Ok(MainRepo.GetAllIgnoreQueryFilters());
        }
    }
}
