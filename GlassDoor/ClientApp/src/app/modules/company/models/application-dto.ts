import { EmployeeDto } from './employee-dto';
export interface ApplicationDto {
  id: number,
  applyDate: Date,
  status: string,
  employee: EmployeeDto,
  employeeFirstName: string,
  employeeLastName: string,
  employeeCity: string,
  employeeCountry: string,
  employeeBirthDate: Date,
  employeeExperience: number,
  employeeEducation: string,
  employeePhoto: string
}

