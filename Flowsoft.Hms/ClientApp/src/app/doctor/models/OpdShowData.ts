export interface OpdShowData {
  Id: number;
  departmentName: string;
  doctorName: string;
  patientName: string;
  opdDate: Date;
  tokenNumber: number
}
export interface OpdHistoryData {
  doctorName: string,
  opdDate: Date,
  tokenNumber: number,
  patientName: string,
  departmentName: string,
  opdNotes: string,
  prescription: string
}
