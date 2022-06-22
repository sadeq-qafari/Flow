using System.Threading.Tasks;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Identity.Operations.Database.PersistedGrant.Commands
{
    public class UpsertPersistedGrant : DbOperationAsync<IdentityServer4.Models.PersistedGrant, bool>
    {
        protected override async Task ExecutionAsync()
        {
            const string sqlText = @"
IF EXISTS (SELECT TOP 1 1 FROM [Identity].PersistedGrant WHERE [Key] = @Key)
BEGIN
  UPDATE [Identity].PersistedGrant
  SET Type = @Type
     ,SubjectId = @SubjectId
     ,ClientId = @ClientId
     ,CreationTime = @CreationTime
     ,Expiration = @Expiration
     ,Data = @Data
     ,SessionId = @SessionId
     ,Description = @Description
     ,ConsumedTime = @ConsumedTime
     ,ModifiedAt = GETDATE()
  WHERE [Key] = @Key;
END
ELSE
BEGIN
  INSERT [Identity].PersistedGrant
    ([Key], Type, SubjectId, ClientId, CreationTime, Expiration, Data, CreatedBy, CreatedAt, SessionId, Description, ConsumedTime)
  VALUES
    (@Key, @Type, @SubjectId, @ClientId, @CreationTime, @Expiration, @Data, 0, GETDATE(), @SessionId, @Description, @ConsumedTime);
END
";
            await NewSql(sqlText, new PersistedGrant
                {
                    Key = Input.Key,
                    Type = Input.Type,
                    SubjectId = Input.SubjectId,
                    ClientId = Input.ClientId,
                    CreationTime = Input.CreationTime.ToInstant(),
                    Expiration = Input.Expiration?.ToInstant(),
                    Data = Input.Data,
                    SessionId = Input.SessionId,
                    Description = Input.Description,
                    ConsumedTime = Input.ConsumedTime?.ToInstant()
                })
                .ExecuteAsync()
                .ValidateDatabaseAffectedRows();

            Output = true;
        }
    }
}
