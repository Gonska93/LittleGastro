import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-home",
  template: `
    <app-header></app-header>
    <app-content></app-content>
    <app-welcome-sign></app-welcome-sign>
  `,
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  constructor() {}

  ngOnInit() {}
}
