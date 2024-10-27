using InmobiliariaUNAH.Services.Interfaces;

namespace InmobiliariaUNAH.Services
{
    public class AuditService : IAuditService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuditService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            var idClaim = _httpContextAccessor.HttpContext
                .User.Claims.Where(x => x.Type == "UserId").FirstOrDefault();

            return idClaim.Value;
        }
    }
}
