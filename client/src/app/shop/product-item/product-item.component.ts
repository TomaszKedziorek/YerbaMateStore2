import { Component, Input } from '@angular/core';
import { IProduct } from 'src/app/shared/models/IProduct';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent {

  @Input() product!: IProduct;

  public getProductTypeName() {
    return this.product.productType ? this.product.productType.toLowerCase().replace(/\s/g, '') : "";
  }
}
