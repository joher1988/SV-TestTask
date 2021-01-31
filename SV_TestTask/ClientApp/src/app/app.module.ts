import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatTableModule, MatProgressSpinnerModule, MatInputModule, MatTooltipModule } from "@angular/material"
import { BuildingDetailsComponent } from "./home/building-details/building-details.component";
import { LockDetailsComponent } from "./home/lock-details/lock-details.component";
import { GroupDetailsComponent } from "./home/group-details/group-details.component";
import { MediumDetailsComponent } from "./home/medium-details/medium-details.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    BuildingDetailsComponent,
    LockDetailsComponent,
    GroupDetailsComponent,
    MediumDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
    ]),
    BrowserAnimationsModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatTooltipModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
