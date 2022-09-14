
using MiniExcelDemo;
using MiniExcelLibs;

//var path = Path.Combine("F:\\", $"{Guid.NewGuid()}.xlsx");
//MiniExcel.SaveAsAsync(path, new DemoData[] {
//    new DemoData{ Id=1,Name="张三" },
//    new DemoData{Id = 2, Name = "李四"}
//});

string path = "F:\\a8bffabc-c38d-4917-bcdc-32d27d8f2e69.xlsx";

//var rows = MiniExcel.Query<DemoData>(path).ToList();

// or 
using (var stream = File.OpenRead(path))
{
    var rows = stream.Query<DemoData>().ToList();

	foreach (var item in rows)
	{
		Console.WriteLine(item.Name);
	}
}