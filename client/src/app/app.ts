import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject, signal } from '@angular/core';
import { lastValueFrom } from 'rxjs';

@Component({
  imports: [],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App implements OnInit   {
 private http = inject(HttpClient);
protected  members =signal<any>([]);
  async ngOnInit() {
this.members.set(await this.fetchMembers())
  }
  protected readonly title ='Dating App';

  protected async fetchMembers() {

    try {
      return lastValueFrom(this.http.get('https://localhost:5001/api/members'));
    } catch (error) {
      console.log(error)
      throw error;
    }
  }
}
