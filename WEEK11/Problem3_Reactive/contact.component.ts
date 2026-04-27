
import { FormBuilder, Validators } from '@angular/forms';

export class ContactComponent {
  constructor(private fb: FormBuilder) {}

  form = this.fb.group({
    name: ['', Validators.required],
    email: ['', Validators.email],
    phone: ['', Validators.minLength(10)]
  });
}
