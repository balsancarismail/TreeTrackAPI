using System.Reflection;
using TreeTrackAPI.DataAccessLayer.abstracts;
using TreeTrackAPI.DataAccessLayer.concretes.efcore;
using TreeTrackAPI.DataAccessLayer.concretes.efcore.dals;
using TreeTrackAPI.Services.concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BaseDbContext>();
builder.Services.AddScoped<IGardenDal, EfGardenDal>();
builder.Services.AddScoped<INoteDal, EfNoteDal>();
builder.Services.AddScoped<IPlantDal, EfPlantDal>();
builder.Services.AddScoped<IPlantTypeDal, EfPlantTypeDal>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped(typeof(GardenService));
builder.Services.AddScoped(typeof(NoteServices));
builder.Services.AddScoped(typeof(PlantService));
builder.Services.AddScoped(typeof(PlantTypeService));
builder.Services.AddScoped(typeof(UserService));
builder.Services.AddAutoMapper(Assembly.Load("TreeTrackAPI.Services"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
