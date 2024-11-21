using ProyectoMedidor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configurar MVC
builder.Services.AddControllersWithViews();

// Configurar HttpClient y la inyección de dependencias para la interfaz y la implementación
builder.Services.AddHttpClient<IApiService, ApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Forzar HTTPS en entornos de producción
}

// Middleware para servir archivos estáticos como CSS, JS, imágenes, etc.
app.UseStaticFiles();

app.UseRouting();

// Middleware para la autorización (si decides implementarla en el futuro)
app.UseAuthorization();

// Configura la ruta predeterminada para el patrón MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia la aplicación
app.Run();
