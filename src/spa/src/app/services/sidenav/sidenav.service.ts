import { Injectable } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Injectable()
export class SidenavService {
    private sidenav: MatSidenav;
    private ready: boolean = false;


    public setSidenav(sidenav: MatSidenav) {
        this.sidenav = sidenav;
        this.ready = true;
    }

    public reset() {
        this.ready = false;
    }

    public isReady(): boolean {
        return this.ready;
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