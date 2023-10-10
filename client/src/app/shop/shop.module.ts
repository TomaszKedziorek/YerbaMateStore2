import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { YerbaMateSideFilterComponent } from './yerba-mate-side-filter/yerba-mate-side-filter.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    YerbaMateSideFilterComponent
  ],
  imports: [
    CommonModule,
    CollapseModule,
    PaginationModule,
    FormsModule
  ],
  exports: [
    ShopComponent
  ]
})
export class ShopModule { }
