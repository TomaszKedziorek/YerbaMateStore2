import { Component, EventEmitter, Output } from '@angular/core';
import { ICountry } from 'src/app/shared/models/ICountry';
import { IProductBrand } from 'src/app/shared/models/IProductBrand';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-yerba-mate-side-filter',
  templateUrl: './yerba-mate-side-filter.component.html',
  styleUrls: ['./yerba-mate-side-filter.component.scss']
})
export class YerbaMateSideFilterComponent {

  public isCountriesCollapsed: boolean = true;
  public isBrandsCollapsed: boolean = true;

  public brands: IProductBrand[] = [];
  public countries: ICountry[] = [];

  public selectedBrandId: number = 0;
  public selectedCountryId: number = 0;
  @Output() selectCountryEvent = new EventEmitter<number>();
  @Output() selectBrandEvent = new EventEmitter<number>();

  constructor(private shopService: ShopService) { }

  public ngOnInit(): void {
    this.getProductBrands();
    this.getProductCountries();
  }

  public getProductBrands() {
    this.shopService.getProductBrands().subscribe({
      next: result => this.brands = [{ id: 0, name: 'All' }, ...result],
      error: err => console.log(err)
    });
  }

  public getProductCountries() {
    this.shopService.getProductCountries().subscribe({
      next: result => this.countries = [{ id: 0, name: 'All', isoAlfa2Code: "" }, ...result],
      error: err => console.log(err)
    });
  }

  public onSelectedCountry(selectedCountryId: number) {
    this.selectedCountryId = selectedCountryId;
    this.selectCountryEvent.emit(this.selectedCountryId);
  }

  public onSelectedBrand(selectedBrandId: number) {
    this.selectedBrandId = selectedBrandId;
    this.selectBrandEvent.emit(this.selectedBrandId);
  }
}
