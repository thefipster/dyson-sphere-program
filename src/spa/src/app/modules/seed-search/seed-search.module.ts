import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';

import { SeedSearchRoutingModule } from './seed-search-routing.module';
import { MaterialModule } from 'src/app/material.module';
import { NgxSliderModule } from "@angular-slider/ngx-slider";

import { ClusterFinderComponent } from './components/cluster-finder/cluster-finder.component';
import { FilterComponent } from './components/filter/filter.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';

import { SeedPipe } from './pipes/seed/seed.pipe';
import { GasGiantTypePipe } from './pipes/gas-giant-type/gas-giant-type.pipe';

import { ApiService } from './services/api/api.service';
import { FilterService } from './services/filter/filter.service';

@NgModule({
  declarations: [
    ClusterFinderComponent,
    FilterComponent,
    SeedPipe,
    GasGiantTypePipe,
    SidebarComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    MaterialModule,
    NgxSliderModule,
    SeedSearchRoutingModule,
    FlexLayoutModule
  ],
  providers: [
    ApiService,
    FilterService
  ]
})
export class SeedSearchModule { }
