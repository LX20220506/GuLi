import request from "@/utils/request";

const api_name = "/edu/Course";

export default {
  saveCourseInfo(courseInfo) {
    console.log(courseInfo);
    return request({
      url: `${api_name}/SaveCourseInfo`,
      method: "post",
      data: courseInfo
    });
  },

  // 根据id获取信息
  getCourseInfoById(id) {
    return request({
      url: `${api_name}/GetInfoById/${id}`,
      method: "get"
    });
  },

  //课程列表
  getPageList(page, limit, searchObj) {
    console.log(searchObj);
    return request({
      url: `${api_name}/List/${page}/${limit}`,
      method: "post",
      data: searchObj,
      headers: { "content-type": "application/json; charset=utf-8" }
    });
  },

  // 修改课程信息
  updateCourseInfo(courseInfoForm) {
    return request({
      url: `${api_name}/Update`,
      method: "put",
      data: courseInfoForm
    });
  },

  // 根据id删除课程
  removeById(id) {
    return request({
      url: `${api_name}/${id}`,
      method: "delete"
    });
  },

  // 课程id获取课程基本预览信息
  getCoursePublishInfoById(id) {
    return request({
      url: `${api_name}/CoursePublishInfo/${id}`,
      method: "get"
    });
  },

  // 发布课程
  publishCourse(id) {
    return request({
      url: `${api_name}/PublishCourse/${id}`,
      method: "put"
    });
  }
};
