import { Component } from '@angular/core';
import { Books } from './books/books';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Books],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
}