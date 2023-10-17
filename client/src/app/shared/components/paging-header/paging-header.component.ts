import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.scss']
})
export class PagingHeaderComponent implements OnInit,OnChanges {

  @Input() pageNumber!: number;
  @Input() pageSize!: number;
  @Input() totalCount!: number;

  constructor(){}

  ngOnChanges(changes: SimpleChanges): void {
  }

  ngOnInit(): void {
  }
}

