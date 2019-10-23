import { Injectable } from '@angular/core';
import { eLayoutType, addAbpRoutes, ABP } from '@abp/ng.core';
import { addSettingTab } from '@abp/ng.theme.shared';
import { BaseSettingsComponent } from '../components/base-settings.component';

@Injectable({
  providedIn: 'root',
})
export class BaseConfigService {
  constructor() {
    addAbpRoutes({
      name: 'Base',
      path: 'base',
      layout: eLayoutType.application,
      order: 2,
    } as ABP.FullRoute);

    const route = addSettingTab({
      component: BaseSettingsComponent,
      name: 'Base Settings',
      order: 1,
      requiredPolicy: '',
    });
  }
}
