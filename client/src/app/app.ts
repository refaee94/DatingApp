import { Component, inject, signal } from '@angular/core';
import { Nav } from "../layout/nav/nav";
import { User } from '../types/user';
import { Router, RouterOutlet } from '@angular/router';
import { ConfirmDialog } from '../shared/confirm-dialog/confirm-dialog';

@Component({
  selector: 'app-root',
  imports: [Nav, RouterOutlet, ConfirmDialog],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App   {

  protected title = 'Dating app';
  protected router = inject(Router);

 




}