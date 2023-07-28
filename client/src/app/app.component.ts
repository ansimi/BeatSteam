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

  constructor(private steamService: SteamService) { }

  //getNewsForApp() {
  ngOnInit(): void {
    this.steamService.getNewsForApp('1687950', 3, 300).subscribe({
      next: response => this.appNews = response,
      error: error => console.log(error),
      complete : () => console.log(this.appNews)
    })
  }

}
