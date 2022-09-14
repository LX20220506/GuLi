import request from "@/utils/request";

const api_name = "/admin/edu/teacher";
export default {
  // 获取数据
  getPageList(page, limit, searchObj) {
    if (searchObj.name==""&&searchObj.level==""&&searchObj.begin==""&&searchObj.end==""){
      return request({
        url: `${api_name}/${page}/${limit}`,
        method: "get",
        data: searchObj
      });
    }else{
      return request({
        url: `${api_name}/${page}/${limit}`,
        method: "post",
        data: JSON.stringify(searchObj),
        // 注意，这里使用axios的post提交时，Content-Type是application/x-www-form-urlencoded
        //      所有一直报415的错误，因此在post提交时，要将Content-Type改为application/json; charset=utf-8
        headers:{"Content-Type":"application/json; charset=utf-8"} 
      });
    }

  },

  // 删除
  removeById(teacherId) {
    return request({
      url: `${api_name}/${teacherId}`,
      method: "delete"
    });
  },

  // 新增
  save(teacher) {
    return request({
      url: api_name,
      method: "post",
      data: teacher
    });
  },

  // 根据id查询记录
  getById(id) {
    return request({
      url: `${api_name}/${id}`,
      method: "get"
    });
  },

  // 更新
  updateById(teacher) {
    return request({
      url: `${api_name}/${teacher.id}`,
      method: "put",
      data: teacher
    });
  }
};
