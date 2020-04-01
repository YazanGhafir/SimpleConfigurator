import React, { Component } from 'react'
import { MDBBtn, MDBCard, MDBCardBody, MDBCardImage, MDBCardTitle, MDBCardText, MDBRow, MDBCol, MDBIcon } from
    'mdbreact';

export default class MainPage extends Component {
    render() {
        return (
            <div>

                <MDBRow className="justify-content-center">
                    <MDBCol md="4">
                        <MDBCard cascade onClick={() =>{window.location.replace('/Lift');}}>
                            <MDBCardImage
                                cascade
                                className='img-fluid'
                                overlay="white-light"
                                hover
                                src='https://wwwcibesliftcom.cdn.triggerfish.cloud/uploads/2018/07/cabinliftcibesa6000.png'
                            />
                            <MDBBtn
                                floating
                                tag='a'
                                className='ml-auto mr-4 lighten-3 mdb-coalor'
                                action
                            >
                                <MDBIcon icon='chevron-right' className="mdb-color lighten-3" />
                            </MDBBtn>
                            <MDBCardBody cascade>
                                <MDBCardTitle>Lift</MDBCardTitle>
                                <hr />
                            </MDBCardBody>
                        </MDBCard>
                    </MDBCol>

                    <MDBCol md="4">
                        <MDBCard cascade  onClick={() => {alert("unfortunately the Elevators are out of stock right now! Please try again later.")}}>
                            <MDBCardImage
                                cascade
                                className='img-fluid'
                                overlay="white-light"
                                hover
                                src='https://5.imimg.com/data5/RK/KD/MY-19581894/electric-passenger-lift-500x500.jpg'
                            />
                            <MDBBtn
                                floating
                                tag='a'
                                className='ml-auto mr-4 lighten-3 mdb-coalor'
                                action
                            >
                                <MDBIcon icon='chevron-right' className="mdb-color lighten-3" />
                            </MDBBtn>
                            <MDBCardBody cascade>
                                <MDBCardTitle>Elevator</MDBCardTitle>
                                <hr />
                            </MDBCardBody>
                        </MDBCard>
                    </MDBCol>

                </MDBRow>
            </div>
        )
    }
}
