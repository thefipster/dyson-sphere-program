import { Component, EventEmitter, Output } from '@angular/core';
import { SidenavService } from 'src/app/services/sidenav/sidenav.service';
import { FilterService } from '../../services/filter/filter.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {
  @Output() filtersApplied = new EventEmitter();

  birthGiant: string = '';

  constructor(
    public sidenavService: SidenavService,
    public filterService: FilterService
  ) { 
    filterService.onReset.subscribe(() => {
      this.birthGiant = '';
      console.log("Resetting baby")
    } );
  }

  submit() {
    this.sidenavService.close().then(() => this.filtersApplied.emit());
  }

  birthGiantChanged(event: any) {
    const column = 'isBirthGiantIce';
    if (event.value === '') {
      this.filterService.resetFilter(column);
    } else {
      this.filterService.setValuedFilter(column, event.value);
    }
  }
}
