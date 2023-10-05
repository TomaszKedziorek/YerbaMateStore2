import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public title: string = 'Yerba Mate Sotre 2.0';

  public constructor() {

  }

  public ngOnInit(): void {
  }
}
