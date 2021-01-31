import { Injectable, Inject } from "@angular/core";
import { SVEntity } from "../home/Models/SVEntity";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class SVEntitiesService {

  loadData(filter: string,): Observable<SearchResultEntity[]> {
    return this.http.get<SearchResultEntity[]>(this.baseUrl + "Search/",
      {
        params: new HttpParams()
          .set("searchString", filter)
      });
  }

  constructor(private http: HttpClient, @Inject("BASE_URL") private baseUrl: string) {}

}

export interface SearchResultEntity {
  type: string;
  entity: SVEntity;
}
