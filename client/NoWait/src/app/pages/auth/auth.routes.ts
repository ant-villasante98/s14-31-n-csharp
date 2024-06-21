import { Routes } from "@angular/router";
import { LoginComponent } from "./pages/login/login.component";
import { SignUpComponent } from "./pages/sign-up/sign-up.component";

export const authRoutes: Routes = [
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'sign-up',
        component: SignUpComponent
    },
    {
        path: '',
        redirectTo: 'login',
        pathMatch: "full"
    }
]