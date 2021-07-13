import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ProgressService } from 'src/app/services/progress/progress.service';
import { SidenavService } from 'src/app/services/sidenav/sidenav.service';
import { SeedModel } from '../../interfaces/seed-model';
import { SeedSearchModel } from '../../interfaces/seed-search-model';
import { ApiService } from '../../services/api/api.service';
import { FilterService } from '../../services/filter/filter.service';

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

  constructor(
    private apiService: ApiService,
    private sidenavService: SidenavService,
    private progressService: ProgressService,
    private filterService: FilterService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.getData();
  }

  ngAfterViewInit(): void {
    this.sidenavService.setSidenavWithIcon(this.sidenav, 'filter_alt');
  }

  ngOnDestroy(): void {
    this.sidenavService.reset();
    this.progressService.turnOff();
  }

  sortChanged(sort: any) {
    this.filterService.setSearch(sort.active, sort.direction);
    this.getData();
  }

  getData() {
    this.progressService.turnOn();
    this.apiService.searchSeeds().subscribe((data: SeedModel[]) => {
      this.seeds = data;
      this.progressService.turnOff();
    },
      _ => {
        this.progressService.turnOff();
        var ref = this.snackBar.open(
          "Well that didn't work for some reason.", 
          "Maybe retry?", 
          { duration: 5000 }
        );
        ref.onAction().subscribe(() => this.getData());
      })
  }
}
