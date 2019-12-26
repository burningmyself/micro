import request from '@/utils/request'
import { Interface } from 'readline'

export const getUsers = (params: any) =>
  request({
    url: '/identity/users',
    method: 'get',
    params
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

export const getUserGrantPermission = (data: string) =>
  request({
    url: '/Account/getUserGrantPermission/permission/' + data,
    method: 'get'
  })

export const getPermissionByUserId = (data: string) =>
  request({
    url: `identity/users/${data}/roles`,
    method: 'get'
  })

export const updateUserIsRoleAndPermission = (data: UserAndRoleRoot) =>
  request({
    url: `Account/updateUserIsRoleAndPermission/userPermission`,
    method: 'post',
    data
  })

export interface UserAndRoleRoot {
  grantPermission: Array<string>
  grantRoles: Array<string>
  id: string
}
