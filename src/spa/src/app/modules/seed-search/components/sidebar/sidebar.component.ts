import { Component, EventEmitter, Output } from '@angular/core';
import { SidenavService } from 'src/app/services/sidenav/sidenav.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {
  @Output() filtersApplied = new EventEmitter();

  constructor(
    public sidenavService: SidenavService,
  ) { }

  submit() {
    this.sidenavService.close().then(() => this.filtersApplied.emit());
  }
}
