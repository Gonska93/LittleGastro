import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material";

@Component({
  selector: "app-register-modal",
  templateUrl: "./register-modal.component.html",
  styleUrls: ["./register-modal.component.css"]
})
export class RegisterModalComponent implements OnInit {
  constructor(public dialog: MatDialog) {}

  ngOnInit() {}

  getErrorMessage() {
    console.log("ERROR");
  }
}
