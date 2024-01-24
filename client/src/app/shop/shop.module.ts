import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { YerbaMateSideFilterComponent } from './yerba-mate-side-filter/yerba-mate-side-filter.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { YerbaMateDetailsComponent } from './specificProductDetails/yerba-mate-details/yerba-mate-details.component';
import { BombillaDetailsComponent } from './specificProductDetails/bombilla-details/bombilla-details.component';
import { CupDetailsComponent } from './specificProductDetails/cup-details/cup-details.component'; 
import { ShopRoutingModule } from './shop-routing.module';

@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    YerbaMateSideFilterComponent,
    ProductDetailsComponent,
    YerbaMateDetailsComponent,
    BombillaDetailsComponent,
    CupDetailsComponent
  ],
  imports: [
    CommonModule,
    CollapseModule,
    SharedModule,
    FormsModule,
    ShopRoutingModule
  ],
  exports: [
  ]
})
export class ShopModule { }
