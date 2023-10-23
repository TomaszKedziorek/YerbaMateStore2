import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagerComponent } from './components/pager/pager.component';
import { CaruselComponent } from './components/carusel/carusel.component';
import { SlickCarouselModule } from 'ngx-slick-carousel';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    CaruselComponent,
  ],
  imports: [
    CommonModule,
    PaginationModule,
    SlickCarouselModule,
  ],
  exports: [
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    CaruselComponent
  ]
})
export class SharedModule { }
