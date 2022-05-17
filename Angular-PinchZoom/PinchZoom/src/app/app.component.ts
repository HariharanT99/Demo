import { Component } from '@angular/core';
import { NgxPopperjsPlacements, NgxPopperjsTriggers } from 'ngx-popperjs';
import { pdfDefaultOptions } from 'ngx-extended-pdf-viewer';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'PinchZoom';

  constructor(){
    pdfDefaultOptions.assetsFolder = 'bleeding-edge';
  }

  popClick = NgxPopperjsTriggers.click;
  popPlacement = NgxPopperjsPlacements.BOTTOMSTART;
}
