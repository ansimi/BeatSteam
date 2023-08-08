import { Component } from '@angular/core';
import { SteamService } from './services/steam.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'BeatSteam';
  appNews: any;
  steamProfile: any;

  constructor(private steamService: SteamService) { }

  //getNewsForApp() {
  ngOnInit(): void {
      this.steamService.getPlayerProfile('ansimi').subscribe({
        next: response => this.steamProfile = response,
        error: error => console.log(error),
        complete: () => console.log(this.steamProfile)
      });
    }
  }
