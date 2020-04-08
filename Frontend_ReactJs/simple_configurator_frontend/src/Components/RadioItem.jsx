import React, { Component } from 'react'
import Form from 'react-bootstrap/Form'

export default class RadioItem extends Component {
    render() {
        return (
            <div >
                <Form.Check
                    custom
                    type="radio"
                    label={this.props.radio_name}
                    name={this.props.radio_name}
                    id={this.props.radio_id}
                />
            </div>
        )
    }
}
