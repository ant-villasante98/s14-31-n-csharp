import { Routes } from '@angular/router';
import { TestComponent } from './pages/test/test.component';
import { LoginComponent } from './pages/modals/login/login.component';
import { HomeComponent } from './pages/home/home.component';

export const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'test-component',
        component: TestComponent
    },
    {
        path: 'login',
        component: LoginComponent
    }
];
