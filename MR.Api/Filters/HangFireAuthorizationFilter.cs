using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace MR.Api.Filters
{
    public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true; //TODO:
        }
    }
}
