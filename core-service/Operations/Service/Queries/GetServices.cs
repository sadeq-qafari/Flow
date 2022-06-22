using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto;
using Core.Operations.Service.Dto;
using Meteor.Operation.Db;
using Saanaa.Core.Meteor;

namespace Core.Operations.Service.Queries
{
    public class GetServices : DbOperationAsync<GetServicesInDto, SaanaaServicesDto>
    {
        protected override async Task ExecutionAsync()
        {
            var requestedVersion = Input.Version.GetValueOrDefault(0);
            if (requestedVersion <= 0 || requestedVersion != SaanaaServices.LatestVersion)
            {
                var names = await NewSql(sql => sql.Select("[Identity].[TenantService] TenantService","Service.Name")
                    .InnerJoin("[Core].[Service] Service", "Service.Id = TenantService.ServiceId AND TenantService.TenantId = @TenantId AND TenantService.IsDeleted = 0 AND Service.IsDeleted = 0")
                ).QueryAsync<string>();
                Output = GetSaanaaServicesDto(string.Join(',', names));
            }
            else
            {
                Output = null;
            }
        }

        private static SaanaaServicesDto GetSaanaaServicesDto(string? names)
        {
            var serviceNames = names?.Split(',').Select(x => x.Trim()).ToList() ?? new List<string>();
            return new SaanaaServicesDto
            {
                Services = SaanaaServices.GetServices(serviceNames),
                Version = SaanaaServices.LatestVersion
            };
        }
    }
}
