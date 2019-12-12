import { Component, Output, EventEmitter, Inject, OnInit } from '@angular/core';
import { FormBuilder } from "@angular/forms";
import { Router, ActivatedRoute } from '@angular/router';
import { OpdService } from '../../services/opdservice.service'
import { OptionsInput } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import { AuthenticationService } from '../../../services/authentication.service';
import { User } from '../../../models/user';
import { DatePipe } from '@angular/common'
import { OpdDailyAppointmentData, OpdDoctorUpdateData } from '../../models/OpdDailyAppointmentData';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { OpdHistoryData } from '../../models/OpdShowData';
export interface DialogData {
  opdId: number;
  prescription: string;
  opdNotes: string;
}
@Component({
  templateUrl: './fetchopddetail.component.html',
  styleUrls: ['./fetchopddetail.component.css']
})

export class FetchOpdDetailComponent {
  p: number = 1;
  opdDate: Date;
  currentUser: User;
  public opdDailyAppointmentList: OpdDailyAppointmentData[];
  calendarEvents = [
  ];
  options: OptionsInput;
  eventsModel: any;
  calendarPlugins = [dayGridPlugin, interactionPlugin];
  constructor(private formBuilder: FormBuilder, private _avRoute: ActivatedRoute, private _router: Router,
    private _opdService: OpdService, private authenticationService: AuthenticationService, public dialog: MatDialog,
    public datepipe: DatePipe) {
    if (this._avRoute.snapshot.firstChild.params["opdDate"]) {
      this.opdDate = this._avRoute.snapshot.firstChild.params["opdDate"];
    }
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    _opdService.getDailyAppointments(this.currentUser.id, this.opdDate).subscribe(
      data => this.opdDailyAppointmentList = data
    );
  }
  openDialog(opdDailyAppointmentData: OpdDailyAppointmentData): void {
    const dialogRef = this.dialog.open(EditOpdDetail, {
      data: opdDailyAppointmentData

    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      //this.animal = result;
    });
  }


  openHistoryDialog(opdDailyAppointmentData: OpdDailyAppointmentData): void {
    const dialogRef = this.dialog.open(PatientOpdHistory, {
      data: opdDailyAppointmentData

    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      //this.animal = result;
    });
  }

}




@Component({
  selector: 'EditOpdDetail',
  templateUrl: './editopddetail.component.html',
  styleUrls: ['./fetchopddetail.component.css']
})
export class EditOpdDetail implements OnInit {
  @Output() submitClicked = new EventEmitter<any>();
  errorMessage: any;
  opdDailyAppointmentData: OpdDailyAppointmentData;
  constructor(private _fb: FormBuilder,
    public dialogRef: MatDialogRef<EditOpdDetail>, private _opdService: OpdService,
    @Inject(MAT_DIALOG_DATA) public data: OpdDailyAppointmentData) {
  }


  ngOnInit() {
    this.opdDailyAppointmentData = this.data;
  }
  onSave() {
    this._opdService.save(this.opdDailyAppointmentData).subscribe((data) => {
      this.dialogRef.close();
    }, error => this.errorMessage = error);;
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

}


@Component({
  selector: 'PatientOpdHistory',
  templateUrl: './patientopdhistory.component.html',
  styleUrls: ['./fetchopddetail.component.css']
})
export class PatientOpdHistory implements OnInit {
  @Output() submitClicked = new EventEmitter<any>();
  errorMessage: any;
  opdHistoryData: OpdHistoryData[];
  constructor(private _fb: FormBuilder,
    public dialogRef: MatDialogRef<PatientOpdHistory>, private _opdService: OpdService,
    @Inject(MAT_DIALOG_DATA) public data: OpdDailyAppointmentData) {
    this._opdService.getPatientHistory(this.data.opdId).subscribe(
      data => this.opdHistoryData = data
    )
  }


  ngOnInit() {
    
  };
}
