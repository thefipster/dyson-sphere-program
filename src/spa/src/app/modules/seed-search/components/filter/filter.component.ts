import { Component, OnInit } from '@angular/core';
import { Options } from '@angular-slider/ngx-slider';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  public value: number = 100;
  public options: Options = {
    floor: 0,
    ceil: 250
  };

  constructor() { }

  ngOnInit(): void {
  }

}
