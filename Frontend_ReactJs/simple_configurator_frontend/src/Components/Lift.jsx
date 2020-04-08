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

    check_all(){
            // clear marked_radios, add all the pressed radios to it on each klick
            // do the 2 constraints checks
            // do the 3 constraints checks


            // ideas:
            // add last clicked element to the state and pass it
            // add event listener on the last clicked element
    }

    check_marked_duplicates(){

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
                    {this.state.Parameters.map((p, idx) => { 
                        return <ListGroupingItem 
                        parameter_name={p}
                        parameter_values_keys={Object.keys(this.state.ParameterValues[i])} 
                        parameter_values_values={Object.values(this.state.ParameterValues[i++])} 
                        key={idx} 
                        check_all={this.check_all} 
                        marked_radios={this.state.marked_radios}/> })}
                </Form>
            </div>
        )
    }
}
/**
 *              
 */