import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'gasGiantType'
})
export class GasGiantTypePipe implements PipeTransform {

  transform(value: boolean): unknown {
    return value ? 'Ice' : 'Gas';
  }

}
