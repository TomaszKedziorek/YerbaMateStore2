import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from './../environments/environment';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public title: string = 'Yerba Mate Sotre 2.0';

  public constructor(private http: HttpClient) {

  }

  public ngOnInit(): void {   
    this.http.get(`${environment.apiUrl}/products/`).subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    }
    )
  }
}
