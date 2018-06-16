import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { ErrorComponent } from './error/error.component';
import { AppRoute } from './shared/app.routes';
/**
 * Route constant 
 */
const routes: Routes = [
    { path: '', redirectTo: AppRoute.home, pathMatch: 'full' },
    
    //temp for testing
    { path: 'home', component: HomeComponent},
    { path: AppRoute.error, component: ErrorComponent },
    { path: AppRoute.login, component: LoginComponent },
    { path: AppRoute.register, component: RegisterComponent },
    // { path: '', component: AdminLayoutComponent, children: Admin_Routes },
    // { path: '', component: AuthLayoutComponent, children: Auth_Routes },
    { path: '**', redirectTo: AppRoute.home }
];

/**
 * App routing module
 */
@NgModule({

    imports: [
        RouterModule.forRoot(routes, { useHash: true })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }