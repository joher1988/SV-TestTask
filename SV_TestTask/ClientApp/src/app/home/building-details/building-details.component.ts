import { Component, OnInit, Input } from "@angular/core";
import { SVEntity } from "../Models/SVEntity";

@Component({
  selector: "app-building-details",
  templateUrl: "./building-details.component.html"
})
export class BuildingDetailsComponent implements OnInit {

  @Input()
  entity: SVEntity;

  constructor() {}

  ngOnInit() {
  }

}
