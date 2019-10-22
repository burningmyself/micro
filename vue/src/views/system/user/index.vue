<template>
  <div class="app-container">
    <div class="filter-container">
      <el-input
        v-model="listQuery.filter"
        :placeholder="$t('user.filter')"
        style="width: 200px"
        class="filter-item"
        @keyup.enter.native="handleFilter"
      />
      <el-button
        v-waves
        class="filter-item"
        type="primary"
        icon="el-icon-search"
        @click="handleFilter"
      >{{$t('table.search')}}</el-button>
      <el-button
        class="filter-item"
        style="margin-left: 10px;"
        type="primary"
        icon="el-icon-edit"
        @click="handleCreate"
      >{{ $t('table.add') }}</el-button>
      <el-table
        :key="tableKey"
        v-loading="listLoading"
        :data="list"
        border
        fit
        highlight-current-row
        style="width: 100%;"
      >
        <el-table-column
          :label="$t('user.id')"
          prop="id"
          sortable="custom"
          align="center"
          width="280px"
        >
          <template slot-scope="scope">
            <span>{{ scope.row.id }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('user.name')" min-width="150px">
          <template slot-scope="{row}">
            <span @click="handleUpdate(row)">{{ row.name }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('User.tenantId')" width="80px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.tenantId }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('User.userName')" width="80px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.userName }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('User.surname')" width="80px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.surname }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('User.email')" width="180px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.email }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('User.emailConfirmed')" width="80px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.emailConfirmed }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('User.phoneNumber')" width="80px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.phoneNumber }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('User.phoneNumberConfirmed')" width="80px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.phoneNumberConfirmed }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('User.twoFactorEnabled')" width="80px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.twoFactorEnabled }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('User.lockoutEnabled')" width="80px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.lockoutEnabled }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('User.lockoutEnd')" width="80px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.lockoutEnd }}</span>
          </template>
        </el-table-column>
        <el-table-column
          :label="$t('table.actions')"
          align="center"
          width="230"
          class-name="fixed-width"
        >
          <template slot-scope="{row}">
            <el-button type="primary" size="mini" @click="handleUpdate(row)">{{ $t('User.edit') }}</el-button>
            <el-button
              size="mini"
              type="danger"
              @click="handleDelete(row,'deleted')"
            >{{ $t('User.delete') }}</el-button>

            <el-button size="mini" type="warning" @click="handleRole(row)">{{ $t('User.roles') }}</el-button>
          </template>
        </el-table-column>
      </el-table>
      <pagination
        v-show="total>0"
        :total="total"
        :page.sync="listQuery.page"
        :limit.sync="listQuery.limit"
        @pagination="getList"
      />

      <el-dialog :title="textMap[dialogStatus]" :visible.sync="digRole">
        <el-form
          ref="dataForm"
          :rules="rules"
          :model="tempUserData"
          label-position="left"
          label-width="100px"
          style="width: 400px; margin-left:50px;"
        >
          <el-form-item :label="$t('User.name')" prop="name">
            <el-input v-model="tempUserData.name" />
          </el-form-item>
          <el-form-item :label="$t('User.roles')" prop="name">
            <el-checkbox v-for="item in roleArray" v-model="item.v" :key="item.name">{{item.name}}</el-checkbox>
          </el-form-item>
          <el-form-item :label="$t('User.permission')" prop="name">
            <el-checkbox
              v-for="item in permission.array"
              v-model="item.v"
              :key="item.name"
            >{{item.name}}</el-checkbox>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click="digRole = false">{{ $t('User.cancel') }}</el-button>
          <el-button type="primary" @click="submitPermission">{{ $t('User.confirm') }}</el-button>
        </div>
      </el-dialog>

      <el-dialog :title="textMap[dialogStatus]" :visible.sync="dialogFormVisible">
        <el-form
          ref="dataForm"
          :rules="rules"
          :model="tempUserData"
          label-position="left"
          label-width="100px"
          style="width: 400px; margin-left:50px;"
        >
          <el-form-item :label="$t('User.name')" prop="name">
            <el-input v-model="tempUserData.name" />
          </el-form-item>
          <el-form-item :label="$t('User.password')" prop="password">
            <el-input v-model="tempUserData.password" />
          </el-form-item>
          <el-form-item :label="$t('User.userName')" prop="userName">
            <el-input v-model="tempUserData.userName" />
          </el-form-item>
          <el-form-item :label="$t('User.surname')" prop="surname">
            <el-input v-model="tempUserData.surname" />
          </el-form-item>
          <el-form-item :label="$t('User.email')" prop="email">
            <el-input v-model="tempUserData.email" />
          </el-form-item>
          <el-form-item :label="$t('User.phoneNumber')" prop="phoneNumber">
            <el-input v-model="tempUserData.phoneNumber" />
          </el-form-item>
          <el-form-item :label="$t('User.twoFactorEnabled')" prop="twoFactorEnabled">
            <el-input v-model="tempUserData.twoFactorEnabled" />
          </el-form-item>
          <el-form-item :label="$t('User.lockoutEnabled')" prop="lockoutEnabled">
            <el-input v-model="tempUserData.lockoutEnabled" />
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click="dialogFormVisible = false">{{ $t('User.cancel') }}</el-button>
          <el-button
            type="primary"
            @click="dialogStatus==='create'?createData():updateData()"
          >{{ $t('User.confirm') }}</el-button>
        </div>
      </el-dialog>

      <el-dialog :visible.sync="dialogPageviewsVisible" title="Reading statistics">
        <el-table :data="pageviewsData" border fit highlight-current-row style="width: 100%">
          <el-table-column prop="key" label="Channel" />
          <el-table-column prop="pageviews" label="Pageviews" />
        </el-table>
        <span slot="footer" class="dialog-footer">
          <el-button type="primary" @click="dialogPageviewsVisible = false">{{ $t('User.confirm') }}</el-button>
        </span>
      </el-dialog>
    </div>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Model } from "vue-property-decorator";
