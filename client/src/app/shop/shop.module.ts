import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { YerbaMateSideFilterComponent } from './yerba-mate-side-filter/yerba-mate-side-filter.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RouterModule } from "@angular/router"; 

@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    YerbaMateSideFilterComponent,
    ProductDetailsComponent
  ],
  imports: [
    CommonModule,
    CollapseModule,
    SharedModule,
    FormsModule,
    RouterModule
  ],
  exports: [
    ShopComponent
  ]
})
export class ShopModule { }
