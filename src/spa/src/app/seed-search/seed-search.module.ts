import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { SeedSearchRoutingModule } from './seed-search-routing.module';

import { MaterialModule } from '../material.module';

import { ClusterFinderComponent } from './cluster-finder/cluster-finder.component';
import { ApiService } from './services/api.service';


@NgModule({
  declarations: [
    ClusterFinderComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule,
    SeedSearchRoutingModule
  ],
  providers: [
    ApiService
  ]
})
export class SeedSearchModule { }
