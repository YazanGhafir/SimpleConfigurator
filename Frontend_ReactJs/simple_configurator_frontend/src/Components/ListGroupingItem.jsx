import React, { Component } from 'react'
import RadioItem from './RadioItem'
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';

export default class ListGroupingItem extends Component {
    render() {
        var j = 0;
        return (
            <div>
                <fieldset>
                    <Form.Group as={Row}>
                    <Form.Label as="legend" column>
                        {this.props.parameter_name}
                    </Form.Label>
                    <Col sm={10} >
                        {this.props.parameter_values_values.map((pv, idx) => {return <RadioItem param_name={this.props.parameter_name} radio_name={pv} radio_id={this.props.parameter_values_keys[j++]} key={idx} /> })}
                    </Col>
                    </Form.Group>
                </fieldset>


                </div>
            
        )
    }
}

