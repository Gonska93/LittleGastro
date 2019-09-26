import { Component, OnInit, HostBinding, Input } from "@angular/core";

@Component({
  selector: "app-content",
  templateUrl: "./content.component.html",
  styleUrls: ["./content.component.css"]
})
export class ContentComponent {
  constructor() {}

  @HostBinding("class.is-open")
  @Input()
  isOpen = false;
}
