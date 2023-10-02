import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from './../environments/environment';
import { IProduct } from './models/IProduct';
import { IPagination } from './models/IPagination';
import { IBombilla } from './models/IBombilla';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public title: string = 'Yerba Mate Sotre 2.0';
  public products: IProduct[] = [];
  public bombillas: IBombilla[] = [];

  public constructor(private http: HttpClient) {

  }

  public ngOnInit(): void {
    this.http.get<IPagination<IProduct>>(`${environment.apiUrl}/products?pageSize=10&typeId=1`).subscribe({
      next: (result:IPagination<IProduct>) => { this.products = result.data },
      error: (err) => console.log(err),
    })

    this.http.get<IPagination<IBombilla>>(`${environment.apiUrl}/products/bombilla`).subscribe({
      next: (result:IPagination<IBombilla>) => { this.bombillas = result.data },
      error: (err) => console.log(err),
    })
  }
}
