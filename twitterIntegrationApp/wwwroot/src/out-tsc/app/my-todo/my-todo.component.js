import { __decorate, __metadata } from "tslib";
import { Component, ViewEncapsulation } from "@angular/core";
import { HttpClient } from '@angular/common/http';
let MyTodoComponent = class MyTodoComponent {
    constructor(httpClient) {
        this.httpClient = httpClient;
        this.myTodos = [];
        this.userName = "";
        this.name = "";
        this.REST_API_SERVER = "https://localhost/api/twitter/";
        this.getPosts();
    }
    ngOnInit() {
    }
    getPosts(name = '') {
        this.httpClient.get(this.REST_API_SERVER + name).subscribe((data) => {
            this.myTodos = data;
        });
    }
};
MyTodoComponent = __decorate([
    Component({
        selector: "app-my-todo",
        templateUrl: "./my-todo.component.html",
        styleUrls: ["./my-todo.component.scss"],
        encapsulation: ViewEncapsulation.Native
    }),
    __metadata("design:paramtypes", [HttpClient])
], MyTodoComponent);
export { MyTodoComponent };
//# sourceMappingURL=my-todo.component.js.map