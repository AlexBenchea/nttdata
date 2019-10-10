import { BrowserModule } from '@angular/platform-browser';
import { NgModule,Injector } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { createCustomElement } from '@angular/elements';
import { AppComponent } from 'src/app/app.component';
import { MyTodoComponent } from './my-todo/my-todo.component';
import { HttpClientModule } from '@angular/common/http'; 
@NgModule({
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
})

export class AppModule {
    constructor(private injector: Injector){}


    ngDoBootstrap() {
        const MyTodoElement = createCustomElement(MyTodoComponent, {
            injector: this.injector
        });
        customElements.define("mytodo-element", MyTodoElement)
    }

}
