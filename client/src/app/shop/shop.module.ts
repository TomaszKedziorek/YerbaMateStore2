import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent
  ],
  imports: [
    CommonModule,
    CollapseModule
  ],
  exports: [
    ShopComponent
  ]
})
export class ShopModule { }
