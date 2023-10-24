import { Component, Input } from '@angular/core';
import { ICup } from 'src/app/shared/models/ICup';

@Component({
  selector: 'app-cup-details',
  templateUrl: './cup-details.component.html',
  styleUrls: ['./cup-details.component.scss']
})
export class CupDetailsComponent {
  @Input() product!: ICup;
}
