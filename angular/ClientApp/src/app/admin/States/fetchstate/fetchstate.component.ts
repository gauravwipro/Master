import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from '@angular/router';
import { StateService } from '../../services/stateservice.service'
import { StateData } from '../../models/StateData'

@Component({
  templateUrl: './fetchstate.component.html'
})

export class FetchStateComponent {
    public stateList:StateData[];
    p: number = 1;
  constructor(private formBuilder: FormBuilder, private _router: Router, private _stateService: StateService) {
        this.getAll();
    }

    getAll() {
        this._stateService.getAll().subscribe(
            data => this.stateList = data
        )
    }

    delete(id) {
        var ans = confirm("Do you want to delete state with Id: " + id);
        if (ans) {
            this._stateService.delete(id).subscribe((data) => {
                this.getAll();
            }, error => console.error(error))
        }
    }
}
