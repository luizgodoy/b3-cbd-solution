import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { Cdb } from '../models/cdb';

var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

@Injectable({
  providedIn: 'root'
})
export class CdbService {

  url = 'https://localhost:44369/cdb';  
  constructor(private http: HttpClient) { }

  getCdb(principal: number, vencimento: number): Observable<Cdb> {
    const apiurl = `${this.url}?Principal=${principal}&Vencimento=${vencimento}`;
    return this.http.get<Cdb>(apiurl);
  }
}