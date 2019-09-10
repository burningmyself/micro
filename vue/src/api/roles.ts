import request from '@/utils/request'

export const getRoles = (params: any) =>
  request({
    url: '/identity/roles',
    method: 'get',
    params
  })

export const createRole = (data: any) =>
  request({
    url: '/identity/roles',
    method: 'post',
    data
  })

export const updateRole = (id: any, data: any) =>
  request({
    url: `/identity/roles/${id}`,
    method: 'put',
    data
  })

export const deleteRole = (id: number) =>
  request({
    url: `/identity/roles/${id}`,
    method: 'delete'
  })

export const getRoutes = (params: any) =>
  request({
    url: '/routes',
    method: 'get',
    params
  })
