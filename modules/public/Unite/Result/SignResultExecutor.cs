using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Unite.Result
{
    public class SignResultExecutor : IActionResultExecutor<SignResult>
    {

        private const string DefaultContentType = "text/plain; charset=utf-8";
        private readonly IHttpResponseStreamWriterFactory _httpResponseStreamWriterFactory;

        public SignResultExecutor(IHttpResponseStreamWriterFactory httpResponseStreamWriterFactory)
        {
            _httpResponseStreamWriterFactory = httpResponseStreamWriterFactory;
        }
        public async Task ExecuteAsync(ActionContext context, SignResult result)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            var response = context.HttpContext.Response;
            ResponseContentTypeHelper.ResolveContentTypeAndEncoding(
                null,
                response.ContentType,
                DefaultContentType,
                out var resolvedContentType,
                out var resolvedContentTypeEncoding);
            response.ContentType = resolvedContentType;
            var defaultContentTypeEncoding = MediaType.GetEncoding(response.ContentType);
            if (result.Value != null)
            {
                string content = JsonConvert.SerializeObject(result.Value);
                response.ContentLength = resolvedContentTypeEncoding.GetByteCount(content);
                using (var textWriter = _httpResponseStreamWriterFactory.CreateWriter(response.Body, resolvedContentTypeEncoding))
                {
                    await textWriter.WriteAsync(content);
                    await textWriter.FlushAsync();
                }
            }
        }
    }
}
