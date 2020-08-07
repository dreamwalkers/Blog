import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BlogPostService } from '../../services/blog-post.service';
import { BlogPost } from '../../models/blogpost';

@Component({
  selector: 'app-blog-posts',
  templateUrl: './blog-posts.component.html',
  styleUrls: ['./blog-posts.component.scss']
})
export class BlogPostsComponent implements OnInit {
  blogPosts$: Observable<BlogPost[]>;
  constructor(private blogPostService: BlogPostService) { }

  ngOnInit(): void {
    this.loadBlogPosts();
  }

  // tslint:disable-next-line: typedef
  loadBlogPosts() {
    this.blogPosts$ = this.blogPostService.getBlogPosts();
  }

  // tslint:disable-next-line: typedef
  delete(postId: number) {
    const ans = confirm('Do you want to delete blog post with id: ' + postId);
    if (ans) {
      this.blogPostService.deleteBlogPost(postId).subscribe((data) => {
        this.loadBlogPosts();
      });
    }
  }

}
