using Identity.Operations.Database.Branch.Dtos;
using Meteor.Database.SqlDialect;
using Core.Meteor;

namespace Identity.Operations.Database.Branch.Queries
{
    public class GetBranchPage : DbQueryPage<BranchDto>
    {
        public GetBranchPage() : base("[Identity].[Branch]")
        {
        }



        protected override ISqlDialect GetSelectSql(bool isForCount = false)
        {

            return SqlFactory!.Create().Select("[Identity].[Branch] Branch", isForCount ? "COUNT(*)" : @"
						Branch.*, 
						Parent.Title AS ParentTitle")
                .LeftJoin("[Identity].[Branch] Parent",  "Branch.ParentId = Parent.Id  AND  Parent.IsDeleted=0");
        }

        protected override string GetFieldName(string fieldName) =>
            $"[Branch].[{fieldName}]";
    }
}
