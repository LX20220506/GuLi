import request from '@/utils/request'

const api_name = '/edu/video'

export default {

  saveVideoInfo(videoInfo) {
    return request({
      url: `${api_name}/SaveVideoInfo`,
      method: 'post',
      data: videoInfo
    })
  },

  getVideoInfoById(id) {
    return request({
      url: `${api_name}/${id}`,
      method: 'get'
    })
  },

  updateVideoInfoById(videoInfo) {
    return request({
      url: `${api_name}`,
      method: 'put',
      data: videoInfo
    })
  },

  removeById(id) {
    return request({
      url: `${api_name}/${id}`,
      method: 'delete'
    })
  }
}