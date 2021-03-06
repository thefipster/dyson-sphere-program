import { EventEmitter, Injectable } from '@angular/core';
import { FilterLimits } from '../../interfaces/filter-limits';
import { SeedFilterModel } from '../../interfaces/seed-filter-model';
import { SeedSearchModel } from '../../interfaces/seed-search-model';

@Injectable({
  providedIn: 'root'
})
export class FilterService {
  private filters: { [id: string] : FilterLimits; } = {};
  private column: string = "totalEnergy";
  private direction: string = "desc";
  public onReset = new EventEmitter();

  constructor() { }

  reset() {
    this.filters = {};
    this.onReset.emit();
  }

  resetFilter(column: string) {
    delete this.filters[column];
  }

  setLimitedFilter(column: string, value: number, highValue: number) {
    this.filters[column] = { min: value, max: highValue } as FilterLimits;
  }

  setValuedFilter(column: string, value: string) {
    this.filters[column] = { value: value } as FilterLimits;
  }

  setSearch(column: string, direction: string) {
    this.column = column;
    this.direction = direction;
  }

  getFilters(): SeedFilterModel[] {
    let filters = [];
    for (let key in this.filters) {
      let value = this.filters[key];
      filters.push({ column: key, min: value.min, max: value.max } as SeedFilterModel);
    }
    return filters;
  }

  getSearch(): SeedSearchModel {
    return {
      sortColumn: this.column,
      sortDirection: this.direction,
      filters: this.getFilters()
    } as SeedSearchModel
  }
}
