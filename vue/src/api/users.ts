import request from '@/utils/request'

export const getUsers = (params: any) =>
  request({
    url: '/identity/users',
    method: 'get',
    params,
  })

export const getUserInfo = (data: any) =>
  request({
    url: '/account/info',
    method: 'post',
    data
  })

export const getUserByName = (username: string) =>
  request({
    url: `/identity/users/by-username/${username}`,
    method: 'get'
  })

  export const getUserByEmail = (username: string) =>
  request({
    url: `/identity/users/by-email/${username}`,
    method: 'get'
  })  

export const updateUser = (username: string, data: any) =>
  request({
    url: `/identity/users/${username}`,
    method: 'put',
    data
  })

export const deleteUser = (username: string) =>
  request({
    url: `/identity/users/${username}`,
    method: 'delete'
  })

export const login = (data: any) =>
  request({
    url: '/account/token',
    method: 'post',
    data
  })

export const logout = () =>
  request({
    url: '/account/logout',
    method: 'post'
  })

export const createUser = (data: any) =>
  request({
    url: '/identity/users',
    method: 'post',
    data
  })
