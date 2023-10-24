import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/IProduct';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  public product!: any;
  public iproduct!: IProduct;
  public quantity: number = 1;

  constructor(private shopService: ShopService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('id');
    let typeName = this.route.snapshot.paramMap.get('productTypeName') ?? "";
    this.loadProduct(Number(id), typeName);
  }

  public loadProduct(id: number, productType: string) {
    this.shopService.getProduct<IProduct>(id, productType).subscribe({
      next: result => {
        if (result) {
          this.product = result;
        }
      },
      error: err => console.log(err)
    });
  }

  public minusOne() {
    this.quantity = this.quantity - 1 <= 0 ? 1 : this.quantity - 1;
  }
  public plusOne() {
    this.quantity = this.quantity >= this.product.quantity ? this.quantity : this.quantity + 1;
  }
}
