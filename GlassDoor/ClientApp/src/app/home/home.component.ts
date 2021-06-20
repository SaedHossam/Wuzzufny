
import { Component, OnInit } from "@angular/core";
import { AuthenticationService } from "../shared/services/authentication.service";
import { Router } from "@angular/router";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  responsiveOptions;
  carouselData;

  constructor(private _authService: AuthenticationService, private _router: Router) { }

  ngOnInit(): void {
    if (this._authService.isUserEmployee()) {
      this._router.navigate(["/employee"]);
    }
    else if (this._authService.isUserAdmin()) {
      this._router.navigate(["/admin"]);
    }
    else if (this._authService.isUserCompany()) {
      this._router.navigate(["/company"]);
    }

    this.responsiveOptions = [
      {
        breakpoint: '1024px',
        numVisible: 2,
        numScroll: 2
      },
      {
        breakpoint: '768px',
        numVisible: 1,
        numScroll: 1
      }
    ];

    this.carouselData = [
      {
        image: "../../assets/Images/gallery/user-f.png",
        text: "قولتها وهاقولها كل ما حد يسأل عن ITI هو مكان هيغير لك حياتك 180 درجة للافضل, فكرة انك بتتخرج و انت واقف ع اول طريق الصح فى كاريرك من مكان يأسسك صح وتتخرج وانت فخورانك كنت جزء من الكيان ده "
      },
      {
        image: "../../assets/Images/gallery/user-f.png",
        text: "ITI غيرنى تماما, الشخصية اللى دخلت اتغيرت فعليا للاحسن"
      },
      {
        image: "../../assets/Images/gallery/user-m.png",
        text: "من ارقى الاماكن فكريا وعلميا واجتماعيا اللى ممكن تتعلم فيها, كانت من احلى التجارب فى حياتى"
      },
      {
        image: "../../assets/Images/gallery/user-m.png",
        text: "تجربة جميلة ومفيده مش بس ف المستوى العلمى بس ف كل حاجة تقريبا اجتماعى وسلوكيات اتمنى اشترك ف اى حاجة تخص ITI"
      },
      {
        image: "../../assets/Images/gallery/user-f.png",
        text: "كل اللي فيه هدفهم حاجة واحدة بس ،، انك تطلع شخصية ناجحة وهتبقي ناجح جدا لو اجتهدت فيه"
      },
      {
        image: "../../assets/Images/gallery/user-f.png",
        text: "رغم اننا اتخرجنا لكن محسسيننا اننا دايما لينا عيلة موجوده في اي وقت نرجعلهم فيها"
      }
    ];
  }
}
