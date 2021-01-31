import { Component, OnInit, Input } from "@angular/core";
import { SVEntity } from "../Models/SVEntity";

@Component({
  selector: "app-group-details",
  templateUrl: "./group-details.component.html"
})
export class GroupDetailsComponent implements OnInit {

  @Input()
  entity: SVEntity;

  constructor() {}

  ngOnInit() {
  }

}
