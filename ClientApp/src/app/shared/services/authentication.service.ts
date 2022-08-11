import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { EnvironmentUrlService } from './environment-url.service';

import { UserForRegistrationDto } from '../../interfaces/user.models';
import { RegistrationResponseDto } from '../../interfaces/user.models';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*'
  })
}

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public registerUser = (route: string, body: UserForRegistrationDto) => {
    return this.http.post<RegistrationResponseDto>(this.createCompleteRoute(route, this.envUrl.urlAddress), body, httpOptions);
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
