import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SeedModel } from '../../interfaces/seed-model';
import { FilterService } from '../filter/filter.service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl: string = 'https://localhost:44346/api/seeds';

  constructor(
    private http: HttpClient,
    private filterService: FilterService,
  ) { }

  public searchSeeds(): Observable<SeedModel[]> {
    const search = this.filterService.getSearch();
    return this.http.post<SeedModel[]>(this.apiUrl, search);
  }
}
