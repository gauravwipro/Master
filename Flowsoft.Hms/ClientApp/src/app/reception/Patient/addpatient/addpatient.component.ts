import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchPatientComponent } from '../fetchpatient/fetchpatient.component';
import { PatientService } from '../../services/patientservice.service';
import { OpdService } from '../../services/opdservice.service';
import { MatTabsModule } from '@angular/material/tabs';
import { DepartmentData } from '../../../admin/models/DepartmentData';
import { DoctorData } from '../../../admin/models/DoctorData';
import { OpdCreateData } from '../../../admin/models/OpdCreateData';
import { OpdShowData } from '../../../admin/models/OpdShowData';
import { debounce } from 'rxjs/operators';
@Component({
  templateUrl: './AddPatient.component.html'
})

export class CreatePatient implements OnInit {

  //event handler for the select element's change event
  selectDepartmentHandler(event: any) {
    //update the ui
    this.selectedDepartment = event.target.value;

    this._patientService.getDoctorList(this.selectedDepartment).subscribe(
      data => this.doctorList = data,
      error => console.log("Error :: " + error)
    )
  }
  patientForm: FormGroup;
  opdForm: FormGroup;
  title: string = "Create";
  Id: number;
  crnumber: number;
  errorMessage: any;
  public opdList: OpdShowData[];
  public stateList: IDropDownValues[];
  selectedDepartment: string = '';
  public departmentList: DepartmentData[];
  public doctorList: DoctorData[];
  public genderList: IDropDownValues[];
  constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _patientService: PatientService, private _opdService: OpdService, private _router: Router) {
    if (this._avRoute.snapshot.firstChild.params["id"]) {
      this.Id = this._avRoute.snapshot.firstChild.params["id"];
      this.crnumber = this.Id;
    }


    this.patientForm = this._fb.group({
      id: 0,
      crnumber: 0,
      adhaarCard: '',
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      address: ['', [Validators.required]],
      city: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
      emergencyNumber: ['', [Validators.required]],
      stateId: ['0', [Validators.required]],
      genderId: ['0', [Validators.required]],
      createdDate: new Date(),
      voterCard: '',
    })

    this.opdForm = this._fb.group({
      id: 0,
      departmentId: ['0', [Validators.required]],
      doctorId: ['0', [Validators.required]],
      OpdDate: '',
      patientId: this.Id,
    })

  }

  ngOnInit() {


    this._patientService.getStateList().subscribe(
      data => this.stateList = data,
      error => console.log("Error :: " + error)
    );

    this._patientService.getDepartmentList().subscribe(
      data => this.departmentList = data,
      error => console.log("Error :: " + error)
    );
    this._patientService.getGenderList().subscribe(
      data => this.genderList = data,
      error => console.log("Error :: " + error)
    );
    if (this.Id > 0) {
      this.title = "Edit";
      this._patientService.get(this.Id)
        .subscribe(resp => this.patientForm.setValue(resp)
          , error => this.errorMessage = error);

      this._opdService.getTodayAppointment(this.Id).subscribe(
        data => this.opdList = data,
        error => console.log("Error :: " + error)
      );
    }


  }

  save() {

    if (!this.patientForm.valid) {
      return;
    }
    debugger
    if (this.title == "Create") {
      this._patientService.save(this.patientForm.value)
        .subscribe((data) => {
          this._router.navigate(['patient']);
        }, error => this.errorMessage = error)
    }
    else if (this.title == "Edit") {
      this._patientService.update(this.patientForm.value)
        .subscribe((data) => {
          this._router.navigate(['patient']);
        }, error => this.errorMessage = error)
    }
  }

  saveOpd() {
    if (!this.opdForm.valid) {
      return;
    }

    this._opdService.saveOpd(this.opdForm.value).subscribe((data) => {
        this._router.navigate(['patient']);
      }, error => this.errorMessage = error)
  }

  cancel() {
    this._router.navigate(['patient']);
  }

  get adhaarCard() { return this.patientForm.get('adhaarCard'); }
  get firstName() { return this.patientForm.get('firstName'); }
  get lastName() { return this.patientForm.get('lastName'); }
  get address() { return this.patientForm.get('address'); }
  get phoneNumber() { return this.patientForm.get('phoneNumber'); }
  get emergencyNumber() { return this.patientForm.get('emergencyNumber'); }
  get stateId() { return this.patientForm.get('stateId'); }
  get genderId() { return this.patientForm.get('genderId'); }
  get city() { return this.patientForm.get('city'); }
  get voterCard() { return this.patientForm.get('voterCard'); }

  get departmentId() { return this.opdForm.get('departmentId'); }
  get doctorId() { return this.opdForm.get('doctorId'); }
  get OpdDate() { return this.opdForm.get('OpdDate'); }
}
interface IDropDownValues {
  id: number;
  name: string;

}

