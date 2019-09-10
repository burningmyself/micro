using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Unite.Result
{
    public class SignResult : ActionResult
    {
        public SignResult()
        {
        }

        public SignResult(object value)
        {
            Value = value;
        }

        public object Value { get; set; }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentException(nameof(context));
            }
            var executor = context.HttpContext.RequestServices.GetRequiredService<IActionResultExecutor<SignResult>>();
            //return base.ExecuteResultAsync(context);
            return executor.ExecuteAsync(context, this);
        }
    }
}
