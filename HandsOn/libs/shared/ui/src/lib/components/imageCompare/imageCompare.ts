import { Component, OnInit, model } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ImageCompareModule } from 'primeng/imagecompare';
@Component({
  selector: 'lib-image-compare',
  imports: [CommonModule, ImageCompareModule],
  templateUrl: './imageCompare.html',
  styleUrl: './imageCompare.css',
})
export class ImageCompare implements OnInit{
  images = model<any[]>([]);

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
