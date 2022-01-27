import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

/*import { EventEmitter } from 'stream';*/ /* automatski se
 dodaje kada se upiše EventEmmiter u liniju 12. Taj ne treba!; treba dodati kroz @angular/core */ 

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
/*@Input() usersFromHomeComponent:any;*/
@Output() cancelRegister= new EventEmitter();
  model:any={};
  constructor(private accountService:AccountService) { }

  ngOnInit(): void {
  }
  register()
  {
    this.accountService.register(this.model).subscribe(response=>
      {console.log(response);
      this.cancel();
    },error=>{console.log(error);
  })
    /*console.log(this.model)*/

  }
cancel()
    {

   /* console.log("canceled")*/
   this.cancelRegister.emit(false);

    }
}
