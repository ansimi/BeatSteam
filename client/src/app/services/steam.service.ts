import { HttpParams, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SteamService {
  baseUrl: string = 'http://api.steampowered.com/';
  news: string = 'ISteamNews/GetNewsForApp/v0002/';
  user: string = 'ISteamUser/';
  userstats: string = 'ISteamUserStats/';
  playerservice: string = 'IPlayerService/';

  format: string = 'json';

  constructor(private http: HttpClient) { }

  getNewsForApp(appId: string, count: number, maxLength: number) {
    let params = new HttpParams();
    params = params.append('appid', appId);
    params = params.append('count', count);
    params = params.append('maxlength', maxLength);
    params = params.append('format', this.format);

    //return this.http.get(this.baseUrl + this.news, {params: params});
    return this.http.get('https://localhost:5001/API/Test');
  }

}
