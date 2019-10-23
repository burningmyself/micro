import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'lib-base',
  template: `
    <p>
      base works!
    </p>
  `,
  styles: []
})
export class BaseComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
