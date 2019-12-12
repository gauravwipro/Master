import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from '@angular/router';
import { OpdService } from '../../services/opdservice.service'
import { OpdMonthlyAppointmentData } from '../../models/OpdMonthlyAppointmentData'
import { OptionsInput } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import { FullCalendarModule } from '@fullcalendar/angular';
import interactionPlugin from '@fullcalendar/interaction';
import { AuthenticationService } from '../../../services/authentication.service';
import { User } from '../../../models/user';
import { DatePipe } from '@angular/common'

@Component({
  templateUrl: './fetchopd.component.html',
  styleUrls: ['./fetchopd.component.css']
})

export class FetchOpdComponent {
  currentUser: User;
  public opdMonthlyAppointmentList: OpdMonthlyAppointmentData[];
  calendarEvents = [
  ];
  options: OptionsInput;
  eventsModel: any;
  calendarPlugins = [dayGridPlugin, interactionPlugin];
  handleDateClick(arg) { // handler method
    this._router.navigate(['opdDetails/opdList/' + arg.dateStr]);
  }
  constructor(private formBuilder: FormBuilder, private _router: Router, private _opdService: OpdService, private authenticationService: AuthenticationService, public datepipe: DatePipe) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    _opdService.getMonthlyAppointments(this.currentUser.id).subscribe(
      data => {
        data.forEach(p => {
          this.calendarEvents.push(
            { title: p.count.toString(), date: this.datepipe.transform(p.appointmentDate, 'yyyy-MM-dd') }
          );

        })
      }
    );
   
  }


}




