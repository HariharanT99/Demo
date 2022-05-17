import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgxExtendedPdfViewerModule } from 'ngx-extended-pdf-viewer';
import { PinchZoomModule } from 'ngx-pinch-zoom';
import { NgxPopperjsModule } from 'ngx-popperjs';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    PinchZoomModule,
    NgxPopperjsModule,
    NgxExtendedPdfViewerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
