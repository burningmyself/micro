import request from '@/utils/request'

export const getTenants = (params: any) =>
  request({
    url: '/multi-tenancy/tenants',
    method: 'get',
    params
  })

export const updateTenant = (id: any, data: any) =>
  request({
    url: `/multi-tenancy/tenants/${id}`,
    method: 'put',
    data
  })

export const createTenant = (data: any) =>
  request({
    url: '/multi-tenancy/tenants',
    method: 'post',
    data
  })

export const deleteTenant = (id: any) =>
  request({
    url: `/multi-tenancy/tenants/${id}`,
    method: 'delete'    
  })

