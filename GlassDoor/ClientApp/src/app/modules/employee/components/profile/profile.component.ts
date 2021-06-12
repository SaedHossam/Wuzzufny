import { Component, OnInit } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { Country } from "../../../../models/country";
import { CountryService } from "../../../../shared/services/country.service";
import { City } from "../../../../models/city";
import { CityService } from "../../../../shared/services/city.service";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  active = 'General Info';
  dateOfBirth: NgbDateStruct;
  isWillingToRelocate: boolean = true;

  countries: Country[];
  cities: City[];

  constructor(private _countryService: CountryService, private _cityService: CityService) { }

  ngOnInit(): void {
    this._countryService.getCountries().subscribe(c => { this.countries = c });
    this._cityService.getCities().subscribe(c => { this.cities = c });

  }

}
