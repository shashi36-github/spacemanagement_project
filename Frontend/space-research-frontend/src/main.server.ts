import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { config } from "../src/app/app.config.server"; // Corrected relative path

const bootstrap = () => bootstrapApplication(AppComponent, config);

export default bootstrap;
