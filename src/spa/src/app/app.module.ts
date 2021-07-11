import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { MaterialModule } from './material.module';

import { SeedSearchModule } from './modules/seed-search/seed-search.module';
import { SeedViewModule } from './modules/seed-view/seed-view.module';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { ToolbarComponent } from './components/toolbar/toolbar.component';

import { ProgressService } from './services/progress/progress.service';
import { SidenavService } from './services/sidenav/sidenav.service';


@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    ToolbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SeedSearchModule,
    SeedViewModule,
    BrowserAnimationsModule,
    MaterialModule,
  ],
  providers: [
    SidenavService, 
    ProgressService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
