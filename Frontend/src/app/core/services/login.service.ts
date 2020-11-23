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

    private Url = environment.apiUrl + `/facade/`;

    Login(loginName: string, selectedtype: string): Observable<ILoginResponse> {

        return this.http.get<ILoginResponse>(this.Url + 'login?loginName=' + loginName + '&selectedtype=' + selectedtype)
            .pipe(
                tap(data => { }));
    }
}
