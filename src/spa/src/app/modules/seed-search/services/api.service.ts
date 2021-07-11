import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SeedModel } from '../interfaces/seed-model';
import { SeedSearchModel } from '../interfaces/seed-search-model';
import { SeedSearchModule } from '../seed-search.module';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private apiUrl: string = 'https://localhost:44346/api/seeds';

  constructor(private http: HttpClient) { }

  public getSeeds(): Observable<SeedModel[]> {
    return this.http.get<SeedModel[]>(this.apiUrl);
  }

  public searchSeeds(search: SeedSearchModel): Observable<SeedModel[]> {
    return this.http.post<SeedModel[]>(this.apiUrl, search);
  }
}
