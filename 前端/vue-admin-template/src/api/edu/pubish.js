import request from "@/utils/request";

const api_name = "/edu/chapter";

export default {
  previous() {
    console.log("previous");

    this.$router.push({ path: "/edu/course/chapter/" + this.courseId });
  },

  publish() {
    console.log("publish");

    course.publishCourse(this.courseId).then(response => {
      this.$router.push({ path: "/edu/course/list" });
    });
  }
};
