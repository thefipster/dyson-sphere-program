import { Component, ViewChild } from '@angular/core';
import { MatProgressBar } from '@angular/material/progress-bar';
import { ProgressService } from 'src/app/services/progress/progress.service';
import { SidenavService } from 'src/app/services/sidenav/sidenav.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent {
  @ViewChild('progressBar') public sidenav: MatProgressBar;

  constructor(public sidenavService: SidenavService, public progressService: ProgressService) { }
}
