import { Component, model, Input, OnChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ImageCompareModule } from 'primeng/imagecompare';
@Component({
  selector: 'lib-image-compare',
  imports: [CommonModule, ImageCompareModule],
  templateUrl: './imageCompare.html',
  styleUrl: './imageCompare.css',
})
export class ImageCompare implements OnChanges{
  @Input() originalImageUrl = '';
  @Input() diseaseImageUrl = '';
  images : { itemImageSrc: string; title: string, alt: string }[] = [];

  ngOnChanges() {
    this.images = [
      { itemImageSrc: this.originalImageUrl, title: 'User Image', alt: 'User Image' },
      { itemImageSrc: this.diseaseImageUrl, title: 'Reference Image', alt: 'Reference Image' }
    ];
  }
}
