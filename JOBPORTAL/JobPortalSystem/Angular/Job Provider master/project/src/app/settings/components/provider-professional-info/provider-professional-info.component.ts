import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-provider-professional-info',
  templateUrl: './provider-professional-info.component.html',
  styleUrls: ['./provider-professional-info.component.css']
})
export class ProviderProfessionalInfoComponent {

  @Input() data: any;
  @Input() title: any;
  @Input() image:any;

}
