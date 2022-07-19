using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.Meteor
{
    public class AssignUserInfoActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var argument in context.ActionArguments)
            {
                if (argument.Value is IHaveCreatedBy)
                    ((IHaveCreatedBy) argument.Value).CreatedBy = (int) (context.HttpContext.Items["UserId"] ?? -1);
                if (argument.Value is IHaveModifiedBy)
                    ((IHaveModifiedBy) argument.Value).ModifiedBy = (int) (context.HttpContext.Items["UserId"] ?? -1);
                if (argument.Value is IHaveTenant)
                    ((IHaveTenant) argument.Value).TenantId = (int?) context.HttpContext.Items["TenantId"];
                if (argument.Value is IHaveTenant0)
                    ((IHaveTenant0) argument.Value).HasTenant0 = (bool) (context.HttpContext.Items["Common.Core.Owner"] ?? false);
                if (argument.Value is IHaveActionBy)
                    ((IHaveActionBy) argument.Value).ActionBy = (int) (context.HttpContext.Items["UserId"] ?? -1);
                if (argument.Value is IHaveBranch)
                    ((IHaveBranch) argument.Value).BranchId = (int) (context.HttpContext.Items["BranchId"] ?? -1);
            }
        }
    }
}
