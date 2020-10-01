import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })

  export class ClickService {
    constructor(private http: HttpClient) { }

    private Url = `http://localhost:5000/api/health`;

    sendClick() {
          this.http.get(this.Url).subscribe();
    }
}