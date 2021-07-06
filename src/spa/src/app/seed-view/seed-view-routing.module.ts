import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClusterInfoComponent } from './cluster-info/cluster-info.component';



const routes: Routes = [
  {
    path: '',
    component: ClusterInfoComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SeedViewRoutingModule { }