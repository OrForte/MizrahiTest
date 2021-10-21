import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';
import { Post } from './post/post.model';
import { PostService } from './post/post.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  posts: BehaviorSubject<Post[]> = new BehaviorSubject<Post[]>([]);
  isLoading: boolean = false;
  currentPage: number = 1;

  constructor(private postService: PostService) {
  }

  ngOnInit(): void {
    this.isLoading = true;
    this.postService.getPost(this.currentPage).subscribe(p => {
      this.posts.next(p);
      this.isLoading = false;
    });
  }

  onScroll() {
    this.isLoading = true;
    this.postService.getPost(this.currentPage).subscribe(p => {
      this.posts.next([... this.posts.value, ...p]);
      this.isLoading = false;
      this.currentPage++;
    });
  }
}