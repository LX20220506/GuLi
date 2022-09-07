using glkt.Common.Middleware;
using glkt.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 添加数据库上下文对象
builder.Services.AddGuLiDbContext(builder.Configuration.GetConnectionString("guli"));

// 添加公共服务
builder.Services.AddCommonService();

// 添加edu的服务
builder.Services.AddEduService();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { 
    c.EnableAnnotations();
});

var app = builder.Build();

// 启用异常中间件
//  注意：进来将异常中间件放到最前面，以此来确保它能拦截到所有可能发生的异常
app.UseMiddleware<CustomExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();
