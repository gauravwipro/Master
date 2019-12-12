import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FetchStateComponent } from './States/fetchstate/fetchstate.component';
import { CreateState } from './States/addstate/addstate.component';
import { StateService } from './services/stateservice.service';

import { StateRoutingModule } from '../admin/state-routing.module';
import { NgxPaginationModule } from 'ngx-pagination'; // <-- import the module
@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    StateRoutingModule,
    NgxPaginationModule
  ],
  declarations: [
    FetchStateComponent,
    CreateState,
  ],
  providers: [ StateService]
})
export class StateModule {
  constructor() {
    console.log('StateModule loaded.');
  }
} 
