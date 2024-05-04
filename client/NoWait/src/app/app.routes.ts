import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { authRoutes } from './pages/auth/auth.routes';
import { SearchComponent } from './pages/search/search.component';
import { authGuard } from './shared/guards/auth.guard';

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
        loadComponent: () => import('./pages/locals/shop.component').then(c => c.ShopComponent)
    },
    {
        path: 'shop/:id',
        loadComponent: () => import('./pages/shop-detail/shop-detail.component').then(c => c.ShopDetailComponent)
    },
    {
        // Componente de prueba
        path: 'test-component',
        loadComponent: () => import('./pages/test/test.component').then(c => c.TestComponent),
    },
    {
        path: 'user',
        loadComponent: () => import('./pages/user/user.component').then(c => c.UserComponent),
        canActivate: [authGuard]
    },
    {
        path: 'create-order',
        loadComponent: () => import('./pages/create-order/create-order.component').then(c => c.CreateOrderComponent),
        canActivate: [authGuard]
    },
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: '**',
        loadComponent: () => import('./pages/not-found/not-found.component').then(c => c.NotFoundComponent)
    }
];
