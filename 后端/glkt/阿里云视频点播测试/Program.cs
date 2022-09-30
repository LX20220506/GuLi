using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.vod.Model.V20170321;

string uploadAuth = "";
string uploadAddress = "";
string videoId = "";

DefaultAcsClient InitVodClient(string accessKeyId, string accessKeySecret)
{
    // 点播服务接入地域
    string regionId = "cn-shanghai";
    //填写AccessKey信息
    IClientProfile profile = DefaultProfile.GetProfile(regionId, accessKeyId, accessKeySecret);
    return new DefaultAcsClient(profile);
}

// 获取播放地址
void GetVideo() {
    try
    {
        // 构造请求
        GetPlayInfoRequest request = new GetPlayInfoRequest();
        request.VideoId = "8257d5d3aad643d6a704873a4ed6f083";
        request.AuthTimeout = 3600;
        // 初始化客户端
        DefaultAcsClient client = InitVodClient("LTAI5tD2H9j2zDMp39dqmKjK", "8XEgaEi6FQcJKSqQeVdKTcBcJfYjdC");
        // 发起请求，并得到 response
        GetPlayInfoResponse response = client.GetAcsResponse(request);
        Console.WriteLine("RequestId = " + response.RequestId);
        Console.WriteLine("VideoBase.Title = " + response.VideoBase.Title);
        List<GetPlayInfoResponse.GetPlayInfo_PlayInfo> playInfoList = response.PlayInfoList;
        foreach (var playInfo in response.PlayInfoList)
        {
            Console.WriteLine("PlayInfoList.PlayURL = " + playInfo.PlayURL);
        }
    }
    catch (ServerException ex)
    {
        Console.WriteLine(ex.ToString());
    }
    catch (ClientException ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

//GetVideo();


// 上传视频
void ShangChuang() {
    try
    {
        // 构造请求
        CreateUploadVideoRequest request = new CreateUploadVideoRequest();
        request.Title = "测试视频";
        request.FileName = "E:/demo/谷粒课堂/java资料/项目资料/1-阿里云上传测试视频/sample.mp4";


        // request.Tags = "tags1,tags2";
        // request.Description = "this is a sample description";
        //CoverURL示例：http://192.168.0.0/16/sample****.jpg
        // request.CoverURL = "<your Cover URL>";
        // request.CateId = -1;
        // request.TemplateGroupId = "278840921dee4963bb5862b43a52****";
        // 初始化客户端
        DefaultAcsClient client = InitVodClient("LTAI5tD2H9j2zDMp39dqmKjK", "8XEgaEi6FQcJKSqQeVdKTcBcJfYjdC");
        // 发起请求，并得到响应结果
        CreateUploadVideoResponse response = client.GetAcsResponse(request);
        Console.WriteLine("RequestId = " + response.RequestId);
        Console.WriteLine("VideoId = " + response.VideoId);
        Console.WriteLine("UploadAddress = " + response.UploadAddress);
        Console.WriteLine("UploadAuth = " + response.UploadAuth);
        videoId = response.VideoId;
        uploadAddress = response.UploadAddress;
        uploadAuth = response.UploadAuth;
    }
    catch (ServerException ex)
    {
        Console.WriteLine(ex.ToString());
    }
    catch (ClientException ex)
    {
        Console.WriteLine(ex.ToString());
    }
}



// 刷新音/视频上传凭证
void Refresh() {
    try
    {
        // 构造请求
        RefreshUploadVideoRequest request = new RefreshUploadVideoRequest();
        request.VideoId = videoId;

        // 初始化客户端
        DefaultAcsClient client = InitVodClient("LTAI5tD2H9j2zDMp39dqmKjK", "8XEgaEi6FQcJKSqQeVdKTcBcJfYjdC");
        

        // 发起请求，并得到 response
        RefreshUploadVideoResponse response = client.GetAcsResponse(request);
        Console.WriteLine("RequestId = " + response.RequestId);
        Console.WriteLine("UploadAddress = " + response.UploadAddress);
        Console.WriteLine("UploadAuth = " + response.UploadAuth);
    }
    catch (ServerException ex)
    {
        Console.WriteLine(ex.ToString());
    }
    catch (ClientException ex)
    {
        Console.WriteLine(ex.ToString());
    }
}


ShangChuang();

Refresh();