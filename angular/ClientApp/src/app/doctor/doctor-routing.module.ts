import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FetchOpdComponent } from './Opd/fetchopd/fetchopd.component';
import { FetchOpdDetailComponent } from './OpdDetail/fetchopddetail/fetchopddetail.component';
import { AuthGuard } from '../app.routing';
const countryRoutes: Routes = [
  {
    path: '',
    component: FetchOpdComponent,
    children: [
      { path: 'opdDetails', component: FetchOpdComponent, canActivate: [AuthGuard], pathMatch: "full" },
    ]
  },
  {
    path: '',
    component: FetchOpdDetailComponent,
    children: [
      { path: 'opdList/:opdDate', component: FetchOpdDetailComponent, canActivate: [AuthGuard], pathMatch: "full" }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(countryRoutes)],
  exports: [RouterModule]
})
export class DoctorRoutingModule { } 
