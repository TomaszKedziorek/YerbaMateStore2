import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { IImage } from '../../models/IImage';

@Component({
  selector: 'app-carusel',
  templateUrl: './carusel.component.html',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['./carusel.component.scss']
})
export class CaruselComponent implements OnInit {


  @Input() slides!: IImage[];
  public slideConfig = {
    infinite: true,
    vertical: false,
    autoplay: true,
    autoplaySpeed: 5000,
    slidesToShow: 3,
    slidesToScroll:3,
    dots: true,
    arrow:true,
    responsive: [
      {
        breakpoint: 1200,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
          infinite: true,
          dots: true,
          arrows: true
        }
      },
      {
        breakpoint: 900,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
          vertical: false,
          dots: true,
          arrows: true
        }
      }
    ]
  };

  ngOnInit(): void {}

  onImageClick(pictureUrl: string) {
    document.getElementById('product-detail')?.setAttribute('src', pictureUrl);
  }

}
