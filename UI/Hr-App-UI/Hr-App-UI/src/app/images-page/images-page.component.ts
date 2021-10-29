import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Image } from '../models/image';
import { ImagesServiceService } from '../services/images-service.service';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-images-page',
  templateUrl: './images-page.component.html',
  styleUrls: ['./images-page.component.css']
})
export class ImagesPageComponent implements OnInit {
  public currentImage:Image;
  public currentId:number=0;
  public base64Image: SafeUrl;

  constructor(private imageService: ImagesServiceService,private domSanitizer: DomSanitizer ) { }

  ngOnInit(): void {
    this.currentImage= {id:0,imageData:" ",imageTitle:" " };
  }
  public loadImage() {
    this.imageService.getImageById(this.currentId).subscribe((image) => {
      this.currentImage = image,
      this.base64Image =this.domSanitizer.bypassSecurityTrustUrl('data:image/png;base64,'+this.currentImage.imageData);
    })
  }

}
