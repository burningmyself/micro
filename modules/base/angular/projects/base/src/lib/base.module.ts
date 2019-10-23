import { NgModule } from '@angular/core';
import { BaseComponent } from './components/base.component';
import { BaseRoutingModule } from './base-routing.module';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CoreModule } from '@abp/ng.core';

@NgModule({
  declarations: [BaseComponent],
  imports: [CoreModule, ThemeSharedModule, BaseRoutingModule],
  exports: [BaseComponent],
})
export class BaseModule {}
