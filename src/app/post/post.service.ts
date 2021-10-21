import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Post } from "./post.model";
import { delay } from "rxjs/operators";

@Injectable()
export class PostService {
    private readonly API_URL: string = "http://localhost:28757/posts";

    constructor(private http: HttpClient) { }

    getPost(page: number, pageSize?: number): Observable<Post[]> {
        if (pageSize)
            return this.http.get<Post[]>(`${this.API_URL}/${page}?pageSize=${pageSize}`).pipe(delay(1000));

        return this.http.get<Post[]>(`${this.API_URL}/${page}`).pipe(delay(1000));
    }
}
