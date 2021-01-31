import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { SVEntitiesService } from "../services/SVEntities.service";
import { SVEntitiesDataSource } from "./DataSource/SVEntitiesDataSource";
import { SVEntity } from "./Models/SVEntity";
import { trigger, state, transition, style, animate } from "@angular/animations";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
  animations: [
    trigger("detailExpand",
      [
        state("collapsed", style({ height: "0px", minHeight: "0", display: "none" })),
        state("expanded", style({ height: "*" })),
        transition("expanded <=> collapsed", animate("225ms cubic-bezier(0.4, 0.0, 0.2, 1)")),
      ]),
  ],
})
export class HomeComponent implements OnInit {
  displayedColumns = ["type", "name", "description"];

  @ViewChild("SearchInput", { static: false })
  input: ElementRef;

  dataSource: SVEntitiesDataSource;
  selectedEntity: SVEntity;

  constructor(private entitiesService: SVEntitiesService) {
  }

  ngOnInit(): void {
    this.dataSource = new SVEntitiesDataSource(this.entitiesService);
    this.dataSource.load("");
  }

  loadData() {
    this.dataSource.load(this.input.nativeElement.value);
  }
}
