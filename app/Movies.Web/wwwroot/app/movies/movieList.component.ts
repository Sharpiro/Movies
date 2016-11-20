import {Component} from "@angular/core"
import {BrowserPlatformLocation} from "@angular/platform-browser"
import {MovieService} from "./movies"
import {Observable} from "rxjs/Rx"
import {RouteParams} from "@angular/router-deprecated"


@Component({
    selector: "movieList",
    templateUrl: "./app/movies/movieList.component.html",
    providers: [BrowserPlatformLocation]
})
export class MovieListComponent
{
    public movies: IMovie[];
    public query: string;
    public url: string;

    constructor(private _movieService: MovieService, private _params: RouteParams, private _location: BrowserPlatformLocation)
    {
        this.query = this.buildQuery();
    }

    public ngOnInit(): void
    {
        this._movieService.GetMoviesByQuery(this.query).subscribe(data => this.movies = data);
    }

    public submitQuery()
    {
        this._movieService.GetMoviesByQuery(this.query).subscribe(data => this.movies = data);
    }

    public stringToDateMilliseconds(dateString: string): number
    {
        var date = Date.parse(dateString);
        return date;
    }

    private buildUrl(): void
    {
        var baseUrl = this._location.location.host;
        var hash = this._location.hash;
        var queryObj = <IMovieQuery>JSON.parse(this.query);
        this.url = `${baseUrl}/${hash}?MinYear=${queryObj.MinYear}&MaxYear=${queryObj.MaxYear}&Contains=${queryObj.Contains}&OrderBy=${queryObj.OrderBy}`;
    }

    private buildQuery(): string
    {
        var defaultQueryString = '{"MinYear": "0001", "MaxYear": 2016, "Contains": "*", "OrderBy": "Rank"}'
        var queryObj = <IMovieQuery>JSON.parse(defaultQueryString);
        var minYear = parseInt(this._params.get("MinYear"));
        queryObj.MinYear = minYear ? minYear : queryObj.MinYear;
        var maxYear = parseInt(this._params.get("MaxYear"));
        queryObj.MaxYear = maxYear ? maxYear : queryObj.MaxYear;
        var contains = this._params.get("Contains");
        queryObj.Contains = contains ? contains : queryObj.Contains;
        var orderBy = this._params.get("OrderBy");
        queryObj.OrderBy = orderBy ? orderBy : queryObj.OrderBy;
        return JSON.stringify(queryObj);
    }
}