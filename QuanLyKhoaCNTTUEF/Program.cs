using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication()
        .AddGoogle(opts =>
        {
            opts.ClientId = "365724471869-j61qj1obqh6ogliiucar2pqg1ameuh31.apps.googleusercontent.com";
            opts.ClientSecret = "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";
            opts.SignInScheme = IdentityConstants.ExternalScheme;
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
