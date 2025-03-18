using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container (DI Container)
builder.Services.AddRazorPages();

var app = builder.Build();


//Content Security Policy(CSP)

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Content-Security-Policy", "default-src 'self'");
    await next.Invoke();
});


// Configure the HTTP request pipeline


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware for logging requests and responses
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
    Console.WriteLine($"Response: {context.Response.StatusCode}");
});

app.UseHttpsRedirection();

// Middleware to serve static files
app.UseStaticFiles();

// Middleware to enforce HTTPS
app.UseHttpsRedirection();

// Handle errors and return custom error page
app.UseStatusCodePages("text/plain", "Status Code Page, Status Code: {0}");

app.MapRazorPages();

app.Run();
