import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MatAnchor } from "@angular/material/button";

@Component({
  selector: 'app-home',
  imports: [RouterLink, MatAnchor],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home {}
