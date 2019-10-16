layui.define([], function (e) {
    'use strict';
    let admin = layui.admin,
        api = layui.api



    e('login', function (data) {
        return admin.req({
            url: api.identity + 'account/token',
            type: 'POST',
            data: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json-patch+json'
            }
        })
    })



    e('userInfo', function () {
        return admin.req({
            url: api.identity + 'account/info',
            type: 'POST',
            headers: {
                'Content-Type': 'application/json-patch+json',
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    })



    e('delUser', function (data) {
        return admin.req({
            url: api.identity + 'identity/users/' + data,
            type: 'DELETE',
            headers: {
                'Content-Type': 'application/json-patch+json',
                'Authorization': `Bearer ${localStorage.getItem('token')}`
            }
        })
    })



    e('addUser', function (data) {
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


    e('putUser', function (data) {
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

    e('addRole', function (data) {
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

});