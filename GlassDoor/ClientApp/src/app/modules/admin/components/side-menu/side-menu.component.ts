import { Component, OnInit, OnDestroy, ViewChild, ElementRef, Renderer2 } from '@angular/core';
import { Observable, Subscription, fromEvent, of, merge } from "rxjs";
import { map, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent implements OnInit, OnDestroy {
  public isCollapsed = false;
  public canCollapse: boolean = false;
  initial$: Observable<boolean>;
  resize$: Observable<boolean>;
  menuClosable$: Observable<boolean | Event>;
  sub: Subscription;

  @ViewChild('menu') menu: ElementRef;
  @ViewChild('toggleButton') toggleButton: ElementRef;

  constructor(private renderer: Renderer2) {
  }

  ngOnInit(): void {
    this.initial$ = of(window.innerWidth > 599 ? false : true);
    this.resize$ = fromEvent(window, 'resize').pipe(map((event: any) => {
      return event.target.innerWidth > 1200 ? false : true;
    }));

    this.menuClosable$ = merge(this.resize$, this.initial$).pipe(distinctUntilChanged());

    this.sub = this.menuClosable$.subscribe((event) => { this.isCollapsed = (event === true); this.canCollapse = (event === true) });

    this.renderer.listen('window', 'click', (e: Event) => {
      if (e.target != this.toggleButton.nativeElement && e.target != this.menu.nativeElement) {
        if (this.canCollapse) {
          this.isCollapsed = true;
        }
      }
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
