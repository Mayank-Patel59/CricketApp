import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CricketService {

  apiUrl: 'http://localhost:5000/api/Values/';
  constructor(private http: HttpClient) { }

  GetCountries() {
    return this.http.get('http://localhost:5000/api/Values/GetCountries');
  }
}
