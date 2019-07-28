using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Centric.Internship.Mvc.Custom
{
    public class CustomResourceFilter : IResourceFilter
    {
        private static readonly Dictionary<string, object> _cache
            = new Dictionary<string, object>();

        private string _cacheKey;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomResourceFilter(
            IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _cacheKey = context.HttpContext.Request.Path.ToString();
            if (_cache.ContainsKey(_cacheKey))
            {
                var cachedValue = _cache[_cacheKey] as string;
                if (cachedValue != null)
                {
                    var result = new ViewResult();
                    result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
                    result.ViewData.Add("CachedMessage", cachedValue);

                    context.Result = result;
                }
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (!string.IsNullOrEmpty(_cacheKey) && !_cache.ContainsKey(_cacheKey))
            {
                var result = context.Result as ViewResult;
                if (result != null && result.ViewData["CachedMessage"]!= null)
                {
                    _cache.Add(_cacheKey, result.ViewData["CachedMessage"]);
                }
            }
        }
    }
}