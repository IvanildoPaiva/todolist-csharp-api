var builder = WebApplication.CreateBuilder(args);

// --- 1. DEFINA A POLÍTICA DE CORS AQUI ---
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // Coloque aqui o endereço em que seu React está rodando
                          policy.WithOrigins("http://localhost:5173") 
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// --- 2. ATIVE O CORS AQUI (ANTES DE UseAuthorization) ---
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();