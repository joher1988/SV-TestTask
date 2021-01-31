import { DataSource } from "@angular/cdk/table";
import { BehaviorSubject, Observable, of } from "rxjs";
import { SVEntity } from "../Models/SVEntity";
import { CollectionViewer } from "@angular/cdk/collections";
import { catchError, finalize } from "rxjs/operators"
import { SVEntitiesService, SearchResultEntity } from "../../services/SVEntities.service";
import { SVEntityType } from "../Models/SVEntityType.enum";

export class SVEntitiesDataSource implements DataSource<SVEntity> {
  connect(collectionViewer: CollectionViewer): Observable<SVEntity[]> {
    return this.dataSourceSubject.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
    this.dataSourceSubject.complete();
    this.loadingSubject.complete();
  }

  private dataSourceSubject = new BehaviorSubject<SVEntity[]>(new Array<SVEntity>());
  private loadingSubject = new BehaviorSubject<boolean>(false);

  loading$ = this.loadingSubject.asObservable();

  constructor(private entitiesService: SVEntitiesService) {}

  load(filter =""): void {

    this.loadingSubject.next(true);
    this.entitiesService.loadData(filter).pipe(
      catchError(() => of(new Array<SearchResultEntity>())),
      finalize(() => this.loadingSubject.next(false))
    ).subscribe(entities => {
      const result = entities.map((entity) => {
        switch (entity.type) {
        case "Building":
          entity.entity.entityType = SVEntityType.Building;
          break;
        case "Lock":
          entity.entity.entityType = SVEntityType.Lock;
          break;
        case "Group":
          entity.entity.entityType = SVEntityType.Group;
          break;
        case "Medium":
          entity.entity.entityType = SVEntityType.Medium;
          break;
        default:
          break;
        }
        return entity.entity;
      });
      this.dataSourceSubject.next(result);
    });

  }
}
