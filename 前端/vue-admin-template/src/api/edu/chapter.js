import request from "@/utils/request";

const api_name = "/edu/chapter";

export default {
  getNestedTreeList(courseId) {
    return request({
      url: `${api_name}/GetChapterList/${courseId}`,
      method: "get"
    });
  },

  removeById(id) {
    return request({
      url: `${api_name}/${id}`,
      method: "delete"
    });
  },

  save(chapterRequest) {
    return request({
      url: api_name,
      method: "post",
      data: chapterRequest
    });
  },

  getById(id) {
    return request({
      url: `${api_name}/${id}`,
      method: "get"
    });
  },

  updateById(chapter) {
    return request({
      url: `${api_name}`,
      method: "put",
      data: chapter
    });
  },

  previous() {
      console.log('previous')
      this.$router.push({ path: '/edu/course/info/' + this.courseId })
    },

    next() {
      console.log('next')
      this.$router.push({ path: '/edu/course/publish/' + this.courseId })
    }
};
