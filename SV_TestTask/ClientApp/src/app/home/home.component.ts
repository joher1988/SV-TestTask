import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { SVEntitiesService } from '../services/SVEntities.service';
import { DataSource } from '@angular/cdk/table';
import { SVEntitiesDataSource } from './DataSource/SVEntitiesDataSource';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public displayedColumns = ["type", "name", "description"];

  @ViewChild('SearchInput',{static:false}) input: ElementRef;

  dataSource: SVEntitiesDataSource;

  constructor(private entitiesService:SVEntitiesService) {
  }

  ngOnInit(): void {
    this.dataSource = new SVEntitiesDataSource(this.entitiesService);
    this.dataSource.load('');
  }
  loadData(){
    this.dataSource.load(this.input.nativeElement.value);
  }
}
