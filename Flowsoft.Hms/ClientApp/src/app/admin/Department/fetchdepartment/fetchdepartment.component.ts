import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from '@angular/router';
import { DepartmentData } from '../../models/DepartmentData'
import { DepartmentService } from '../../services/departmentservice.service';
@Component({
  templateUrl: './fetchdepartment.component.html'
})

export class FetchDepartmentComponent {
  public departmentList: DepartmentData[];
  p: number = 1;
  constructor(private formBuilder: FormBuilder, private _router: Router, private _departmentService: DepartmentService) {
    this.getDepartments();
  }

  getDepartments() {
    this._departmentService.getDepartments().subscribe(
      data => this.departmentList = data
    )
  }

  delete(departmentID) {
    var ans = confirm("Do you want to delete department with Id: " + departmentID);
    if (ans) {
      this._departmentService.deleteDepartment(departmentID).subscribe((data) => {
        this.getDepartments();
      }, error => console.error(error))
    }
  }
}

