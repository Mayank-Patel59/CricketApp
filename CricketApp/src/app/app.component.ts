import { Component } from '@angular/core';
import {CricketService} from './cricket.service'
import  {TblTeamName} from '../Models/TblTeamName.model'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {

  countries: TblTeamName[] = [];
  FilterCountries: TblTeamName[] = [];
  countriesArray= [];
  _listFilter = '';
  CountryHeaderList = [
    { DisplayName: 'Countries', BindingValue: 'team_Name' }
  ];

  get listFilter(): string {
    return this._listFilter;
  }

  set listFilter(value: string) {
    this._listFilter = value;
    this.FilterCountries = this.listFilter ? this.doFilter(this.listFilter) : this.countries;
  }

  constructor(private cricketService:CricketService){
    this.FilterCountries = this.countries;
    this.listFilter = '';
  }

  ngOnInit() {
    this.GetCountries();
  }

  doFilter(filterBy: string): TblTeamName[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.countries.filter((cm: TblTeamName) =>
    (cm.team_Name.toLocaleLowerCase().indexOf(filterBy) !== -1));
  }

  GetCountries() {
    this.cricketService.GetCountries().subscribe((result: TblTeamName[]) => {
      this.countries = result;
      console.log('hello',this.countries[0]);
      this.FilterCountries = result;
      this.countriesArray = [];
      this.countries.forEach((country: any) => {
        const count: any={
          team_ID: country.team_ID,
          team_Name: country.team_Name,
          matches: country.matches
        };
        this.countriesArray.push(count);
      });
    });
  }

  displayedColumns: string[] = ['Country', 'Matches Played'];
  dataSource = this.countries;

}
