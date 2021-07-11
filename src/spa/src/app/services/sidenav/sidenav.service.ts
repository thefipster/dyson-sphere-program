import { Injectable } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Injectable()
export class SidenavService {
    private sidenav: MatSidenav;

    public isReady: boolean = false;
    public icon: string = 'menu';


    public setSidenav(sidenav: MatSidenav) {
        this.sidenav = sidenav;
        this.isReady = true;
    }

    public setSidenavWithIcon(sidenav: MatSidenav, icon: string) {
        this.sidenav = sidenav;
        this.isReady = true;
        this.icon = icon;
    }

    public reset() {
        this.isReady = false;
        this.icon = 'menu';
    }

    public open() {
        console.log("Open sidenav")
        return this.sidenav.open();
    }


    public close() {
        return this.sidenav.close();
    }

    public toggle(): void {
    this.sidenav.toggle();
   }
}