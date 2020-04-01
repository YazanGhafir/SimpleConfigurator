import React, { Component } from 'react'
import Navbar from 'react-bootstrap/Navbar'

export default class Footer extends Component {
    render() {
        return (
            <div>
                 <Navbar bg="dark" variant="dark" fixed="bottom" className="justify-content-md-center">
                    < Navbar.Brand className="navbar-center">
                         Yazan Ghafir
                    </Navbar.Brand>
                </Navbar>
            </div>
        )
    }
}
