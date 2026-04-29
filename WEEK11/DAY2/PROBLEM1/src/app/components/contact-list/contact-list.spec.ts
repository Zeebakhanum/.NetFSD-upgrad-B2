import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-list.component.html'
})
export class ContactListComponent {

  contacts: Contact[] = [
    { id: 1, name: 'John', email: 'john@gmail.com', phone: '9999999999' },
    { id: 2, name: 'Sara', email: 'sara@gmail.com', phone: '8888888888' },
    { id: 3, name: 'David', email: 'david@gmail.com', phone: '7777777777' }
  ];

  constructor(private router: Router) {}

  viewDetails(id: number) {
    this.router.navigate(['/contact', id]);
  }
}