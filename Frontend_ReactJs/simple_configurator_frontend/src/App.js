import './App.css';
import React, { Component } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import './App.css';
import NavB from './Components/Navbar.jsx';
import Footer from './Components/Footer.jsx';
import Default from './Components/Default';
import MainPage from './Components/MainPage';
import FeatureModel from './Components/FeatureModel.jsx';
import Lift from './Components/Lift.jsx';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';

function App() {
  return (
    <div className="App">
      <header className="App-header">
      </header>
      <React.Fragment>

        <Container fluid={true} style={{ paddingLeft: 0, paddingRight: 0 }}>
          <NavB />
        </Container>

        <Container className="h-50" fluid={true} style={{ paddingLeft: '10%', paddingRight: 0, marginTop: '10%' }}>
          <Row>
            <BrowserRouter>
              <Switch>
                <Route exact path="/" component={MainPage} />
                <Route path="/Lift" component={Lift} />
                <Route component={Default} />
              </Switch>
            </BrowserRouter>
          </Row>
        </Container>

        <Container fluid={true} style={{ paddingLeft: 0, paddingRight: 0 }}>
          <BrowserRouter>
            <Footer />
          </BrowserRouter>
        </Container>

      </React.Fragment>
    </div>
  );
}

export default App;
