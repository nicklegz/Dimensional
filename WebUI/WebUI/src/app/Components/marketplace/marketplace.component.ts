
import { FlatTreeControl } from '@angular/cdk/tree';
import { Component, ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';

interface FoodNode {
  name: string;
  children?: FoodNode[];
}

const TREE_DATA: FoodNode[] = [
  {
    name: 'Categories',
    children: [
      {name: 'Services'},
      {name: 'Products'}
    ]
  }, {
    name: 'Location',
    children: [
      {name: 'Ottawa'},
      {name: 'Montreal'}
    ]
  },
  {
    name: 'Materials',
    children: [
      {name: 'ABS'},
      {name: 'Flexible'},
      {name: 'PLA'},
      {name: 'HIPS'},
      {name: 'PETG'},
      {name: 'Nylon'},
      {name: 'Carbon Fiber Filled'},
      {name: 'ASA'},
      {name: 'Polycarbonate'},
      {name: 'Polypropylene'},
      {name: 'Metal Filled'},
      {name: 'Wood Filled'},
      {name: 'PVA'}
    ]
  }
];

interface ExampleFlatNode {
  expandable: boolean;
  name: string;
  level: number;
}

export interface Service{
  service: string;
  image: string;
}

@Component({
  selector: 'app-marketplace',
  templateUrl: './marketplace.component.html',
  styleUrls: ['./marketplace.component.css']
})
export class MarketplaceComponent {

  checkboxClick(){

  }

  @ViewChild(MatMenuTrigger) trigger: MatMenuTrigger;

  someMethod() {
    this.trigger.openMenu();
  }
  isActive = false;
  numberOfReviews = "No Reviews";

  services: Service[] = [
    {service: 'Dremel', image: "/assets/Images/Maker Bot.jpg"},
    {service: 'Product', image:"/assets/Images/Dremel Printer.jpg"},
    {service: 'Consulting', image: "/assets/Images/Prusa Mini Printer.jpg"},
    {service: 'Procurement', image: "/assets/Images/Maker Bot.jpg"}
  ];

  private _transformer = (node: FoodNode, level: number) => {
    return {
      expandable: !!node.children && node.children.length > 0,
      name: node.name,
      level: level,
    };
  }

  treeControl = new FlatTreeControl<ExampleFlatNode>(
      node => node.level, node => node.expandable);

  treeFlattener = new MatTreeFlattener(
      this._transformer, node => node.level, node => node.expandable, node => node.children);

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  constructor() {
    this.dataSource.data = TREE_DATA;
  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;
}


