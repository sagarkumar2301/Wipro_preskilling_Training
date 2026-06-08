import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-course-list',
  imports: [CommonModule],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList {

  @Input() courses: any[] = [];

  @Output() courseSelected = new EventEmitter<any>();

  viewDetails(course: any) {
    this.courseSelected.emit(course);
  }
}