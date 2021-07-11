import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './components/landing-page/landing-page.component';

const routes: Routes = [
  {
    path: '',
    component: LandingPageComponent,
    pathMatch: 'full'
  },
  {
    path: 'search',
    loadChildren: () => import('./modules/seed-search/seed-search.module').then(m => m.SeedSearchModule)
  },
  {
    path: 'view',
    loadChildren: () => import('./modules/seed-view/seed-view.module').then(m => m.SeedViewModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
