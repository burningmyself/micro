import { NgModule, APP_INITIALIZER } from '@angular/core';
import { BaseConfigService } from './services/base-config.service';
import { noop } from '@abp/ng.core';
import { BaseSettingsComponent } from './components/base-settings.component';

@NgModule({
  declarations: [BaseSettingsComponent],
  providers: [{ provide: APP_INITIALIZER, deps: [BaseConfigService], multi: true, useFactory: noop }],
  exports: [BaseSettingsComponent],
  entryComponents: [BaseSettingsComponent],
})
export class BaseConfigModule {}
