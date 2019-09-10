import { RouteConfig } from 'vue-router'
import Layout from '@/layout/index.vue'

const systemRouter: RouteConfig = {
    path: '/system',
    name: 'AbpIdentity',
    meta: {
        icon: 'logo-buffer',
        title: 'system'
    },
    component: Layout,
    children: [{
        path: 'users',
        name: 'AbpIdentity.Users',
        meta: {
            icon: 'md-contact',
            title: 'users'
        },
        component: () => import( /* webpackChunkName: "system" */ '@/views/system/user/index.vue')
    }, {
        path: 'roles',
        name: 'AbpIdentity.Roles',
        meta: {
            icon: 'md-contacts',
            title: 'roles'
        },
        component: () => import( /* webpackChunkName: "system" */ '@/views/system/role/index.vue')
    }, {
        path: 'tenants',
        name: 'AbpTenantManagement.Tenants',
        meta: {
            icon: 'md-menu',
            title: 'tenants'
        },
        component: () => import('@/views/system/tenants.vue')
    },]
}


export default systemRouter
