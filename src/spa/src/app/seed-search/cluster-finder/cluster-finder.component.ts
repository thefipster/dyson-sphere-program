import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-cluster-finder',
  templateUrl: './cluster-finder.component.html',
  styleUrls: ['./cluster-finder.component.scss']
})
export class ClusterFinderComponent implements OnInit {

  public header: any = null;
  public seeds: any = null;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getSeeds().subscribe((data: any[][]) => {
      this.header = data.shift();
      this.seeds = data;
    });
  }

}