import { Form } from "element-ui";
import { cloneDeep } from "lodash";
import { exportJson2Excel } from "@/utils/excel";
import { formatJson } from "@/utils";
import Pagination from "@/components/Pagination/index.vue";

import { RoleModule } from "@/store/modules/role";
import {
  getUsers,
  updateUser,
  createUser,
  deleteUser,
  getUserGrantPermission,
  getPermissionByUserId,
  UserAndRoleRoot,
  updateUserIsRoleAndPermission
} from "@/api/users";
import { regex } from "../../../regex";
import { getBaseRoles } from "../../../api/roles";
import { UserModule } from "../../../store/modules/user";

interface IUserData {
  id: string;
  name: string;
  roleNames: [];
  password: string;
  userName: string;
  surname: string;
  email: string;
  phoneNumber: string;
  twoFactorEnabled: boolean;
  lockoutEnabled: boolean;
}
const defaultUserData: IUserData = {
  id: "",
  name: "",
  roleNames: [],
  password: "",
  userName: "",
  surname: "",
  email: "",
  phoneNumber: "",
  twoFactorEnabled: false,
  lockoutEnabled: false
};

@Component({
  name: "UserTable",
  components: {
    Pagination
  }
})
export default class extends Vue {
  private tableKey = 0;
  private listLoading = true;
  private list = [];
  private total = 0;
  private listQuery = {
    page: 1,
    limit: 20,
    importance: undefined,
    title: undefined,
    type: undefined,
    sort: "+id"
  };
  private dialogFormVisible = false;
  private dialogStatus = "";
  private textMap = {
    update: "Edit",
    create: "Create"
  };

  private dialogPageviewsVisible = false;
  private pageviewsData = [];

  //#region "role权限"
  /**
   * 角色弹窗显示
   */
  private digRole: boolean = false;
  private roleArray: Array<any> = [];

  //当前用户拥有的角色
  private grantRoles: Array<object> = [];
  //当前用户拥有的权限
  private grantPermission: Array<object> = [];

  private userInfo: any = {};

  /**
   * 初始化数据
   */
  permissionOpen() {
    this.roleArray = [];
    this.grantRoles = [];
    this.userInfo = {};
    this.grantPermission = [];
  }

  /**
   * 打开弹窗初始化数据
   */
  async handleRole(row: any) {
    this.digRole = true;

    //打开弹窗
    this.permissionOpen();
    this.userInfo = row;
    this.tempUserData = Object.assign({}, row);
    let data_v = await this.getRoles();
    //获取当前用户角色
    let roles = await getPermissionByUserId(row.id);

    let array: any = [];
    let arrayNULL: any = [];

    data_v.items.map(xs => {
      let item = {
        id: xs.id,
        name: xs.name,
        v: false
      };
      if (!!roles.items.find(res => res.name == xs.name)) {
        item.v = true;
      }
      array.push(item);
    });

    if (array.length != 0) this.roleArray = array;
    else this.roleArray = arrayNULL;
    //获取当前用户权限
    let per = await getUserGrantPermission(row.id);
    this.permission.array = this.permission.array.map(x => {
      let d = per.find(res => res == x.name);
      if (!!d) {
        x.v = true;
      }
      return x;
    });
  }

