using ProyectoMedidor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configurar MVC
builder.Services.AddControllersWithViews();

// Configurar HttpClient y la inyecci�n de dependencias para la interfaz y la implementaci�n
builder.Services.AddHttpClient<IApiService, ApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Forzar HTTPS en entornos de producci�n
}

// Middleware para servir archivos est�ticos como CSS, JS, im�genes, etc.
app.UseStaticFiles();

app.UseRouting();

// Middleware para la autorizaci�n (si decides implementarla en el futuro)
app.UseAuthorization();

// Configura la ruta predeterminada para el patr�n MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia la aplicaci�n
app.Run();
