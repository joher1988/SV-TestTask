import { Component, OnInit, Input } from "@angular/core";
import { SVEntity } from "../Models/SVEntity";

@Component({
  selector: "app-lock-details",
  templateUrl: "./lock-details.component.html"
})
export class LockDetailsComponent implements OnInit {

  @Input()
  entity: SVEntity;

  constructor() {}

  ngOnInit() {
  }

}
