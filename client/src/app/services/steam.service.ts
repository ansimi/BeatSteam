import { HttpParams, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SteamService {

  constructor(private http: HttpClient) { }

  getPlayerProfileFromSteamName(steamUsername: string) {
    let params = new HttpParams();
    params = params.append('username', steamUsername);

    return this.http.get('https://localhost:5001/API/SteamProfile', {params: params});
  }

  getPlayerProfileFromSteamID(steamid: string) {
    let params = new HttpParams();
    params = params.append('steamid', steamid);

    return this.http.get('https://localhost:5001/API/SteamProfile/SteamID', {params: params});
  }

}
