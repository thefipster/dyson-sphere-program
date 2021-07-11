import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort, Sort } from '@angular/material/sort';
import { SeedModel } from '../../interfaces/seed-model';
import { SeedSearchModel } from '../../interfaces/seed-search-model';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-cluster-finder',
  templateUrl: './cluster-finder.component.html',
  styleUrls: ['./cluster-finder.component.scss']
})
export class ClusterFinderComponent implements OnInit {

  public isSearching: boolean = true;
  public seeds: SeedModel[] = [];
  public displayedColumns: string[] = [
    'seed',
    'oTypeCount',
    'giantCount',
    'dwarfCount',
    'neutronStarCount',
    'blackHoleCount',
    'gasGiantCount',
    'iceGiantCount',
    'maxLuminosity',
    'maxRadius',
    'avgResourceCoeficient',
    'unipolarCoeficient',
    'maxStarEnergy',
    'totalEnergy',
    'averageDistance',
    'birthMoonCount',
    'isBirthGiantIce'
  ];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getSeeds().subscribe((data: SeedModel[]) => {
      this.seeds = data;
      this.isSearching = false;
    });
  }

  sortData(sort: any) {
    this.isSearching = true;

     const search = { 
       sortDirection: sort.direction,
       sortColumn: sort.active
     } as SeedSearchModel;

     this.apiService.searchSeeds(search).subscribe((data: SeedModel[]) => {
       this.seeds = data;
       this.isSearching = false;
     })
  }
}
