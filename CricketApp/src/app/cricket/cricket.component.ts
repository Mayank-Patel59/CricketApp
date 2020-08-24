import { Component, OnInit } from '@angular/core';
import {CricketService} from '../cricket.service'
import  {TblTeamName} from '../../Models/TblTeamName.model'

@Component({
  selector: 'app-cricket',
  templateUrl: './cricket.component.html',
  styles: [
  ]
})
export class CricketComponent implements OnInit {

  countries: TblTeamName[];
  FilterCountries: TblTeamName[];
  CountryHeaderList = [
    { DisplayName: 'Countries', BindingValue: 'team_Name' }
  ];
  constructor(private cricketService: CricketService) { }

  ngOnInit(): void {
    this.GetCountries();
  }

  GetCountries() {
    this.cricketService.GetCountries().subscribe((result: TblTeamName[]) => {
      this.countries = result;
      console.log('hello',this.countries);
      this.FilterCountries = result;
    });
  }

}