  submitPermission() {
    //当前id
    let id = this.userInfo.id;
    //当前选中角色 返回Array<string>
    let grantRoles = this.roleArray.filter(res => res.v).map(res => res.name);
    //当前选中权限 返回Array<string>
    let grantPermission = this.permission.array
      .filter(res => res.v)
      .map(res => res.name);
    let postData: UserAndRoleRoot = {
      id,
      grantRoles,
      grantPermission
    };
    updateUserIsRoleAndPermission(postData).then(res => {
      this.digRole = false;
      this.permissionOpen();
      this.getList();
    });
  }

  //获取所有角色
  async getRoles() {
    return await getBaseRoles();
  }
  //所有权限
  private permission = {
    checkList: [],
    array: new Array<any>()
  };
  //初始化所有权限
  constructor() {
    super();
    let t = UserModule.auth.policies;
    for (let item in t) {
      this.permission.array.push({ name: item, v: false });
    }
  }
  //#endregion

  private handleFilter() {
    this.listQuery.page = 1;
    this.getList();
  }
  private resetTempUserData() {
    this.tempUserData = cloneDeep(defaultUserData);
  }
  private handleCreate() {
    this.resetTempUserData();
    this.dialogStatus = "create";
    this.dialogFormVisible = true;
    this.$nextTick(() => {
      (this.$refs["dataForm"] as Form).clearValidate();
    });
  }
  private createData() {
    (this.$refs["dataForm"] as Form).validate(async valid => {
      if (valid) {
        let { id, roleNames, ...UserData } = this.tempUserData;
        const data = await createUser(UserData);
        this.list.unshift(data);
        this.dialogFormVisible = false;
        this.$notify({
          title: "成功",
          message: "创建成功",
          type: "success",
          duration: 2000
        });
      }
    });
  }
  private handleUpdate(row: any) {
    this.tempUserData = Object.assign({}, row);
    this.dialogStatus = "update";
    this.dialogFormVisible = true;
    this.$nextTick(() => {
      (this.$refs["dataForm"] as Form).clearValidate();
    });
  }
  private updateData() {
    (this.$refs["dataForm"] as Form).validate(async valid => {
      if (valid) {
        const tempData = Object.assign({}, this.tempUserData);
        const data = await updateUser(tempData.id, tempData);
        for (const v of this.list) {
          if (v.id === data.id) {
            const index = this.list.indexOf(v);
            this.list.splice(index, 1, data);
            break;
          }
        }
        this.dialogFormVisible = false;
        this.$notify({
          title: "成功",
          message: "更新成功",
          type: "success",
          duration: 2000
        });
      }
    });
  }
  private handleModifyStatus() {}

  private handleGetPageviews() {}

  private handleDelete(row: any) {
    const data = deleteUser(row.id);
    if (data) {
      this.list = this.list.filter(r => r !== row);
      this.$notify({
        title: "成功",
        message: "删除成功",
        type: "success",
        duration: 2000
      });
    }
  }
  private tempUserData = defaultUserData;
  created() {
    this.getList();
  }
  private async getList() {
    this.listLoading = true;
    const data = await getUsers(this.listQuery);
    this.list = data.items;
    this.total = this.list.length;
    // Just to simulate the time of the request
    setTimeout(() => {
      this.listLoading = false;
    }, 0.5 * 1000);
  }

  //#region "表单验证"

  private rules = {
    name: [{ required: true, message: "name is required", trigger: "change" }],
    userName: [
      { required: true, message: "userName is required", trigger: "change" }
    ],
    phoneNumber: [
      { required: true, message: "phone is invalid", trigger: "change" }
    ],
    surname: [
      { required: true, message: "surname is required", trigger: "change" }
    ],
    password: [{ validator: validatePass, trigger: "change" }],
    email: [
      {
        type: "email",
        required: true,
        message: "请输入正确的邮箱",
        trigger: "change"
      }
    ]
  };

  //#endregion
}
//#region "自定义表单验证"
var validatePass = (rule: any, value: string, callback: any) => {
  if (!regex.loginPass.test(value))
    callback(
      "至少8-16个字符，至少1个大写字母，1个小写字母和1个数字，其他可以是任意字符："
    );
  else callback();
};

//#endregion
</script>
