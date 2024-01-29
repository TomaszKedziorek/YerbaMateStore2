import { Component } from '@angular/core';
import { NavigationExtras } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.scss']
})
export class ServerErrorComponent {

  public error: any;

  constructor(private router: Router) {
    //NavigationExtras are ony available in constructor
    const navigationExtras = this.router.getCurrentNavigation();
    if (navigationExtras && navigationExtras.extras && navigationExtras.extras.state && navigationExtras.extras.state?.['error'])
      this.error = navigationExtras.extras.state?.['error'];
  }

}
