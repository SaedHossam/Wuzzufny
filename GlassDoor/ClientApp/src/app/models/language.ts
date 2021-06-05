import { UserLanguage } from "./user-language";

export class Language {

  constructor(id?: number, userLanguages?: UserLanguage, name?: string)
  {

    this.id = id;
    this.name = name;
    this.userLanguages = userLanguages;
   

  }
  public id: number;
  public name: string;
  public userLanguages: UserLanguage;


}
