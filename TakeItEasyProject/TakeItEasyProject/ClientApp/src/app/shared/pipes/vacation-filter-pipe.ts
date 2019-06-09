import { Pipe, PipeTransform } from '@angular/core';
import { Vacation } from '../models/Vacation';

@Pipe({
  name: 'vacationFilterPipe'
})
export class VacationFilterPipe implements PipeTransform {

  transform(value: Vacation[], args?: string): Vacation[] {
    if (args) {
        return (value || []).filter((item: Vacation) => {
          return item.vacationPoints.filter(point => point.locationType === 1)[0].address.toLowerCase().normalize('NFD').replace(/[\u0300-\u036f]/g, "").includes(args.toLowerCase().normalize('NFD').replace(/[\u0300-\u036f]/g, ""));
        });
    } else {
        return value;
    }   
  }
}
