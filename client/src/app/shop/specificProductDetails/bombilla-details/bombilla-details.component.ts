import { Component, Input } from '@angular/core';
import { IBombilla } from 'src/app/shared/models/IBombilla';

@Component({
  selector: 'app-bombilla-details',
  templateUrl: './bombilla-details.component.html',
  styleUrls: ['./bombilla-details.component.scss']
})
export class BombillaDetailsComponent {
  @Input() product!: IBombilla;
}
