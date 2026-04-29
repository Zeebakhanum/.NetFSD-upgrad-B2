import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css'
})
export class ContactListComponent {

  contacts = [
    { id: 1, name: 'John', email: 'john@gmail.com', phone: '9876543210' },
    { id: 2, name: 'Sara', email: 'sara@gmail.com', phone: '9876543211' },
    { id: 3, name: 'David', email: 'david@gmail.com', phone: '9876543212' }
  ];

  constructor(private router: Router) {}

  viewDetails(id: number) {
    this.router.navigate(['/contact', id]);
  }

}