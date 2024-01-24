import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/IProduct';
import { ShopService } from '../shop.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductType } from 'src/app/shared/models/product-type';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  public product!: any;
  public quantity: number = 1;
  public productType!: ProductType;
  public allTypes = ProductType;

  constructor(private shopService: ShopService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('id');
    let productTypeName = this.route.snapshot.paramMap.get('productTypeName') ?? "";
    this.productType = this.setProductType(productTypeName);
    this.loadProduct(Number(id), productTypeName);
  }

  private setProductType(productTypeName: string): number {
    switch (productTypeName.toUpperCase()) {
      case ProductType[ProductType.YERBAMATE]:
        return ProductType.YERBAMATE;
      case ProductType[ProductType.BOMBILLA]:
        return ProductType.BOMBILLA;
      case ProductType[ProductType.CUP]:
        return ProductType.CUP;
      default: return 0;
    }
  }

  public loadProduct(id: number, productType: string) {
    this.shopService.getProduct<IProduct>(id, productType).subscribe({
      next: result => {
        if (result) {
          if (!productType)
            this.router.navigate(['/shop/', result.productType.toLowerCase().replace(/\s/g, ''), id]);
          else
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
