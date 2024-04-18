import { Component, ElementRef, Input, OnInit, ViewChild, WritableSignal, computed, inject } from '@angular/core';
import { MainModalComponent } from '../main-modal/main-modal.component';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { JsonPipe } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-modal',
  standalone: true,
  imports: [MainModalComponent, ReactiveFormsModule, JsonPipe],
  templateUrl: './search-modal.component.html',
  styleUrl: './search-modal.component.css'
})
export class SearchModalComponent implements OnInit {

  @ViewChild("inputSearch", { static: true }) inputSearch!: ElementRef

  @Input({ alias: "showModal", required: true }) showModal!: WritableSignal<boolean>;

  private _formBuilder = inject(FormBuilder)

  private router = inject(Router)

  formSearch: FormGroup = new FormGroup({})

  // focusInput = computed(() => {
  // let inputNative = this.inputSearch.nativeElement as HTMLInputElement
  // console.log(inputNative)
  // this.showModal()
  // })

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

  searchFood() {
    if (this.query.value.trim()) {
      this.router.navigate(['/search'], { queryParams: { q: this.query.value } })
      this.showModal.set(false)
    }
  }
}
