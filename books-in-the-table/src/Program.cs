using books_in_the_table.Interfaces;
using books_in_the_table.Domain;
using books_in_the_table.Data;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAuthor, AuthorDomain>();
builder.Services.AddScoped<IPublisher, PublisherDomain>();
builder.Services.AddScoped<IBook, BookDomain>();
builder.Services.AddScoped<IAuthorPublisher, AuthorPublisherDomain>();

// AddDbContext -> postgres  
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("Default"),
    assembly => assembly.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
    );
});

//AddCors
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:8080")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .AllowAnyOrigin();
                          });
});

// AddAutoMapper 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
