﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private Stopwatch stopWatch;
        private ILogger<RequestTimeMiddleware> logger;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            this.stopWatch = new Stopwatch();
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            stopWatch.Start();
            await next.Invoke(context);
            stopWatch.Stop();

            var elapsedMilliseconds = stopWatch.ElapsedMilliseconds;
            if(elapsedMilliseconds / 1000 > 4)
            {
                var message = $"Request [{context.Request.Method}] at {context.Request.Path} took {elapsedMilliseconds} ms";
                logger.LogInformation(message);

            }
        }
    }
}
