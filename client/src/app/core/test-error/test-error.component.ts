import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {

  private baseUrl: string = environment.apiUrl;
  public validationErrors!: string[];
  public invalidUrl!: string;

  public constructor(private httpClient: HttpClient) { }

  public ngOnInit(): void {
  }


  public get400Error(): void {
    this.httpClient.get(this.baseUrl + 'Buggy/badrequest').subscribe({
      next: result => {
        console.log(result);
      },
      error: error => {
        console.log(error);
      }
    })
  }

  public get400VlaidationError(): void {
    // this.httpClient.get(this.baseUrl + 'Buggy/badrequest/sixtysix/334').subscribe({
      this.httpClient.get(this.baseUrl + 'products/sixtysix').subscribe({
      next: result => {
        console.log(result);
      },
      error: error => {
        console.log(error);
        this.validationErrors = error.error.errors;
        this.invalidUrl = error.url;
      }
    })
  }

  public get404Error(): void {
    this.httpClient.get(this.baseUrl + 'Buggy/notfound').subscribe({
      next: result => {
        console.log(result);
      },
      error: error => {
        console.log(error);
      }
    })
  }

  public get500Error(): void {
    this.httpClient.get(this.baseUrl + 'Buggy/servererror').subscribe({
      next: result => {
        console.log(result);
      },
      error: error => {
        console.log(error);
      }
    })
  }
}
