import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { RouterModule } from "@angular/router"; 

@NgModule({
  declarations: [
    NavBarComponent
  ],
  imports: [
    CommonModule,
    CollapseModule,
    RouterModule
  ],
  exports: [
    NavBarComponent
  ]
})
export class CoreModule { }
