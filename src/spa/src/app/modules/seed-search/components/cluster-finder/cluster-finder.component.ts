import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { ProgressService } from 'src/app/services/progress/progress.service';
import { SidenavService } from 'src/app/services/sidenav/sidenav.service';
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

  @ViewChild('sidenav') public sidenav: MatSidenav;

  constructor(private apiService: ApiService, private sidenavService: SidenavService, private progressService: ProgressService) { }

  ngOnInit(): void {
    this.apiService.getSeeds().subscribe((data: SeedModel[]) => {
      this.seeds = data;
      this.progressService.turnOff();
    });
  }

  ngAfterViewInit(): void {
    this.sidenavService.setSidenav(this.sidenav);
  }

  ngOnDestroy(): void {
    this.sidenavService.reset();
    this.progressService.turnOff();
  }

  sortData(sort: any) {
      this.progressService.turnOn();

     const search = { 
       sortDirection: sort.direction,
       sortColumn: sort.active
     } as SeedSearchModel;

     this.apiService.searchSeeds(search).subscribe((data: SeedModel[]) => {
       this.seeds = data;
      this.progressService.turnOff();
     })
  }
}
