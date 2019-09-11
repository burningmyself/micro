<template>
  <div class="app-container">
    <div class="filter-container">
      <el-input
        v-model="listQuery.filter"
        :placeholder="$t('role.filter')"
        style="width: 200px;"
        class="filter-item"
        @keyup.enter.native="handleFilter"
      />
      <el-button
        v-waves
        class="filter-item"
        type="primary"
        icon="el-icon-search"
        @click="handleFilter"
      >{{ $t('table.search') }}</el-button>
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
          :label="$t('role.id')"
          prop="id"
          sortable="custom"
          align="center"
          width="280px"
        >
          <template slot-scope="scope">
            <span>{{ scope.row.id }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('role.name')" min-width="150px">
          <template slot-scope="{row}">
            <span @click="handleUpdate(row)">{{ row.name }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('role.isDefault')" width="180px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.isDefault }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('role.isStatic')" width="180px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.isStatic }}</span>
          </template>
        </el-table-column>
        <el-table-column :label="$t('role.isPublic')" width="180px" align="center">
          <template slot-scope="scope">
            <span>{{ scope.row.isPublic }}</span>
          </template>
        </el-table-column>
        <el-table-column
          :label="$t('table.actions')"
          align="center"
          width="230"
          class-name="fixed-width"
        >
          <template slot-scope="{row}">
            <el-button type="primary" size="mini" @click="handleUpdate(row)">{{ $t('role.edit') }}</el-button>
            <el-button
              size="mini"
              type="danger"
              @click="handleDelete(row,'deleted')"
            >{{ $t('role.delete') }}</el-button>
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
      <el-dialog :title="textMap[dialogStatus]" :visible.sync="dialogFormVisible">
        <el-form
          ref="dataForm"
          :rules="rules"
          :model="tempRoleData"
          label-position="left"
          label-width="100px"
          style="width: 400px; margin-left:50px;"
        >
          <el-form-item :label="$t('role.name')" prop="name">
            <el-input v-model="tempRoleData.name" />
          </el-form-item>
          {{tempRoleData.isStatic}}
          <el-form-item :label="$t('role.isStatic')" prop="isStatic">
            <el-radio v-model="tempRoleData.isStatic" label="true" border>{{$t('true')}}</el-radio>
            <el-radio v-model="tempRoleData.isStatic" label="false" border>{{$t('false')}}</el-radio>
          </el-form-item>
          <el-form-item :label="$t('role.isPublic')" prop="isPublic">
            <el-radio v-model="tempRoleData.isPublic" label="true" border>{{$t('true')}}</el-radio>
            <el-radio v-model="tempRoleData.isPublic" label="false" border>{{$t('false')}}</el-radio>
          </el-form-item>
          <el-form-item :label="$t('role.isDefault')" prop="isDefault">
            <el-radio v-model="tempRoleData.isDefault" label="true" border>{{$t('true')}}</el-radio>
            <el-radio v-model="tempRoleData.isDefault" label="false" border>{{$t('false')}}</el-radio>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click="dialogFormVisible = false">{{ $t('role.cancel') }}</el-button>
          <el-button
            type="primary"
            @click="dialogStatus==='create'?createData():updateData()"
          >{{ $t('role.confirm') }}</el-button>
        </div>
      </el-dialog>

      <el-dialog :visible.sync="dialogPageviewsVisible" title="Reading statistics">
        <el-table :data="pageviewsData" border fit highlight-current-row style="width: 100%">
          <el-table-column prop="key" label="Channel" />
          <el-table-column prop="pageviews" label="Pageviews" />
        </el-table>
        <span slot="footer" class="dialog-footer">
          <el-button type="primary" @click="dialogPageviewsVisible = false">{{ $t('role.confirm') }}</el-button>
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
import { getRoles, updateRole, createRole,deleteRole } from "@/api/roles";

interface IRoleData {
  id: string;
  name: string;
  isStatic: boolean;
  isPublic: boolean;
  isDefault: boolean;
}
const defaultRoleData: IRoleData = {
  id: "",
  name: "",
  isStatic: true,
  isPublic: true,
  isDefault: true
};

@Component({
  name: "roleTable",
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
  private rules = {
    name: [{ required: true, message: "name is required", trigger: "change" }]
  };

  private handleFilter() {
    this.listQuery.page = 1
    this.getList()
  }
  private resetTempRoleData() {
    this.tempRoleData = cloneDeep(defaultRoleData);
  }
  private handleCreate() {
    this.resetTempRoleData();
    this.dialogStatus = "create";
    this.dialogFormVisible = true;
    this.$nextTick(() => {
      (this.$refs["dataForm"] as Form).clearValidate();
    });
  }
 private createData() {
    (this.$refs['dataForm'] as Form).validate(async(valid) => {
      if (valid) {
        let { id,isStatic,...roleData } = this.tempRoleData
        const data  = await createRole(roleData)
        this.list.unshift(data)
        this.dialogFormVisible = false
        this.$notify({
          title: '成功',
          message: '创建成功',
          type: 'success',
          duration: 2000
        })
      }
    })
  }
  private handleUpdate(row: any) {
    this.tempRoleData = Object.assign({}, row)
    this.dialogStatus = 'update'
    this.dialogFormVisible = true
    this.$nextTick(() => {
      (this.$refs['dataForm'] as Form).clearValidate()
    })
  }
 private updateData() {
    (this.$refs['dataForm'] as Form).validate(async(valid) => {
      if (valid) {
        const tempData = Object.assign({}, this.tempRoleData)
        const data = await updateRole(tempData.id, tempData)
        for (const v of this.list) {
          if (v.id === data.id) {
            const index = this.list.indexOf(v)
            this.list.splice(index, 1, data)
            break
          }
        }
        this.dialogFormVisible = false
        this.$notify({
          title: '成功',
          message: '更新成功',
          type: 'success',
          duration: 2000
        })
      }
    })
  }
  private handleModifyStatus() {}

  private handleGetPageviews() {}

  private handleDelete(row:any) {
    const data = deleteRole(row.id)
    if(data){
      this.list = this.list.filter(r=>r!==row)
      this.$notify({
        title: '成功',
        message: '删除成功',
        type: 'success',
        duration: 2000
      })
    }
  }
  private tempRoleData=defaultRoleData
  created() {
    this.getList();   
  }
  private async getList() {
    this.listLoading = true;
    const data = await getRoles(this.listQuery);
    this.list = data.items;
    this.total = this.list.length;
    // Just to simulate the time of the request
    setTimeout(() => {
      this.listLoading = false;
    }, 0.5 * 1000);
  }
}
</script>
