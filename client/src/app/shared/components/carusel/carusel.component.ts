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
    autoplay: false,
    autoPlaySpeed: 2000,
    slidesToShow: 3,
    slidesToScroll: 3,
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
  public itemsPerSlide = 3;
  public singleSlideOffset = true;

  ngOnInit(): void {
    this.slides.push({ id: 11, pictureUrl: "https://apod.nasa.gov/apod/image/2310/C2023H2LemmonGalaxies.jpg" },)
    this.slides.push({ id: 12, pictureUrl: "https://apod.nasa.gov/apod/image/2310/AnnularMontagev2.jpg" },)
    this.slides.push({ id: 14, pictureUrl: "https://apod.nasa.gov/apod/image/2003/wr124_hubbleschmidt_1289.jpg" },)
    this.slides.push({ id: 15, pictureUrl: "https://apod.nasa.gov/apod/image/2003/Galassiainunagoccia.jpg" },)
    this.slides.push({ id: 16, pictureUrl: "https://apod.nasa.gov/apod/image/2003/ag-obj-52945-001-pub-large.jpg" },)
  }

  onImageClick(pictureUrl: string) {
    document.getElementById('product-detail')?.setAttribute('src', pictureUrl);
  }

}
