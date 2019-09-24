import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material";
import { RegisterModalComponent } from "../register-modal/register-modal.component";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.css"]
})
export class HeaderComponent implements OnInit {
  constructor(public dialog: MatDialog) {}

  ngOnInit() {}

  onClick() {
    alert("WOW");
  }

  register() {
    console.log("sdssdsad");
    this.dialog.open(RegisterModalComponent, {
      height: "400px",
      width: "400px"
    });
  }
}
