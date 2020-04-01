import React, { Component } from 'react'
import Navbar from 'react-bootstrap/Navbar'

export default class NavB extends Component {
  render() {
    return (
      <div>
        <Navbar bg="dark" variant="dark" fixed="top" className="justify-content-md-center">
          <Navbar.Brand>     
            Simple Configurator
          </Navbar.Brand>
        </Navbar>
      </div>
    )
  }
}

