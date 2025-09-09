import { CommonModule } from '@angular/common';
import { Component, OnInit, model } from '@angular/core';
import { GalleriaModule } from 'primeng/galleria';

@Component({
  selector: 'lib-gallery',
  imports: [CommonModule, GalleriaModule],
  templateUrl: './gallery.html',
  styleUrls: ['./gallery.css'],
  standalone: true,
})
export class Gallery implements OnInit {
  images = model<any[]>([]);

  responsiveOptions = [
    { breakpoint: '991px', numVisible: 4 },
    { breakpoint: '767px', numVisible: 3 },
    { breakpoint: '575px', numVisible: 1 },
  ];

  ngOnInit() {
    this.images.set([
      {
        itemImageSrc: 'images/user_image_396.jpg',
        thumbnailImageSrc: 'images/user_image_396.jpg',
        alt: 'Descrição 1',
        title: 'Imagem 1',
      },
      {
        itemImageSrc: 'images/acaro_leprose (2).jpg',
        thumbnailImageSrc: 'images/acaro_leprose (2).jpg',
        alt: 'Descrição 2',
        title: 'Imagem 2',
      },
      {
        itemImageSrc: 'images/acaro_leprose_01.jpg',
        thumbnailImageSrc: 'images/acaro_leprose_01.jpg',
        alt: 'Descrição 2',
        title: 'Imagem 2',
      },
    ]);
  }
}