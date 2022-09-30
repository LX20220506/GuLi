using glkt.Common.CommonServiceExtemsions;
using glkt.Vod.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 添加公众服务
builder.Services.AddCommonService();

// 添加数据库上下文对象
builder.Services.AddGuLiDbContext(builder.Configuration.GetConnectionString("guli"));

// 添加Vod服务
builder.Services.AddVodService(builder.Configuration);

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
