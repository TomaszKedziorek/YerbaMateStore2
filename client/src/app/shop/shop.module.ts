import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { YerbaMateSideFilterComponent } from './yerba-mate-side-filter/yerba-mate-side-filter.component';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    YerbaMateSideFilterComponent
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
