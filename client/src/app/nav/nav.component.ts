import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model:any={}
  /*loggedIn:boolean | undefined;*/
  
  /* kada se implementira async  pipe  linija 16 je nepotrebna jer se podaci nalaze u liniji 23*/
  /*currentUser$ : Observable<User | null>;*/ /* treba dodati u tsconfig.json liniju '"strictPropertyInitialization": false"'*/ 
   constructor(public accountService:AccountService) { }

  ngOnInit(): void
  
  {
  /*this.getCurrentUser();*/
 /* this.currentUser$=this.accountService.currentUser$;*/
  }
login(){

/*console.log(this.model);*/
/*this.accountService.login(this.model).subscribe({next:response=>
  {
    {console.log(response),
    this.loggedIn=true}
  }, error: (error: User) => {console.log(error)}

})*/

this.accountService.login(this.model).subscribe({
  
  next:response => {console.log(response)},
   
  error: error => {console.log(error)}

})


}




logout()
{
  this.accountService.logout();
 /* this.loggedIn=false;*/

}
 
/*getCurrentUser(){}*/

 /* {next: {user-> ... }, error: {error-> ... }}*/

/*this.accountService.currentUser$.subscribe(user=>{this.loggedIn=!!user},
  
  error=>{console.log(error);}
  
)*/
/* this.accountService.currentUser$.subscribe({next:{user=>this.loggedIn=!!user},
  
  error:{error=>{console.log(error)}};}
  
 )*/
 /*this.accountService.currentUser$.subscribe({
  next: user=>{this.loggedIn=!!user},
  error: error => {console.log(error)}
    })*/


 }





