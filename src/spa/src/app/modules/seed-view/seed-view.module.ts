import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SeedViewRoutingModule } from './seed-view-routing.module';
import { MaterialModule } from 'src/app/material.module';

import { ClusterInfoComponent } from './components/cluster-info/cluster-info.component';


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
