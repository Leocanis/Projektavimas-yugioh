import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })

  export class HealthService {
    constructor(private http: HttpClient) { }

    private Url = `http://localhost:5000/api/click`;

    getHealth() {
          this.http.get(this.Url).subscribe();
    }
}