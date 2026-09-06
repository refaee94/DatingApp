import { Component, inject, signal } from '@angular/core';
import { Nav } from "../layout/nav/nav";
import { User } from '../types/user';
import { Router, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [Nav, RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App   {

  protected title = 'Dating app';
  protected members = signal<User[]>([])
  protected router = inject(Router);

 




}