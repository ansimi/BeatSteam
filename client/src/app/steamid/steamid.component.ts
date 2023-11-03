import { Component } from '@angular/core';
import { SteamService } from '../services/steam.service';

@Component({
  selector: 'app-steamid',
  templateUrl: './steamid.component.html',
  styleUrls: ['./steamid.component.css']
})
export class SteamidComponent {

  steamUsername: string = "";
  steamId: string = "";
  steamProfile: any; //Convert to a Model

  steamIdLogin: boolean = false;

  constructor(private steamService: SteamService) {
  }

  ngOnInit(): void {
  }

  loginWithSteamName() {
    this.steamService.getPlayerProfileFromSteamName(this.steamUsername).subscribe({
      next: response => this.steamProfile = response,
      error: error => console.log(error),
      complete: () => console.log(this.steamProfile)
    });
  }

  loginWithSteamId() {
    this.steamService.getPlayerProfileFromSteamID(this.steamId).subscribe({
      next: response => this.steamProfile = response,
      error: error => console.log(error),
      complete: () => console.log(this.steamProfile)
    });
  }

  steamIdLoginSwitch() {
    this.steamIdLogin = !this.steamIdLogin;
  }

}
