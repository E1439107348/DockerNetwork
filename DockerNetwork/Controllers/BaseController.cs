﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerNetwork.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerNetwork.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BaseController : Controller
    {

        protected UserIdentity UserIdentity => new UserIdentity { UserId = 1, Name = "qy" };




    }
}