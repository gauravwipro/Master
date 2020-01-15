import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchDoctorComponent } from '../fetchdoctor/fetchdoctor.component';
import { DoctorService } from '../../services/doctorservice.service';
@Component({
  templateUrl: './AddDoctor.component.html'
})

export class CreateDoctor implements OnInit {
    doctorForm: FormGroup;
    title: string = "Create";
    Id: number;
    errorMessage: any;
    public stateList: IDropDownValues[];
    public genderList: IDropDownValues[];
    public departmentList: IDropDownValues[];

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _doctorService: DoctorService, private _router: Router) {
      if (this._avRoute.snapshot.firstChild.params["id"]) {
          this.Id = this._avRoute.snapshot.firstChild.params["id"];
        }

        this.doctorForm = this._fb.group({
            id: 0,
            firstName: ['', [Validators.required]],
            lastName: ['', [Validators.required]],
            address: ['', [Validators.required]],
            city: ['', [Validators.required]],
            phoneNumber: ['', [Validators.required]],
            emergencyNumber: ['', [Validators.required]],
            isRegular: false,
            stateId: ['0', [Validators.required]],
            departmentId: ['0', [Validators.required]],
            genderId: ['0', [Validators.required]],
        })
     
    }

    ngOnInit() {

       
        this._doctorService.getStateList().subscribe(
            data => this.stateList = data,
            error => console.log("Error :: " + error)
        )
        this._doctorService.getGenderList().subscribe(
            data => this.genderList = data,
            error => console.log("Error :: " + error)
        )
        this._doctorService.getDepartmentList().subscribe(
            data => this.departmentList = data,
            error => console.log("Error :: " + error)
        )

        if (this.Id > 0) {
            this.title = "Edit";
            this._doctorService.getDoctorById(this.Id)
                .subscribe(resp => this.doctorForm.setValue(resp)
                    , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.doctorForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._doctorService.saveDoctor(this.doctorForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/doctor']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._doctorService.updateDoctor(this.doctorForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/doctor']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/doctor']);
    }


    get firstName() { return this.doctorForm.get('firstName'); }
    get lastName() { return this.doctorForm.get('lastName'); }
    get address() { return this.doctorForm.get('address'); }
    get phoneNumber() { return this.doctorForm.get('phoneNumber'); }
    get emergencyNumber() { return this.doctorForm.get('emergencyNumber'); }
    get stateId() { return this.doctorForm.get('stateId'); }
    get departmentId() { return this.doctorForm.get('departmentId'); }
    get genderId() { return this.doctorForm.get('genderId'); }
    get city() { return this.doctorForm.get('city'); }
    get isRegular() { return this.doctorForm.get('isRegular'); }
    
}
interface DoctorData {
    id: number;
    name: string;
    description: string;
    isDeleted: boolean;

}  
interface IDropDownValues {
    id: number;
    name: string;

}  

