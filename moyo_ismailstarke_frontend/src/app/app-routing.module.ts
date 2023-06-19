import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//Client Imports
import { HomepageComponent } from './Client-Side/homepage/homepage.component';
import { ClientNavbarComponent } from './Client-Side/client-navbar/client-navbar.component';
import { ViewProductsComponent } from './Client-Side/view-products/view-products.component';
import { CartComponent } from './Client-Side/cart/cart.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './Admin-Side/dashboard/dashboard.component';
import { ProductListingComponent } from './Admin-Side/product-listing/product-listing.component';
import { StockTakeComponent } from './Admin-Side/stock-take/stock-take.component';

const routes: Routes = [
  //Client Side Routes
  { path: '', redirectTo:'product-listing', pathMatch:'full' },
  { path: 'homepage', component: HomepageComponent },
  { path: 'view-products', component: ViewProductsComponent},
  { path: 'cart', component: CartComponent},

  //Admin Side Routes
  { path: 'dashboard', component: DashboardComponent},
  { path: 'product-listing', component: ProductListingComponent},
  { path: 'stock-take', component: StockTakeComponent},

  //Shared Routes
  { path: 'register', component: RegistrationComponent},
  { path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
