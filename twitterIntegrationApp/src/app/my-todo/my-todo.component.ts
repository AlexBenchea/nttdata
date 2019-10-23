import { Component, OnInit, ViewEncapsulation, ElementRef } from "@angular/core";
import { HttpClient } from '@angular/common/http';
@Component({
    selector: "app-my-todo",
    templateUrl: "./my-todo.component.html",
    styleUrls: ["./my-todo.component.scss"],
    encapsulation: ViewEncapsulation.Native
})
export class MyTodoComponent implements OnInit {
    myTodos: string[] = [];
    name: string = "";
    private REST_API_SERVER = "https://localhost/api/twitter/";
    constructor(private httpClient: HttpClient) {
        this.getPosts();
    }
    
    ngOnInit() {
    }

    getPosts(name: string = '') {
        this.httpClient.get(this.REST_API_SERVER + name).subscribe((data: string[]) => {
            this.myTodos = data;
        });
    }
}