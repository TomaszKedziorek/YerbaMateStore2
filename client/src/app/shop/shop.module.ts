import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { YerbaMateSideFilterComponent } from './yerba-mate-side-filter/yerba-mate-side-filter.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RouterModule } from "@angular/router";
import { YerbaMateDetailsComponent } from './specificProductDetails/yerba-mate-details/yerba-mate-details.component';
import { BombillaDetailsComponent } from './specificProductDetails/bombilla-details/bombilla-details.component';
import { CupDetailsComponent } from './specificProductDetails/cup-details/cup-details.component'; 

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
    RouterModule
  ],
  exports: [
    ShopComponent
  ]
})
export class ShopModule { }
