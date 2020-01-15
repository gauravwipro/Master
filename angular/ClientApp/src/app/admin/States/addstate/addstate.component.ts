import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchStateComponent } from '../fetchstate/fetchstate.component';
import { StateService } from '../../services/stateservice.service';
@Component({
  templateUrl: './AddState.component.html'
})

export class CreateState implements OnInit {
    stateForm: FormGroup;
    title: string = "Create";
    Id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _stateService: StateService, private _router: Router) {
      if (this._avRoute.snapshot.firstChild.params["id"]) {
          this.Id = this._avRoute.snapshot.firstChild.params["id"];
        }

        this.stateForm = this._fb.group({
            id: 0,
            name: ['', [Validators.required]],
        })
     
    }

    ngOnInit() {

        if (this.Id > 0) {
            this.title = "Edit";
            this._stateService.get(this.Id)
                .subscribe(resp => this.stateForm.setValue(resp)
                    , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.stateForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._stateService.save(this.stateForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/state']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._stateService.update(this.stateForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/state']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/state']);
    }


    get name() { return this.stateForm.get('name'); }
   
    
}

