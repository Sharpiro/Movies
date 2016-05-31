import { bootstrap } from '@angular/platform-browser-dynamic';
import {provide} from "@angular/core";
import {APP_BASE_HREF, LocationStrategy, HashLocationStrategy, PathLocationStrategy} from "@angular/common";
import { AppComponent } from "./app.component";
import {ROUTER_PROVIDERS} from "@angular/router-deprecated";
import "rxjs/Rx"

bootstrap(AppComponent, [
    ROUTER_PROVIDERS,
    provide(APP_BASE_HREF, { useValue: "/" }),
    provide(LocationStrategy, { useClass: HashLocationStrategy })]);