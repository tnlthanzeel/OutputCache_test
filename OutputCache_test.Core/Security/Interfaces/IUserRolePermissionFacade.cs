using OutputCache_test.Core.Security.Dtos;
using OutputCache_test.SharedKernal.Responses;

namespace OutputCache_test.Core.Security.Interfaces;

public interface IUserRolePermissionFacadeService
{
    Task<ResponseResult> UpdateRoleClaim(Guid roleId, UpdateRoleClaimsDto model, CancellationToken token);
}
