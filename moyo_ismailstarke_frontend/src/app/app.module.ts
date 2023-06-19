import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomepageComponent } from './Client-Side/homepage/homepage.component';
import { ClientNavbarComponent } from './Client-Side/client-navbar/client-navbar.component';
import { ViewProductsComponent } from './Client-Side/view-products/view-products.component';
import { CartComponent } from './Client-Side/cart/cart.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './Admin-Side/dashboard/dashboard.component';
import { MenuComponent } from './Admin-Side/menu/menu.component';
import { ProductListingComponent } from './Admin-Side/product-listing/product-listing.component';
import { StockTakeComponent } from './Admin-Side/stock-take/stock-take.component';

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    ClientNavbarComponent,
    ViewProductsComponent,
    CartComponent,
    RegistrationComponent,
    LoginComponent,
    DashboardComponent,
    MenuComponent,
    ProductListingComponent,
    StockTakeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
