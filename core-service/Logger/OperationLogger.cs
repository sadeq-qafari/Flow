using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Meteor;
using Meteor.Logger;
using Meteor.Operation;
using Meteor.Operation.Db.Default;
using Meteor.Utils;
using Saanaa.Core.Meteor;
using Serilog;
using Serilog.Events;

namespace Saanaa.Core.Logger
{
    public class OperationLogger : IOperationLoggerAsync
    {
        private readonly OperationFactory _operationFactory;

        public OperationLogger(OperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public async Task LogAsync(IOperationAsync operation)
        {
            Log.Information("Operation '{Name}({State})', Input: {@Input}, Output: {@Output}",
                operation.GetType().Name, operation.State, operation.Input, operation.Output);

            // if (operation.State != OperationState.Failed)
            //     return;

            int? userId = 0;
            int? tenantId = 0;
            var type = "General";
            var tableName = (operation as IHaveTableName)?.TableName;
            long? entityId = (operation.Input as IDbModel<int>)?.Id;
            switch (operation.Input)
            {
                case IAmDbSelect o:
                    return; // todo: prevented from logging select operations
                    tenantId = o.TenantId;
                    type = "Select";
                    break;
                case IAmDbInsert o:
                    userId = o.CreatedBy;
                    tenantId = o.TenantId;
                    entityId = operation.Output as long?;
                    type = "Insert";
                    break;
                case IAmDbDelete o:
                    userId = o.ModifiedBy;
                    tenantId = o.TenantId;
                    type = "Delete";
                    break;
                case IAmDbUpdate o:
                    userId = o.ModifiedBy;
                    tenantId = o.TenantId;
                    type = "Update";
                    break;

                default:
                    if (operation is not INeedLog && operation.Input is not INeedLog)
                        return;

                    var props = operation.Input?.GetType().GetProperties();
                    if (props != null)
                    {
                        tenantId = (int?) props.FirstOrDefault(x => x.Name == "TenantId")?.GetValue(operation.Input)
                                   ?? tenantId;
                        userId = (int?) props.FirstOrDefault(x => x.Name == "ActionBy")?.GetValue(operation.Input)
                                 ?? (int?) props.FirstOrDefault(x => x.Name == "CreatedBy")?.GetValue(operation.Input)
                                 ?? (int?) props.FirstOrDefault(x => x.Name == "ModifiedBy")?.GetValue(operation.Input)
                                 ?? userId;
                    }

                    break;
            }


            var res = await _operationFactory.New<AddSaanaaLog>().ExecuteAsync(new AddSaanaaLogInDto
            {
                Service = EnvVars.Get("SERVICE_NAME"),
                TableName = tableName,
                UserId = userId,
                EntityId = entityId,
                TenantId = tenantId,
                Type = type,
                Message = $"{operation.GetType().Name}({operation.State})",
                MessageTemplate = "{Name}({State})",
                Level = LogEventLevel.Information,
                Exception = null,
                Properties = new
                {
                    operation.Input,
                    operation.Output
                }.ToJson()
            });
        }
    }
}
