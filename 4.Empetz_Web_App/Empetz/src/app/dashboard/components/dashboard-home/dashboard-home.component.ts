import { CommonModule } from '@angular/common';
import { Component ,OnInit} from '@angular/core';

@Component({
  selector: 'app-dashboard-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard-home.component.html',
  styleUrl: './dashboard-home.component.css'
})
export class DashboardHomeComponent implements OnInit {
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  pets = [
    {
      name: 'Bella',
      description: 'A friendly and energetic dog looking for a loving home.',
      imageUrl: 'assets/img/bella.jpg'
    },
    {
      name: 'Max',
      description: 'Loyal and protective, Max is ready to be your best friend.',
      imageUrl: 'assets/img/max.jpg'
    },
    {
      name: 'Luna',
      description: 'Luna loves playing and is great with kids.',
      imageUrl: 'assets/img/luna.jpg'
    },
    {
      name: 'Charlie',
      description: 'A calm and affectionate dog who enjoys walks in the park.',
      imageUrl: 'assets/img/charlie.jpg'
    },
    {
      name: 'Rocky',
      description: 'Rocky is a fun-loving dog who enjoys playing fetch.',
      imageUrl: 'assets/img/rocky.jpg'
    },
    {
      name: 'Lucy',
      description: 'A sweet dog with a lot of love to give.',
      imageUrl: 'assets/img/lucy.jpg'
    }
  ];
}
