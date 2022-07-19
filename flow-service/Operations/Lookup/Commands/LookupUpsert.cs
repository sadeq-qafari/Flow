using System.Threading.Tasks;
using Core.Meteor.Extensions;
using Dapper;
using Flow.Operations.Lookup.Dtos;
using Meteor.Operation.Db;

namespace Flow.Operations.Lookup.Commands
{
    public class LookupUpsert : DbOperationAsync<LookupUpsertInDto, int>
    {
        protected override async Task ExecutionAsync()
        {
            var dt = Input.Items.AsDataTable("Flow.udt_LookupItem", x => new
            {
                x.Id,
                x.Title,
                x.Value,
                x.Description,
                x.Index,
                x.Icon,
                x.ColorHex
            });

            var parameters = new DynamicParameters();
            parameters.Add("Id", Input.Id);
            parameters.Add("TypeLookup", Input.TypeLookup);
            parameters.Add("Title", Input.Title);
            parameters.Add("Query", Input.Query);
            parameters.Add("Description", Input.Description);
            parameters.Add("Items", dt.AsTableValuedParameter("Flow.udt_LookupItem"));
            parameters.Add("ActionBy", Input.ActionBy);
            parameters.Add("TenantId", Input.TenantId);

            Output = await NewSql(@"EXECUTE Flow.sp_LookupUpsert @Id = @Id
                            ,@TypeLookup = @TypeLookup
                            ,@Title = @Title
                            ,@Query = @Query 
                            ,@Description = @Description
                            ,@Items = @Items 
                            ,@ActionBy = @ActionBy 
                            ,@TenantId = @TenantId", parameters).ExecuteScalarAsync<int>();
        }
    }
}
