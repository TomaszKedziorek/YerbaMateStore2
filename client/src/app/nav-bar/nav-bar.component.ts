import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {
  public title: string = 'Yerba Mate Sotre 2.0';
  public isLightTheme: boolean = false;

  public onThemeSwitch(): void {
    this.isLightTheme = !this.isLightTheme;
    document.body.setAttribute('data-bs-theme', this.isLightTheme ? 'light' : 'dark');
  }
}
