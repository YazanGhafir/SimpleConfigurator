import React, { Component } from 'react'
import ListGroupingItem from './ListGroupingItem';
import Form from 'react-bootstrap/Form'

export default class Lift extends Component {


    constructor(props) {
        super(props);
        this.state = { 
            Parameters : [],
            ParameterValues : [],
            ConstraintsList : [],
            marked_radios : []
        };
    }


    componentDidMount() {
        fetch("https://localhost:44382/api/config")
            .then(res => res.json())
            .then((data) => {
                this.setState({ 
                    Parameters : Object.keys(data.Parameters),
                    ParameterValues : Object.values(data.Parameters),
                    ConstraintsList : data.ConstraintsList
                });
            }).catch(console.log);
    }
    
    render() {
        console.log(this.state);
        var i = 0;
        return (
            <div>
               <Form>
                    {this.state.Parameters.map((p, idx) => { return <ListGroupingItem parameter_name={p} parameter_values_keys={Object.keys(this.state.ParameterValues[i])} parameter_values_values={Object.values(this.state.ParameterValues[i++])} key={idx} /> })}
                </Form>
            </div>
        )
    }
}
/**
 *              
 */