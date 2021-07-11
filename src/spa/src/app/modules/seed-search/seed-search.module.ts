import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { SeedSearchRoutingModule } from './seed-search-routing.module';
import { MaterialModule } from 'src/app/material.module';

import { ApiService } from './services/api.service';

import { ClusterFinderComponent } from './components/cluster-finder/cluster-finder.component';

import { SeedPipe } from './pipes/seed/seed.pipe';
import { GasGiantTypePipe } from './pipes/gas-giant-type/gas-giant-type.pipe';


@NgModule({
  declarations: [
    ClusterFinderComponent,
    SeedPipe,
    GasGiantTypePipe,
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
