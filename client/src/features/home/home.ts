import { Component, input, Input, signal } from '@angular/core';
import { User } from '../../types/user';
import { Register } from '../account/register/register';
import { required } from '@angular/forms/signals';

@Component({
  selector: 'app-home',
  imports: [Register],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {
  protected registerMode = signal(false);

  showRegister(value: boolean) {
    this.registerMode.set(value);
  }
}