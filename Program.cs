

using TaskManagementApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the TaskItemService for dependency injection
builder.Services.AddSingleton<ITaskItemService, TaskItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
TaskItemService srv = new TaskItemService();
foreach (var item in srv.GetAllTasks())
{
    Console.WriteLine($"Task: {item.Title}, Priority: {item.Priority}");
}
// Serve static files from wwwroot
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
