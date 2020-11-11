import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ILoginResponse } from 'src/app/shared/models/loginResponse';

@Injectable({
    providedIn: 'root'
})

export class LoginService {
    constructor(private http: HttpClient) { }

    private Url = environment.apiUrl + `/login`;

    Login(loginName: string): Observable<ILoginResponse> {

        return this.http.get<ILoginResponse>(this.Url + '?loginName=' + loginName)
            .pipe(
                tap(data => { }));
    }
}
