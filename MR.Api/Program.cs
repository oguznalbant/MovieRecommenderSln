using Hangfire;
using MR.Api.Configurations;
using MR.Api.Data;
using MR.Api.Data.Abstraction;
using MR.Api.Filters;
using MR.Api.Helper;
using MR.Api.Mapping;
using MR.Api.Repositories;
using MR.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MovieMappingProfile));


builder.Services.AddScoped<SmtpConfiguration>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();
builder.Services.AddScoped<ITMDBService, TMDBService>();
builder.Services.AddScoped<IMovieContext, MovieContext>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddHangfire(x =>
{
    x.UseInMemoryStorage();
});
builder.Services.AddHangfireServer(x => x.Queues = new[] { "comment","moviefetch" });

builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHostedService<HangfireHostedService>(sp => sp.GetRequiredService<IMovieService>());


var app = builder.Build();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangFireAuthorizationFilter() },
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

RecurringJob.AddOrUpdate<IMovieService>(x => x.AutoFetchMovies(), Cron.Minutely, null, "moviefetch");

app.Run();
