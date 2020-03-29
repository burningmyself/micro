import { RouteConfig } from 'vue-router'
import Layout from '@/layout/index.vue'

const systemRouter: RouteConfig = {
  path: '/system',
  name: 'AbpIdentity',
  meta: {
    icon: 'component',
    title: 'system'
  },
  component: Layout,
  children: [{
    path: 'users',
    name: 'AbpIdentity.Users',
    meta: {
      title: 'users'
    },
    component: () => import(/* webpackChunkName: "system" */ '@/views/system/user/index.vue')
  }, {
    path: 'roles',
    name: 'AbpIdentity.Roles',
    meta: {
      title: 'roles'
    },
    component: () => import(/* webpackChunkName: "system" */ '@/views/system/role/index.vue')
  }, {
    path: 'tenants',
    name: 'AbpTenantManagement.Tenants',
    meta: {
      title: 'tenants'
    },
    component: () => import('@/views/system/tenant/index.vue')
  }]
}

export default systemRouter
