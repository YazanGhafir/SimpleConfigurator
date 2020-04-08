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
                    name={this.props.param_name}
                    id={this.props.radio_id}
                    onClick={ ()=> {this.props.marked_radios.push(this.props.param_name + '_' + this.props.radio_id); this.props.check_all(); console.log(this.props.marked_radios);}}
                />
            </div>
        )
    }
}
