import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Image } from '../models/image';
import { ImagesServiceService } from '../services/images-service.service';


@Component({
  selector: 'app-images-page',
  templateUrl: './images-page.component.html',
  styleUrls: ['./images-page.component.css']
})
export class ImagesPageComponent implements OnInit {
  public currentImage:Image;
  public currentId:number=0;

  constructor(private imageService: ImagesServiceService) { }

  ngOnInit(): void {
    this.currentImage= {id:0,imageData:" ",imageTitle:" " };
  }
  public loadImage() {
    this.imageService.getImageById(this.currentId).subscribe((image) => {
      this.currentImage = image
    })
  }

}
