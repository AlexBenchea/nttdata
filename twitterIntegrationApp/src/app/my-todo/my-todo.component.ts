import { Component, OnInit,ViewEncapsulation } from "@angular/core";
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
@Component({
    selector: "app-my-todo",
    templateUrl: "./my-todo.component.html",
    styleUrls: ["./my-todo.component.scss"],
    encapsulation: ViewEncapsulation.Native
})
export class MyTodoComponent implements OnInit {
    myTodos: string[] = [];
    newTodo: string;
    private REST_API_SERVER = "https://localhost:44314/api/values";
    constructor(private httpClient: HttpClient) {
         this.httpClient.get(this.REST_API_SERVER).subscribe((data: string[]) => {
            this.myTodos = data;
        })  ;
    }

    ngOnInit() {
    }
}