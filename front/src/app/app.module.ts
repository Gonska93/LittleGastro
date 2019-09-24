import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { MatMenuModule } from "@angular/material/menu";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatDialogModule } from "@angular/material/dialog";
import { MatCardModule } from "@angular/material/card";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatDividerModule } from "@angular/material/divider";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import { MatFormFieldModule } from "@angular/material/form-field";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { WelcomeSignComponent } from "./welcome-sign/welcome-sign.component";
import { HeaderComponent } from "./header/header.component";
import { ContentComponent } from "./content/content.component";
import { HomeComponent } from "./home/home.component";
import { RegisterModalComponent } from "./register-modal/register-modal.component";
import { EmailInputComponent } from "./email-input/email-input.component";
import { MatInputModule } from "@angular/material";
import { PasswordInputComponent } from "./password-input/password-input.component";
import { UsernameInputComponent } from "./username-input/username-input.component";

@NgModule({
  declarations: [
    AppComponent,
    WelcomeSignComponent,
    HeaderComponent,
    ContentComponent,
    HomeComponent,
    RegisterModalComponent,
    EmailInputComponent,
    PasswordInputComponent,
    UsernameInputComponent
  ],
  entryComponents: [RegisterModalComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    MatCardModule,
    MatDividerModule,
    MatMenuModule,
    MatDialogModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
