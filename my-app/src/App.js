import logo from './logo.svg';
import './App.css';

import {Navigation} from './Navigation';
import {Caesar} from './InformationSecurity/Caesar';
import {Vigener} from './InformationSecurity/Vigener';
import { Gamming } from './InformationSecurity/Gamming';
import { Task4 } from './InformationSecurity/Task4';
import { Task5 } from './InformationSecurity/Task5';
import {RSA} from "./InformationSecurity/RSA";
import {Cryptography1} from "./cryptography/Cryptography1";
import {Cryptography2} from "./cryptography/Cryptography2";
import {Cryptography3} from "./cryptography/Cryptography3";
import {Cryptography4} from "./cryptography/Cryptography4";
import {Cryptography5} from "./cryptography/Cryptography5";

import {BrowserRouter, Route, Switch} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
      <div className="container">
        <h3 className="m-3 d-flex justify-content-center">
          Шифрование информации
        </h3>

        <Navigation/>

          <Switch>
            <Route path='/' component={Caesar} exact/>
            <Route path='/InformationSecurity/Caesar' component={Caesar}/>
            <Route path='/InformationSecurity/Vigener' component={Vigener}/>
            <Route path='/InformationSecurity/Gamming' component={Gamming}/>
            <Route path='/InformationSecurity/Task4' component={Task4}/>
            <Route path='/InformationSecurity/Task5' component={Task5}/>
            <Route path='/InformationSecurity/RSA' component={RSA}/>
            <Route path='/cryptography/Cryptography1' component={Cryptography1}/>
            <Route path='/cryptography/Cryptography2' component={Cryptography2}/>
            <Route path='/cryptography/Cryptography3' component={Cryptography3}/>
            <Route path='/cryptography/Cryptography4' component={Cryptography4}/>
            <Route path='/cryptography/Cryptography5' component={Cryptography5}/>
          </Switch>
      </div>
    </BrowserRouter>
  );
}

export default App;
