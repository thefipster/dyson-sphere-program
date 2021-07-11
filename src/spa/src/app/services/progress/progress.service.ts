import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProgressService {
  public isRunning: boolean = false;

  constructor() { }

  turnOn() {
    this.isRunning = true;
  }

  turnOff() {
    this.isRunning = false;
  }

  toggle() {
    this.isRunning = !this.isRunning;
  }
}
