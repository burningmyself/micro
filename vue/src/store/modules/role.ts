import { VuexModule, Module, Action, Mutation, getModule } from 'vuex-module-decorators'
import store from '@/store'

export interface IRolestate {
    /**
     * 点击修改权限传入的权限
     */
    grantPermission: Array<string>;
}

@Module({ dynamic: true, store, name: 'role' })
class Role extends VuexModule implements IRolestate {

    grantPermission!: Array<string>;

    @Mutation
    public M_EditPermission(req: Array<string>) {
        this.grantPermission = req
    }


    @Action
    public EditPermission(req: Array<string>) {
        store.commit('M_EditPermission', req)
    }

}

export const RoleModule = getModule(Role)
