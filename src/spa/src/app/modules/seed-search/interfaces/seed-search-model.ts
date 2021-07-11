import { SeedFilterModel } from "./seed-filter-model";

export interface SeedSearchModel {
    sortColumn: string;
    sortDirection: string;
    filters: SeedFilterModel[];
}
