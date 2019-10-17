layui.define([], function(e) {
	'use strict';
	let admin = layui.admin,
		api = layui.api



	e('login', function(data) {
		return admin.req({
			url: api.identity + 'account/token',
			type: 'POST',
			data: JSON.stringify(data),
			headers: {
				'Content-Type': 'application/json-patch+json'
			}
		})
	})



	e('userInfo', function() {
		return admin.req({
			url: api.identity + 'account/info',
			type: 'POST',
			headers: {
				'Content-Type': 'application/json-patch+json',
				'Authorization': `Bearer ${localStorage.getItem('token')}`
			}
		})
	})



	e('delUser', function(data) {
		return admin.req({
			url: api.identity + 'identity/users/' + data,
			type: 'DELETE',
			headers: {
				'Content-Type': 'application/json-patch+json',
				'Authorization': `Bearer ${localStorage.getItem('token')}`
			}
		})
	})



	e('addUser', function(data) {
		return admin.req({
			url: api.identity + 'identity/users',
			type: 'POST',
			data: JSON.stringify(data),
			headers: {
				'Content-Type': 'application/json-patch+json',
				'Authorization': `Bearer ${localStorage.getItem('token')}`
			}
		})
	})


	e('putUser', function(data) {
		return admin.req({
			url: api.identity + 'identity/users/' + data.id,
			type: 'PUT',
			data: JSON.stringify(data),
			headers: {
				'Content-Type': 'application/json-patch+json',
				'Authorization': `Bearer ${localStorage.getItem('token')}`
			}
		})
	})

	e('addRole', function(data) {
		return admin.req({
			url: api.identity + 'identity/roles',
			type: 'POST',
			data: JSON.stringify(data),
			headers: {
				'Content-Type': 'application/json-patch+json',
				'Authorization': `Bearer ${localStorage.getItem('token')}`
			}
		})
	})
	e('updateRole', function(data) {
		return admin.req({
			url: api.identity + 'identity/roles/' + data.id,
			type: 'PUT',
			data: JSON.stringify(data),
			headers: {
				'Content-Type': 'application/json-patch+json',
				'Authorization': `Bearer ${localStorage.getItem('token')}`
			}
		})
	})
	e('getUserGrantPermission', function(data) {
		let permissionUrl = api.identity + 'identity/users/' + data + '/roles/'
		return admin.req({
			url: permissionUrl,
			headers: {
				'Authorization': `Bearer ${localStorage.getItem('token')}`
			},
			type: 'get'
		})
	})

	e('getAllRoles', function(data) {

		let roleUrl = api.identity + 'identity/roles'
		return admin.req({
			url: roleUrl,
			headers: {
				'Authorization': `Bearer ${localStorage.getItem('token')}`
			},
			type: 'get'
		})
	})
	e('deleteUser', function(data) {

		let permissionUrl = api.identity + 'identity/users/' + data
		return admin.req({
			url: permissionUrl,
			headers: {
				'Authorization': `Bearer ${localStorage.getItem('token')}`

			},
			type: 'DELETE'
		})
	})
	e('deleteRole', function(data) {

		let permissionUrl = api.identity + 'identity/roles/' + data
		return admin.req({
			url: permissionUrl,
			headers: {
				'Authorization': `Bearer ${localStorage.getItem('token')}`

			},
			type: 'DELETE'
		})
	})

	e('createUser', function(data) {

		let permissionUrl = api.identity + 'Account/CreateUser/createUser'
		return admin.req({
			url: permissionUrl,
			headers: {
				'Authorization': `Bearer ${localStorage.getItem('token')}`,

				'Content-Type': 'application/json'
			},
			type: 'POST',
			data: JSON.stringify(data)
		})
	})
	e('userPermission', function(data) {

		let permissionUrl = api.identity + 'Account/getUserGrantPermission/permission/' + data
		return admin.req({
			url: permissionUrl,
			headers: {
				'Authorization': `Bearer ${localStorage.getItem('token')}`
			},
			type: 'get'
		})
	})
	e('updateUser', function(data) {

		let permissionUrl = api.identity + 'Account/UpdateUser/updateUser'
		return admin.req({
			url: permissionUrl,
			headers: {
				'Authorization': `Bearer ${localStorage.getItem('token')}`,

				'Content-Type': 'application/json'
			},
			type: 'POST',
			data: JSON.stringify(data)
		})
	})
	e('updateRolePermission', function(data) {
		return admin.req({
			url: api.identity + 'Account/UpdateRoleGrantPermission',
			type: 'POST',
			data: JSON.stringify(data),
			headers: {
				'Content-Type': 'application/json-patch+json',
				'Authorization': `Bearer ${localStorage.getItem('token')}`
			}
		})
	})

});
