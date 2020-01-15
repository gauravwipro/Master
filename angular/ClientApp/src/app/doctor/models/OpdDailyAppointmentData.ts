export interface OpdDailyAppointmentData {
  doctorName: string,
  count: number,
  appointmentDate: Date,
  tokenNumber: number,
  patientName: string,
  departmentName: string,
  opdId: number,
  isChecked: boolean,
  opdNotes: string,
  prescription:string
}

export interface OpdDoctorUpdateData {
  opdId: number,
  opdNotes: string,
  prescription: string
}

