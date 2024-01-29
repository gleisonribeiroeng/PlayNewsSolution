
import { Injectable } from '@angular/core';

@Injectable()
export class SampleGuard  {
  canActivate() {
    return true;
  }
}
