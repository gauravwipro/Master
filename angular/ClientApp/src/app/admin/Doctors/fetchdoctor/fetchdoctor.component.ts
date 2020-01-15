import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from '@angular/router';
import { DoctorService } from '../../services/doctorservice.service';
import { DoctorData } from '../../models/DoctorData';
import { StateData } from '../../models/StateData';
import { DropDownValues } from '../../models/DropDownValues';
@Component({
  templateUrl: './fetchdoctor.component.html'
})

export class FetchDoctorComponent {
    public doctorList:DoctorData[];
    p: number = 1;
  constructor(private formBuilder: FormBuilder, private _router: Router, private _doctorService: DoctorService) {
        this.getDoctors();
    }

    getDoctors() {
        this._doctorService.getDoctors().subscribe(
            data => this.doctorList = data
        )
    }

    delete(doctorID) {
        var ans = confirm("Do you want to delete doctor with Id: " + doctorID);
        if (ans) {
            this._doctorService.deleteDoctor(doctorID).subscribe((data) => {
                this.getDoctors();
            }, error => console.error(error))
        }
    }
}

