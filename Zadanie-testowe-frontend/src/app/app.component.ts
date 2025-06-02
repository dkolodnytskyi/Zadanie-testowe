import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductListComponent } from './components/product-list/product-list.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ProductListComponent],
  template: `
    <app-product-list></app-product-list>

    <router-outlet />
  `,
  styles: [],
})
export class AppComponent {
  title = 'Zadanie-testowe-frontend';
}
