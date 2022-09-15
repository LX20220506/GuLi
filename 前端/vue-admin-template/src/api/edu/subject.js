import request from '@/utils/request'

const api_name = '/subject/list'

export default {

  getNestedTreeList() {
    return request({
      url: `${api_name}`,
      method: 'get'
    })
  }
}