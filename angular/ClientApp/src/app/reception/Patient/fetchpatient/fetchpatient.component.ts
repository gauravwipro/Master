import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from '@angular/router';
import { PatientService } from '../../services/patientservice.service'
import { PatientData } from '../../models/PatientData'
@Component({
  templateUrl: './fetchpatient.component.html'
})

export class FetchPatientComponent {
    public patientList: PatientData[];
    p: number = 1;
  constructor(private formBuilder: FormBuilder, private _router: Router, private _patientService: PatientService) {
        this.getAll();
    }

    getAll() {
        this._patientService.getAll().subscribe(
            data => this.patientList = data
        )
    }

    delete(id) {
        var ans = confirm("Do you want to delete patient with Id: " + id);
        if (ans) {
            this._patientService.delete(id).subscribe((data) => {
                this.getAll();
            }, error => console.error(error))
        }
    }
}
