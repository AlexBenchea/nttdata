import { __decorate, __metadata } from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injector } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { createCustomElement } from '@angular/elements';
import { AppComponent } from 'src/app/app.component';
import { MyTodoComponent } from './my-todo/my-todo.component';
import { HttpClientModule } from '@angular/common/http';
let AppModule = class AppModule {
    constructor(injector) {
        this.injector = injector;
    }
    ngDoBootstrap() {
        const MyTodoElement = createCustomElement(MyTodoComponent, {
            injector: this.injector
        });
        customElements.define("mytodo-element", MyTodoElement);
    }
};
AppModule = __decorate([
    NgModule({
        declarations: [
            AppComponent,
            MyTodoComponent,
        ],
        imports: [
            BrowserModule,
            FormsModule,
            HttpClientModule
        ],
        entryComponents: [MyTodoComponent]
    }),
    __metadata("design:paramtypes", [Injector])
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map