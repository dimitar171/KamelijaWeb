import { Component } from "@angular/core";

@Component({
    selector:"product-list",
    templateUrl:"productListView.component.html"
})
export default class ProductListView {
    public products = [{
        title: "Van gogh mugh",
        price: "100"
    }, {
        title: "Van gogh poster",
        price: "200"
    }];
}