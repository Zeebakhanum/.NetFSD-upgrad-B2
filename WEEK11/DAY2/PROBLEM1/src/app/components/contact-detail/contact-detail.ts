import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-detail.html',
  styleUrl: './contact-detail.css'
})
export class ContactDetailComponent {

  contact: any;

  contacts = [
    { id: 1, name: 'John', email: 'john@gmail.com', phone: '9876543210' },
    { id: 2, name: 'Sara', email: 'sara@gmail.com', phone: '9876543211' },
    { id: 3, name: 'David', email: 'david@gmail.com', phone: '9876543212' }
  ];

  constructor(private route: ActivatedRoute) {

    let id = Number(this.route.snapshot.paramMap.get('id'));

    this.contact = this.contacts.find(x => x.id === id);

  }

}