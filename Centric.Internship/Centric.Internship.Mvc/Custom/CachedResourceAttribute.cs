using Microsoft.AspNetCore.Mvc;

namespace Centric.Internship.Mvc.Custom
{
    public class CacheResourceAttribute : TypeFilterAttribute
    {
        public CacheResourceAttribute()
            : base(typeof(CustomResourceFilter))
        {
        }
    }
}