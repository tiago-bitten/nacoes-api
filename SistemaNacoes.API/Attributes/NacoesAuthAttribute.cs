using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SistemaNacoes.API.Attributes
{
    public class NacoesAuthAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _headerName;
        private readonly string _expectedHeaderValue;

        public NacoesAuthAttribute(string headerName = "X-Nacoes-Auth", string expectedHeaderValue = "@nacoes_adm")
        {
            _headerName = headerName;
            _expectedHeaderValue = expectedHeaderValue;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(_headerName, out var headerValue) ||
                headerValue != _expectedHeaderValue)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}