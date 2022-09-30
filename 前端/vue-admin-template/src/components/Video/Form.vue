<template>
  <!-- 添加和修改课时表单 -->
  <el-dialog :visible="dialogVisible" title="添加课时" @close="close()">
    <el-form :model="video" label-width="120px">
      <el-form-item label="课时标题">
        <el-input v-model="video.title" />
      </el-form-item>
      <el-form-item label="课时排序">
        <el-input-number v-model="video.sort" :min="0" />
      </el-form-item>
      <el-form-item label="是否免费">
        <el-radio-group v-model="video.isFree">
          <el-radio :label="0">免费</el-radio>
          <el-radio :label="1">默认</el-radio>
        </el-radio-group>
      </el-form-item>

      <el-form-item label="上传视频">
        <el-upload
          :on-success="handleVodUploadSuccess"
          :on-remove="handleVodRemove"
          :before-remove="beforeVodRemove"
          :on-exceed="handleUploadExceed"
          :file-list="fileList"
          :action="BASE_API + '/admin/vod/video/upload'"
          :limit="1"
          class="upload-demo"
        >
          <el-button size="small" type="primary">上传视频</el-button>
          <el-tooltip placement="right-end">
            <div slot="content">
              最大支持1G，<br />
              支持3GP、ASF、AVI、DAT、DV、FLV、F4V、<br />
              GIF、M2T、M4V、MJ2、MJPEG、MKV、MOV、MP4、<br />
              MPE、MPG、MPEG、MTS、OGG、QT、RM、RMVB、<br />
              SWF、TS、VOB、WMV、WEBM 等视频格式上传
            </div>
            <i class="el-icon-question" />
          </el-tooltip>
        </el-upload>
      </el-form-item>
    </el-form>
    <div slot="footer" class="dialog-footer">
      <el-button @click="close()">取 消</el-button>
      <el-button type="primary" @click="saveOrUpdate()">确 定</el-button>
    </div>
  </el-dialog>
</template>

<script>
import videoApi from '@/api/edu/video'
//import vodApi from '@/api/vod/vod'
import vod from '@/api/edu/vod'

export default {
  data() {
    return {
      dialogVisible: false,
      video: {
        sort: 0,
        free: false,
      },
      fileList: [], //上传文件列表
      BASE_API: process.env.BASE_API, // 接口API地址
      uploadBtnDisabled: false,
      uploader: null,
    };
  },

  methods: {
    open(chapterId, videoId) {
      this.dialogVisible = true;
      this.video.chapterId = chapterId;
      if (videoId) {
        videoApi.getById(videoId).then((response) => {
          this.video = response.data;
          // 回显
          if (this.video.videoOriginalName) {
            this.fileList = [{ name: this.video.videoOriginalName }];
          }
        });
      }
    },

    close() {
      this.dialogVisible = false;
      // 重置表单
      this.resetForm();
    },

    resetForm() {
      this.video = {
        sort: 0,
        free: false,
      };

      this.fileList = []; // 重置视频上传列表
    },

    saveOrUpdate() {
      if (!this.video.id) {
        this.save();
      } else {
        this.update();
      }
    },

    save() {
      this.video.courseId = this.$parent.$parent.courseId;
      videoApi.save(this.video).then((response) => {
        this.$message.success(response.message);
        // 关闭组件
        this.close();
        // 刷新列表
        this.$parent.fetchNodeList();
      });
    },

    update() {
      videoApi.updateById(this.video).then((response) => {
        this.$message.success(response.message);
        // 关闭组件
        this.close();
        // 刷新列表
        this.$parent.fetchNodeList();
      });
    },

    // 上传多于一个视频
    handleUploadExceed(files, fileList) {
      this.$message.warning("想要重新上传视频，请先删除已上传的视频");
    },

    // 上传
    submitUpload() {
      this.uploadBtnDisabled = true;
      this.$refs.upload.submit(); // 提交上传请求
    },

    // 视频上传成功的回调
    handleUploadSuccess(response, file, fileList) {
      this.uploadBtnDisabled = false;
      this.video.videoSourceId = response.data;
      this.video.videoOriginalName = file.name;
    },

    // 失败回调
    handleUploadError() {
      this.uploadBtnDisabled = false;
      this.$message.error("上传失败2");
    },

    // 删除视频文件确认
    handleBeforeRemove(file, fileList) {
      return this.$confirm(`确定移除 ${file.name}？`);
    },

    // 执行视频文件的删除
    handleOnRemove(file, fileList) {
      if (!this.video.videoSourceId) {
        return;
      }
    },

    authUpload() {
      // 然后调用 startUpload 方法, 开始上传
      if (this.uploader !== null) {
        this.uploader.startUpload();
        this.uploadDisabled = true;
        this.pauseDisabled = false;
      }
    },

    //成功回调
    handleVodUploadSuccess(response, file, fileList) {
      this.video.videoSourceId = response.data.videoId;
    },

    //视图上传多于一个视频
    handleUploadExceed(files, fileList) {
      this.$message.warning("想要重新上传视频，请先删除已上传的视频");
    },

    beforeVodRemove(file, fileList) {
      return this.$confirm(`确定移除 ${file.name}？`);
    },
    handleVodRemove(file, fileList) {
      console.log(file);
      vod.removeById(this.video.videoSourceId).then((response) => {
        this.$message({
          type: "success",
          message: response.message,
        });
      });
    },
  },

  created() {
    // 有视频时调用视频播放凭证获取视频封面回显，点击即可播放视频
    this.videoId = this.vId;
    if (this.videoId !== "") {
      getPlayAuth(this.videoId).then((res) => {
        this.$set(this, "coverURL", res.videoMeta.coverURL);
      });
    }
    // 根据父组件传入的sort，查找config中对应的分类信息
    this.videoSortParams = config.videoSort.filter(
      (item) => item.sort === this.sort
    )[0];
  },
};
</script>