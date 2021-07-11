import { NgModule } from '@angular/core';

import { MatToolbarModule } from '@angular/material/toolbar'
import { MatIconModule } from '@angular/material/icon'
import { MatButtonModule } from '@angular/material/button'
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner'
import { MatProgressBarModule } from '@angular/material/progress-bar'
import { MatChipsModule } from '@angular/material/chips'
import { MatSliderModule } from '@angular/material/slider'
import { MatTableModule } from '@angular/material/table'
import { MatSortModule } from '@angular/material/sort';
import { MatTooltipModule } from '@angular/material/tooltip';



@NgModule({
  declarations: [],
  imports: [],
  exports: [
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatChipsModule,
    MatSliderModule,
    MatTableModule,
    MatProgressBarModule,
    MatSortModule,
    MatTooltipModule
  ]
})
export class MaterialModule { }
