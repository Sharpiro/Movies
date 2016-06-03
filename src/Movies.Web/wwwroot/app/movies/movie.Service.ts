import {Injectable} from "@angular/core"
import {Http, RequestOptions, Headers} from "@angular/http"
import {Observable} from "rxjs/Rx"

@Injectable()
export class MovieService
{
    constructor(private _httpService: Http) { }

    public GetMovieData(take: number): Observable<IMovie[]>
    {
        var res = this._httpService.get(`/api/movies/GetMovieData?take=${take}`)
            .map(res => <IMovie[]>(res.json()));
        return res;
    }

    public GetMoviesByQuery(query: string): Observable<IMovie[]>
    {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        var res = this._httpService.post("/api/movies/GetMoviesByQuery", query, options)
            .map(res => <IMovie[]>(res.json()));
        return res;
    }
}