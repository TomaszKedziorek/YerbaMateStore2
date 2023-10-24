import { Component, Input } from '@angular/core';
import { IYerbaMate } from 'src/app/shared/models/IYerbaMate';

@Component({
  selector: 'app-yerba-mate-details',
  templateUrl: './yerba-mate-details.component.html',
  styleUrls: ['./yerba-mate-details.component.scss']
})
export class YerbaMateDetailsComponent {

  @Input() product!: IYerbaMate;
}
