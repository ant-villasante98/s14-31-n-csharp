import { Component, Input, OnInit, WritableSignal, inject } from '@angular/core';
import { MainModalComponent } from '../main-modal/main-modal.component';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-search-modal',
  standalone: true,
  imports: [MainModalComponent, ReactiveFormsModule, JsonPipe],
  templateUrl: './search-modal.component.html',
  styleUrl: './search-modal.component.css'
})
export class SearchModalComponent implements OnInit {

  @Input({ alias: "showModal", required: true }) showModal!: WritableSignal<boolean>;

  private _formBuilder = inject(FormBuilder)

  formSearch: FormGroup = new FormGroup({})

  ngOnInit(): void {
    this.formSearch = this._formBuilder.group(
      {
        query: [""]
      }
    )
  }

  get query() {
    return this.formSearch.controls?.["query"]
  }
}
