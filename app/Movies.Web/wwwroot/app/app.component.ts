import {Component} from "@angular/core";
import {RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS} from "@angular/router-deprecated"
import {MovieListComponent, MovieService} from "./movies/movies"
import {HTTP_PROVIDERS} from "@angular/http"

@Component({
    selector: "my-app",
    templateUrl: "./app/app.component.html",
    directives: [ROUTER_DIRECTIVES],
    providers: [HTTP_PROVIDERS, MovieService]
})
@RouteConfig([
    { path: "/movies", name: "Movies", component: MovieListComponent, useAsDefault: true }
])
export class AppComponent
{

}