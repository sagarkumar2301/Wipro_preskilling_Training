import { Component } from '@angular/core';
import { CourseList } from './course-list/course-list';
import { CourseDetail } from './course-detail/course-detail';

@Component({
  selector: 'app-root',
  imports: [CourseList, CourseDetail],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  courses = [
    {
      id: 1,
      title: 'Advance Angular ',
      instructor: 'John'
    },
    {
      id: 2,
      title: 'Advanced C# Programming',
      instructor: 'David'
    },
    {
      id: 3,
      title: 'Advance .NET Core',
      instructor: 'Smith'
    }
  ];

  selectedCourse = this.courses[0];

  selectCourse(course: any) {
    this.selectedCourse = course;
  }
}