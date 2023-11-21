
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddAuthentication(
				CookieAuthenticationDefaults.AuthenticationScheme).
				AddCookie(x =>
				{
					x.LoginPath = "/Login/Index";

				});
builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});
var app = builder.Build();
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Category}/{action=Index}/{id?}"
        );
});
//app.MapGet("/", () => "Hello World!");
app.UseStaticFiles();
app.Run();
