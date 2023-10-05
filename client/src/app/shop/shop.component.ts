import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/IProduct';
import { IBombilla } from '../shared/models/IBombilla';
import { IYerbaMate } from '../shared/models/IYerbaMate';
import { ICup } from '../shared/models/ICup';
import { ShopService } from './shop.service';
import { IPagination } from '../shared/models/IPagination';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  isCollapsed = false;

  public products: IProduct[] = [];
  public yerbaMateProducts: IYerbaMate[] = [];
  public bombillaProducts: IBombilla[] = [];
  public cupProducts: ICup[] = [];

  constructor(private shopService: ShopService) { }

  public ngOnInit(): void {
    this.shopService.getProducts<IProduct>().subscribe({
      next: result => this.products = result.data,
      error: err => console.log(err)
    });
  }
}
