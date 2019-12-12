import { Component, OnInit } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../../services/authentication.service';
import { debug } from 'util';
import { User } from '../../models/user';
import { Role } from '../..//models/role';
import { DatePipe } from '@angular/common';
@Component({
  selector: '.sidebar-menu',
  templateUrl: './navmenu.component.html',
  styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
  public currentDate = new Date();
  currentUser: User;
  public currentOpdLink: string; 
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
  public datepipe: DatePipe) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.currentOpdLink = 'opdDetails/opdList/' + datepipe.transform(this.currentDate, "yyyy-MM-dd");
  }

  get isAdmin() {
    return this.currentUser && this.currentUser.role === Role.Admin;
  }
  get isReception() {
    return this.currentUser && this.currentUser.role === Role.Reception;
  }

  get isDoctor() {
    return this.currentUser && this.currentUser.role === Role.Doctor;
  }
}
