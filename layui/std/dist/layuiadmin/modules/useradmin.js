/** layuiAdmin.std-v1.2.1 LPPL License By http://www.layui.com/admin/ */ ;
layui.define(["table", "form"], function(e) {
	var t = layui.$,
		i = layui.table;
	layui.form;

	i.set({
		headers: {
			Authorization: 'Bearer ' + localStorage.getItem('token')
		}
	})
	i.render({
		elem: "#LAY-user-manage",
		url: layui.setter.base + "json/useradmin/webuser.js",
		cols: [
			[{
				type: "checkbox",
				fixed: "left"
			}, {
				field: "id",
				width: 100,
				title: "ID",
				sort: !0
			}, {
				field: "username",
				title: "用户名",
				minWidth: 100
			}, {
				field: "avatar",
				title: "头像",
				width: 100,
				templet: "#imgTpl"
			}, {
				field: "phone",
				title: "手机"
			}, {
				field: "email",
				title: "邮箱"
			}, {
				field: "sex",
				width: 80,
				title: "性别"
			}, {
				field: "ip",
				title: "IP"
			}, {
				field: "jointime",
				title: "加入时间",
				sort: !0
			}, {
				title: "操作",
				width: 150,
				align: "center",
				fixed: "right",
				toolbar: "#table-useradmin-webuser"
			}]
		],
		page: !0,
		limit: 30,
		height: "full-220",
		text: "对不起，加载出现异常！"
	}), i.on("tool(LAY-user-manage)", function(e) {
		e.data;
		if ("del" === e.event) layer.prompt({
			formType: 1,
			title: "敏感操作，请验证口令"
		}, function(t, i) {
			layer.close(i), layer.confirm("真的删除行么", function(t) {
				e.del(), layer.close(t)
			})
		});
		else if ("edit" === e.event) {
			t(e.tr);
			layer.open({
				type: 2,
				title: "编辑用户",
				content: "../../../views/user/user/userform.html",
				maxmin: !0,
				area: ["500px", "450px"],
				btn: ["确定", "取消"],
				yes: function(e, t) {
					var l = window["layui-layer-iframe" + e],
						r = "LAY-user-front-submit",
						n = t.find("iframe").contents().find("#" + r);
					l.layui.form.on("submit(" + r + ")", function(t) {
						t.field;
						i.reload("LAY-user-front-submit"), layer.close(e)
					}), n.trigger("click")
				},
				success: function(e, t) {}
			})
		}
	}), i.render({
		elem: "#LAY-user-back-manage",
		url: layui.api.identity + "identity/users",

		parseData(res) {
			return {
				code: 0,
				msg: '',
				data: res.items,
				count: res.totalCount
			}
		},
		cols: [
			[{
				type: "checkbox",
				fixed: "left"
			}, {
				field: "id",
				width: 80,
				title: "ID",
				sort: !0
			}, {
				field: "userName",
				title: "登录名"
			}, {
				field: "phoneNumber",
				title: "手机"
			}, {
				field: "email",
				title: "邮箱"
			}, {
				field: "creationTime",
				title: "加入时间",
				sort: !0
			}, {
				title: "操作",
				width: 150,
				align: "center",
				fixed: "right",
				toolbar: "#table-useradmin-admin"
			}]
		],
		text: "对不起，加载出现异常！"
	}), i.on("tool(LAY-user-back-manage)", function(e) {
		e.data;
		if ("del" === e.event) layer.prompt({
			formType: 1,
			title: "敏感操作，请验证口令"
		}, function(t, i) {
			layer.close(i), layer.confirm("确定删除此管理员？", function(t) {
				layui.delUser(e.data.id)
				console.log(e), e.del(), layer.close(t)
			})
		});
		else if ("edit" === e.event) {
			t(e.tr);
			layer.open({
				type: 2,
				title: "编辑管理员",
				content: "../../../views/user/administrators/userform.html",
				area: ["420px", "420px"],
				btn: ["确定", "取消"],
				yes: function(index, layero) {
					var iframeWindow = window['layui-layer-iframe' + index],
						submit = layero.find('iframe').contents().find("#LAY-user-role-submit");
					//监听提交
					iframeWindow.layui.form.on('submit(formDemo)', function(data) {
						let field = data.field;
						let grantPermission = getChange1(field)
						let roles = getChange2(field)
						layui.updateUser({
							...field,
							roles: roles,
							permissions: grantPermission,
							id: e.data.id
						}).success(res => {
							i.reload('LAY-user-back-manage');
							layer.close(index); //关闭弹层
						})
						return
					});

					submit.trigger('click');
				},
				success: function(layero, index) {
					var iframe = window['layui-layer-iframe' + index]
					iframe.child(e.data)
				}
			})
		}
	}), i.render({
		elem: "#LAY-user-back-role",
		url: layui.api.identity + "Account/getRolesAndGrantPermission",
		parseData(res) {
			return {
				code: 0,
				msg: '',
				data: res.items,
				count: res.totalCount
			}
		},
		cols: [
			[{
				type: "checkbox",
				fixed: "left"
			}, {
				field: "id",
				width: 80,
				title: "ID",
				sort: !0
			}, {
				field: "name",
				title: "角色名"
			}, {
				field: "grantPermission",
				title: "拥有权限"
			}, {
				title: "操作",
				width: 150,
				align: "center",
				fixed: "right",
				toolbar: "#table-useradmin-admin"
			}]
		],
		text: "对不起，加载出现异常！"
	}), i.on("tool(LAY-user-back-role)", function(e) {
		e.data;
		let v = e.data;
		if ("del" === e.event) layer.confirm("确定删除此角色？", function(t) {
			e.del(), layer.close(t)
		});
		else if ("edit" === e.event) {
			t(e.tr);
			layer.open({
				type: 2,
				title: "编辑角色",
				content: "../../../views/user/administrators/roleform.html",
				area: ["500px", "480px"],
				btn: ["确定", "取消"],
				yes: function(e, t) {
					var l = window["layui-layer-iframe" + e],
						r = t.find("iframe").contents().find("#LAY-user-role-submit");
					l.layui.form.on("submit(formDemo)", function(t) {
						let field = t.field;
						field.id = v.id
						let arr = []
						for (let i in field) {
							if (i != 'name' && i != 'id')
								arr.push(i)
						}
						let req = {
							id: field.id,
							grantPermission: arr,
							name: field.name
						}
						layui.updateRolePermission(req).success(function() {

						})
						setTimeout(() => {

							i.reload('LAY-user-back-role');
							layer.close(e); //关闭弹层
						}, 1000)
					});
					r.trigger("click")
					return
				},
				success: function(layero, index) {
					var iframe = window['layui-layer-iframe' + index]
					iframe.child(e.data)
				}
			})
		}
	}), e("useradmin", {})
});
