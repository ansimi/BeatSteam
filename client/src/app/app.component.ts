import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string = 'BeatSteam';
  loggedIn: boolean = false;

  constructor() { }

  ngOnInit(): void {

  }
}
