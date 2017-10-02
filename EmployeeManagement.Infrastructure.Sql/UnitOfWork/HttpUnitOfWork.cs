using Microsoft.AspNetCore.Http;
using AspNet.Security.OpenIdConnect.Primitives;

namespace EmployeeManagement.Infrastructure.Sql
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(EmployeeManagementDbContext context, IHttpContextAccessor httpAccessor) : base(context)
        {
            context.CurrentUserId = httpAccessor.HttpContext.User.FindFirst(OpenIdConnectConstants.Claims.Subject)?.Value?.Trim();
        }
    }
}