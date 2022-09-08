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
        url: `${api_name}/search`,
        method: "post",
        data: searchObj
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
