import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SeedViewRoutingModule } from './seed-view-routing.module';

import { MaterialModule } from '../material.module';

import { ClusterInfoComponent } from './cluster-info/cluster-info.component';

@NgModule({
  declarations: [
    ClusterInfoComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    SeedViewRoutingModule
  ]
})
export class SeedViewModule { }
