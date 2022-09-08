using glkt.Common.Utils.ReadConfig;
using glkt.Service.OSS;
using glkt.IService.OSS;
using Microsoft.Extensions.Configuration;
using glkt.Common.CommonServiceExtemsions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 将配置文件映射为配置类，并加入到IOC容器中
var OssFile = builder.Configuration.GetSection("AliyunOSSFile");
builder.Services.AddSingleton(OssFile.Get<OssFileConfig>());

// 添加FileService服务
builder.Services.AddScoped<IFileService, FileService>();

// 添加公共服务
builder.Services.AddCommonService();


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

// 启用跨域
app.UseCors("cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
