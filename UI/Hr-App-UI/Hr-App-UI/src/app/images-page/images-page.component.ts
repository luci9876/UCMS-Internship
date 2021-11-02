import { Component, OnInit } from '@angular/core';
import { Image } from '../models/image';
import { ImagesServiceService } from '../services/images-service.service';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';


@Component({
  selector: 'app-images-page',
  templateUrl: './images-page.component.html',
  styleUrls: ['./images-page.component.css']
})
export class ImagesPageComponent implements OnInit {
  public currentImage:Image;
  public currentId:number=0;
  public base64Image: SafeUrl;
  private selectedFile: File
  private baseUrl: string = `${environment.apiUrl}Image`;
  public fileName:string;



  constructor(private imageService: ImagesServiceService,private domSanitizer: DomSanitizer,private http: HttpClient ) {
    this.fileName="No Input Chosen";
   }

  ngOnInit(): void {
    this.currentImage= {id:0,imageData:" ",imageTitle:" " };
  }
  public loadImage() {
    this.imageService.getImageById(this.currentId).subscribe((image) => {
      this.currentImage = image,
      this.base64Image =this.domSanitizer.bypassSecurityTrustUrl('data:image/png;base64,'+this.currentImage.imageData);
    })
  }
  onFileChanged(event) {
    this.selectedFile = event.target.files[0];
    this.fileName=this.selectedFile.name;
  }
  onUpload() {
    var index = this.fileName.lastIndexOf('.');
    var currentExtension = this.fileName.substring(index + 1).trim();
    let allExtensions: Array<string> = ["png", "jpg", "jpeg", "gif", "tiff", "bpg"];
    var exists:boolean=false;
    for(let element of allExtensions)
    {
      if(currentExtension===element)
       {
         exists=true;
        break;}
    }
    if(exists)
    {
    const uploadFile = new FormData();
    uploadFile.append('myFile', this.selectedFile, this.selectedFile.name);
    this.http.post(this.baseUrl,uploadFile,)
      .subscribe(res=>{
        console.log(res);
      });
    }
      else
      {
       alert("This file is not an image!");
      }
  }
}


