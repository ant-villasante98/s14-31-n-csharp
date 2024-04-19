import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { authRoutes } from './pages/auth/auth.routes';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { SearchComponent } from './pages/search/search.component';
import { ShopComponent } from './pages/locals/shop.component';

export const routes: Routes = [
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'auth',
        loadComponent: () => import('./pages/auth/auth.component').then(c => c.AuthComponent),
        children: authRoutes
    },
    {
        path: 'search',
        component: SearchComponent
    },
    {
        path: 'shop',
        component: ShopComponent
    },
    {
        // Componente de prueba
        path: 'test-component',
        loadComponent: () => import('./pages/test/test.component').then(c => c.TestComponent),
    },
    {
        path: '',
        redirectTo: "/home",
        pathMatch: 'full'
    },
    {
        path: '**',
        component: NotFoundComponent
    }
];
