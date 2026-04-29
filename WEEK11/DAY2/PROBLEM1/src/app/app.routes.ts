import { Routes } from '@angular/router';

import { ContactListComponent } from './components/contact-list/contact-list';
import { AddContactComponent } from './components/add-contact/add-contact';
import { ContactDetailComponent } from './components/contact-detail/contact-detail';

export const routes: Routes = [
  { path: '', redirectTo: 'contacts', pathMatch: 'full' },
  { path: 'contacts', component: ContactListComponent },
  { path: 'add-contact', component: AddContactComponent },
  { path: 'contact/:id', component: ContactDetailComponent }
];