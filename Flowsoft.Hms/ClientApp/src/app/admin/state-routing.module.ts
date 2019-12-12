import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FetchStateComponent } from './States/fetchstate/fetchstate.component';
import { CreateState } from './States/addstate/addstate.component';
import { StateService } from './services/stateservice.service';
import { AuthGuard } from '../app.routing';
const countryRoutes: Routes = [
   {
    path: '',
     component: FetchStateComponent,
    children: [
      { path: 'state', component: FetchStateComponent, canActivate: [AuthGuard], pathMatch: "full" },
    ]
  },
  {
    path: '',
    component: CreateState,
    children: [
      { path: 'create-state', component: CreateState, canActivate: [AuthGuard], pathMatch: "full" },
    ]
  },
  {
    path: '',
    component: CreateState,
    children: [
      { path: 'state/edit/:id', component: CreateState, canActivate: [AuthGuard], pathMatch: "full" }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(countryRoutes)],
  exports: [RouterModule]
})
export class StateRoutingModule { } 
