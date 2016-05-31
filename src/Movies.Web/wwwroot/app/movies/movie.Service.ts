import {Injectable} from "@angular/core"
import {Http} from "@angular/http"
import {Observable} from "rxjs/Rx"

@Injectable()
export class MovieService
{
    constructor(private _httpService: Http) { }

    public GetMovieData(take: number)
    {
        var res = this._httpService.get(`/api/movies/GetMovieData?take=${take}`)
            .map(res => <any[]>(res.json()));
        return res;
    }
}