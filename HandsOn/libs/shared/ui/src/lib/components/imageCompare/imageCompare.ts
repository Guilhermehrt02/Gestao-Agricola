import { Component, model, Input, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ImageCompareModule } from 'primeng/imagecompare';
@Component({
  selector: 'lib-image-compare',
  imports: [CommonModule, ImageCompareModule],
  templateUrl: './imageCompare.html',
  styleUrl: './imageCompare.css',
})
export class ImageCompare implements OnChanges {
  @Input() originalImageUrl = '';
  @Input() diseaseImageUrl = '';

  images: { itemImageSrc: string; title: string; alt: string }[] = [];

  ngOnInit(): void {
    // chama no início também, para renderizar a primeira imagem
    this.updateImages();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['diseaseImageUrl'] || changes['originalImageUrl']) {
      this.updateImages();
    }
  }

  updateImages(): void {
    this.images = [
      {
        itemImageSrc: this.originalImageUrl,
        title: 'Imagem enviada',
        alt: 'Imagem enviada pelo usuário',
      },
      {
        itemImageSrc: this.diseaseImageUrl,
        title: 'Imagem de referência',
        alt: 'Imagem de referência da doença',
      },
    ];
  }
}