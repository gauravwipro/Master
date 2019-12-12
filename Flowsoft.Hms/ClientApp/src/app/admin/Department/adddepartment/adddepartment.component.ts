import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchDepartmentComponent } from '../fetchdepartment/fetchdepartment.component';
import { DepartmentService } from '../../services/departmentservice.service';
@Component({
    templateUrl: './AddDepartment.component.html'
})

export class CreateDepartment implements OnInit {
    departmentForm: FormGroup;
    title: string = "Create";
    Id: number;
    errorMessage: any;
    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _departmentService: DepartmentService, private _router: Router) {
      if (this._avRoute.snapshot.firstChild.params["id"]) {
        this.Id = this._avRoute.snapshot.firstChild.params["id"];
        }

        this.departmentForm = this._fb.group({
            id: 0,
            name: ['', [Validators.required]],
            description: ['', [Validators.required]],
        })
     
    }

    ngOnInit() {

        if (this.Id > 0) {
            this.title = "Edit";
            this._departmentService.getDepartmentById(this.Id)
                .subscribe(resp => this.departmentForm.setValue(resp)
                    , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.departmentForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._departmentService.saveDepartment(this.departmentForm.value)
                .subscribe((data) => {
                  this._router.navigate(['/department']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._departmentService.updateDepartment(this.departmentForm.value)
                .subscribe((data) => {
                  this._router.navigate(['/department']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
      this._router.navigate(['/department']);
    }
    get name() { return this.departmentForm.get('name'); }
    get description() { return this.departmentForm.get('description'); }
    
}

