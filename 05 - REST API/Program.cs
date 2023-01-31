using DbProject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddTransient<PositionLogic>(); // all og this is for enabling the DI in the controller classes.
builder.Services.AddTransient<GroupLogic>();
builder.Services.AddTransient<WordsVsGroupLogic>();
builder.Services.AddTransient<SongsLogic>();
builder.Services.AddTransient<WordsLogic>();
builder.Services.AddTransient<LinguisticExpressionLogic>();
builder.Services.AddTransient<ExpressionVsPositionLogic>();





builder.Services.AddCors(setup => setup.AddPolicy("EntireWorld", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


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

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
