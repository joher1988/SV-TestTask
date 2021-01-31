import { Component, OnInit, Input } from "@angular/core";
import { SVEntity } from "../Models/SVEntity";

@Component({
  selector: "app-medium-details",
  templateUrl: "./medium-details.component.html"
})
export class MediumDetailsComponent implements OnInit {

  @Input()
  entity: SVEntity;

  constructor() {}

  ngOnInit() {
  }

}
