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
    
    types : string[] = ["Dark","Earth",'Fire','Holy','Light','Water','Wind'];
    private selectedtype: string;
    private loginName: string;

    onLogin(): void {
        if (this.loginName && this.selectedtype) {
            
            this.loginService.Login(this.loginName, this.selectedtype).subscribe(loginResponse => {
                sessionStorage.setItem(appConstants.sessionStorageGameId, loginResponse.gameId);
                sessionStorage.setItem(appConstants.sessionStoragePlayerId, loginResponse.playerId);
                this.router.navigateByUrl('/game');
            });
        }
    }
}
