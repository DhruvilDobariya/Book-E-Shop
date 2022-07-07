import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignUpComponent } from './Components/User/sign-up/sign-up.component';
import { SignInComponent } from './Components/User/sign-in/sign-in.component';
import { FormsModule } from '@angular/forms';
import { BookIndexComponent } from './Components/Book/book-index/book-index.component';
import { CategoryIndexComponent } from './Components/Category/category-index/category-index.component';
import { CategoryAddEditComponent } from './Components/Category/category-add-edit/category-add-edit.component';
import { BookAddEditComponent } from './Components/Book/book-add-edit/book-add-edit.component';
import { CartIndexComponent } from './Components/Cart/cart-index/cart-index.component';
import { UserIndexComponent } from './Components/User/user-index/user-index.component';
import { BookDetailComponent } from './Components/Book/book-detail/book-detail.component';

@NgModule({
    declarations: [
        AppComponent,
        SignUpComponent,
        SignInComponent,
        BookIndexComponent,
        CategoryIndexComponent,
        CategoryAddEditComponent,
        BookAddEditComponent,
        CartIndexComponent,
        UserIndexComponent,
        BookDetailComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        FormsModule,
        HttpClientModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
