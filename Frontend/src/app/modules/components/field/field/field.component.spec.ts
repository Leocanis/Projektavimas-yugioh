import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { IField } from '../../../../shared/models/field';
import { FieldComponent } from './field.component';

Component({
  selector: 'app-field',
  templateUrl: './field.component.html',
})
export class HealthComponent implements OnInit {

  @Input() field: IField;

  ngOnInit(): void {
  }
}