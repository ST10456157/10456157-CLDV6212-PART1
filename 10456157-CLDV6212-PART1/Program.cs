using _10456157_CLDV6212_PART1.Services;

var builder = WebApplication.CreateBuilder(args);

string storageConn = builder.Configuration.GetConnectionString("AzureStorage");

// Register services
builder.Services.AddSingleton(new TableStorageService(storageConn));
builder.Services.AddSingleton(new BlobStorageService(storageConn));
builder.Services.AddSingleton(new QueueStorageService(storageConn));
builder.Services.AddSingleton(new FileStorageService(storageConn));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

