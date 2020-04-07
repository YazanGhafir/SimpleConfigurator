import React, { Component } from 'react'

export default class Lift extends Component {


    constructor(props) {
        super(props);
        this.state = { 
            Parameters : [],
            ConstraintsList : []
        };
    }


    componentDidMount() {
        fetch("https://localhost:44382/api/config")
            .then(res => res.json())
            .then((data) => {
                this.setState({ 
                    Parameters : data.Parameters,
                    ConstraintsList : data.ConstraintsList
                });
            }).catch(console.log);
    }
    
    render() {
        console.log(this.state);
        return (
            <div>
                
            </div>
        )
    }
}
