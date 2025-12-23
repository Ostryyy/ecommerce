import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { SnackbarService } from '../services/snackbar.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  const snackbar = inject(SnackbarService);

  return next(req).pipe(
    catchError((err: HttpErrorResponse) => {
      if (err.status !== 404 && err.status !== 500) {
        snackbar.error(err.message || err.error);
      }
      if (err.status === 404) {
        router.navigateByUrl('/not-found');
      } else if (err.status === 500) {
        const navigationExtras: NavigationExtras = {
          state: { error: err.error },
        };
        router.navigateByUrl('/server-error', navigationExtras);
      }

      return throwError(() => err);
    })
  );
};
