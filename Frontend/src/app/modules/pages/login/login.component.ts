import { ILoginResponse } from 'src/app/shared/models/loginResponse';
import { Component } from '@angular/core';
import { LoginService } from 'src/app/core/services/login.service';
import { Router } from '@angular/router';
import { appConstants } from 'src/app/shared/constants/constants';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
})
export class LoginComponent {

    constructor(private loginService: LoginService, private router: Router) { }

    private loginName: string;

    onLogin(): void {
        if (this.loginName) {
            this.loginService.Login(this.loginName).subscribe(loginResponse => {
                sessionStorage.setItem(appConstants.sessionStorageGameId, loginResponse.gameId);
                sessionStorage.setItem(appConstants.sessionStoragePlayerId, loginResponse.playerId);
                this.router.navigateByUrl('/game');
            });
        }
    }
}
