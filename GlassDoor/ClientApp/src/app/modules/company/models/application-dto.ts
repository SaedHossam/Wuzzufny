import { EmployeeDto } from './employee-dto';
export interface ApplicationDto {
    id:number,
    applyDate:Date,
    status:string,
    employee:EmployeeDto,
}
