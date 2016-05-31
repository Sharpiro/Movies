import {Component} from "@angular/core"
import {MovieService} from "./movies"

@Component({
    selector: "movieList",
    templateUrl: "./app/movies/movieList.component.html"
})
export class MovieListComponent
{
    public movies: any[];

    constructor(private _movieService: MovieService) { }

    public ngOnInit(): void
    {
        this._movieService.GetMovieData(10).subscribe(data => this.movies = data);
    }

    public stringToDateMilliseconds(dateString: string): number
    {
        var date = Date.parse(dateString);
        return date;
    }
}