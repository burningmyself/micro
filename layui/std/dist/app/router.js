layui.define([], function(e) {
	'use strict';

	e('menu', [{
		id: 'AbpHome',
		text: '主页',
		url: '',
		class: 'layui-nav-itemed',
		icon: 'layui-icon-home',
		children: [{
			id: 'AbpHome.Console',
			text: '控制台',
			class: 'layui-this',
			url: 'home/console.html',
			icon: '',
			children: null
		}]
	}, {
		id: 'AbpIdentity',
		text: '权限控制',
		url: '',
		class: '',
		icon: 'layui-icon-user',
		children: [{
			id: 'AbpIdentity.Users',
			text: '用户',
			url: 'user/administrators/list.html',
			icon: '',
			class: '',
			children: null
		}, {
			id: 'AbpIdentity.Roles',
			text: '角色',
			class: '',
			url: 'user/administrators/role.html',
			icon: '',
			children: null
		}]
	}])

});
