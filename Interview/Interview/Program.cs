using Interview.AppCore.Contract.Repositories;
using Interview.AppCore.Contract.Services;
using Interview.Infrastructure.Data;
using Interview.Infrastructure.Repositories;
using Interview.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Interview.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add services
builder.Services.AddScoped<IInterviewRecordRepository, InterviewRecordRepository>();
builder.Services.AddScoped<IInterviewRecordService, InterviewRecordService>();
builder.Services.AddScoped<IInterviewerRepository, InterviewerRepository>();
builder.Services.AddScoped<IInterviewerService, InterviewerService>();
builder.Services.AddScoped<IInterviewFeedbackRepository, InterviewFeedbackRepository>();
builder.Services.AddScoped<IInterviewFeedbackService,InterviewFeedbakService>();
builder.Services.AddScoped<IInterviewTypeRepository, InterviewTypeRepository>();
builder.Services.AddScoped<IInterviewTypeService, InterviewTypeService>();
builder.Services.AddScoped<IRecruiterRepository, RecruiterRepository>();
builder.Services.AddScoped<IRecruiterService, RecruiterService>();
builder.Services.AddLogging();
var connectionStr = Environment.GetEnvironmentVariable("InterviewDb");
builder.Services.AddDbContext<InterviewDbContext>(options =>
{
    if(connectionStr != null && connectionStr.Length >1)
    {
        options.UseSqlServer(connectionStr);
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("InterviewDb"));
    }
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseExceptionMiddleware();
app.Run();
