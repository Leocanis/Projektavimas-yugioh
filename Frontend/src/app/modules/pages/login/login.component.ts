import { ILoginResponse } from 'src/app/shared/models/loginResponse';
import { Component } from '@angular/core';
import { LoginService } from 'src/app/core/services/login.service';
import { Router } from '@angular/router';

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
                sessionStorage.setItem('gameId', loginResponse.gameId);
                sessionStorage.setItem('playerId', loginResponse.playerId);
                this.router.navigateByUrl('/game');
            });
        }
    }
}
