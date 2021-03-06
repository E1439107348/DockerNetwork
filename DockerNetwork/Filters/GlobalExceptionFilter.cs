﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerNetwork.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;//当前环境获取  
        private readonly ILogger<GlobalExceptionFilter> _logger;//日志
        public GlobalExceptionFilter(IHostingEnvironment env, ILogger<GlobalExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var json = new JsonErrorResponse();
            if (context.Exception.GetType() == typeof(UserOperationException))
            {


                json.Message = context.Exception.Message;
                context.Result = new BadRequestObjectResult(json);
            }
            else
            {

               json.Message = "发生了未知内部错误" ;
                //如果是开发环境
                if (_env.IsDevelopment())
                {
                    json.DeveloperMessage = context.Exception.StackTrace;
                }
                context.Result = new InternalServerErrorObjectRosult(json);
            }


            _logger.LogError(context.Exception, context.Exception.Message);//日志记录
            context.ExceptionHandled = true;
        }
    }


    public class InternalServerErrorObjectRosult : ObjectResult
    {
        public InternalServerErrorObjectRosult(object error) : base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
