import { Component,  OnInit } from '@angular/core';
import { StatsCovid } from 'src/app/core/stats';
import { StatService } from '../../services/stats.service';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.scss']
})
export class StatsComponent implements OnInit {
  
  stats: StatsCovid = new StatsCovid();

  constructor(private statService:StatService) { }

  ngOnInit() {
    this.statService.getStats().subscribe(item=>{
      this.stats = item;
    });
  }

}
