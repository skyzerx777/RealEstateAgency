using Microsoft.AspNetCore.Identity;

namespace RealEstateAgency
{
    public class ExpireSessionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TimeSpan _expireTimeSpan;

        public ExpireSessionMiddleware(RequestDelegate next, TimeSpan expireTimeSpan)
        {
            _next = next;
            _expireTimeSpan = expireTimeSpan;
        }

        public async Task Invoke(HttpContext context, SignInManager<IdentityUser> signInManager)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var lastActivity = context.Session.GetString("LastActivity");

                if (!string.IsNullOrEmpty(lastActivity) && DateTime.TryParse(lastActivity, out DateTime lastActivityTime))
                {
                    if (DateTime.UtcNow - lastActivityTime > _expireTimeSpan)
                    {
                        // Время сеанса истекло, выход из аккаунта
                        await signInManager.SignOutAsync();
                    }
                }
            }

            // Обновляем время последней активности
            context.Session.SetString("LastActivity", DateTime.UtcNow.ToString("O"));

            await _next(context);
        }
    }

}
