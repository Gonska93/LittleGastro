import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { MatMenuModule } from "@angular/material/menu";

import { MatCardModule } from "@angular/material/card";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatDividerModule } from "@angular/material/divider";
import { WelcomeSignComponent } from "./welcome-sign/welcome-sign.component";
import { HeaderComponent } from "./header/header.component";
import { ContentComponent } from './content/content.component';

@NgModule({
  declarations: [AppComponent, WelcomeSignComponent, HeaderComponent, ContentComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    MatCardModule,
    MatDividerModule,
    MatMenuModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
