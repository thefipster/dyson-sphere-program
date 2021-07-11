import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClusterFinderComponent } from './components/cluster-finder/cluster-finder.component';

const routes: Routes = [
  {
    path: '',
    component: ClusterFinderComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SeedSearchRoutingModule { }