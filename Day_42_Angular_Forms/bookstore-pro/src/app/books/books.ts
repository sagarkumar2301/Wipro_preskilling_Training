import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Observable, Subscription } from 'rxjs';

import { DataService } from '../services/data';
import { BookCard } from '../book-card/book-card';

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [CommonModule, BookCard],
  templateUrl: './books.html',
  styleUrl: './books.css'
})
export class Books implements OnInit, OnDestroy {

  books: any[] = [];

  books$!: Observable<any[]>;

  subscription!: Subscription;

  constructor(private dataService: DataService) {}

  ngOnInit(): void {

    this.subscription =
      this.dataService.getBooks()
      .subscribe(data => {
        this.books = data;
      });

    this.books$ =
      this.dataService.getBooks();
  }

  ngOnDestroy(): void {

    if (this.subscription) {
      this.subscription.unsubscribe();
    }

  }
}