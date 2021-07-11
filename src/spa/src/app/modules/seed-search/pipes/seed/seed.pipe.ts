import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'seed'
})
export class SeedPipe implements PipeTransform {

  transform(value: number): unknown {
    let paddedSeed = value.toString().padStart(8, "0")
    return paddedSeed.slice(0, 4) + ' ' + paddedSeed.slice(4);
  }

}
