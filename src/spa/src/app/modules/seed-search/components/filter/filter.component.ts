import { Component, Input, OnInit } from '@angular/core';
import { Options } from '@angular-slider/ngx-slider';
import { FilterService } from '../../services/filter/filter.service';
import { resetFakeAsyncZone } from '@angular/core/testing';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  @Input() label: string;
  @Input() column: string;
  @Input() min: number;
  @Input() max: number;
  @Input() step: number;

  public value: number = 0;
  public highValue: number = 100;

  private isReady: boolean;

  options: Options = {
    floor: 0,
    ceil: 250
  };

  constructor(
    private filterService: FilterService
  ) {
    filterService.onReset.subscribe(() => this.reset());
   }

  ngOnInit(): void {
    this.reset();
  }

  setOptions(floor: number, ceil: number, step: number): void {
    const newOptions: Options = Object.assign({}, this.options);
    newOptions.ceil = ceil;
    newOptions.floor = floor;
    newOptions.step = step;
    this.options = newOptions;
    this.isReady = true;

    this.value = floor;
    this.highValue = ceil;
  }

  valueChanged() {
    if (!this.isReady) { return; }

    if (this.highValue === this.max && this.value === this.min) {
      this.filterService.resetFilter(this.column);
    } else {
      this.filterService.setLimitedFilter(this.column, this.value, this.highValue);
    }
  }

  reset(): void {
    this.setOptions(this.min, this.max, this.step);
  }
}



