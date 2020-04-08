import React, { Component } from 'react'
import Form from 'react-bootstrap/Form'

export default class RadioItem extends Component {

    duplicate_handler(last_added){
        var last_added_tuple = last_added.split('_');
        var last_added_param = last_added_tuple[0];
        var last_added_radio_id = last_added_tuple[1];
        var found = false;
        var len = this.props.marked_radios.length
        for (let i = 0; i < len; i++) {
            var element_tuple = this.props.marked_radios[i].split('_');
            var element_param = element_tuple[0];
            var element_radio_id = element_tuple[1];
            if(element_param === last_added_param){
                this.props.marked_radios[i] = last_added;
                found = true;
            }
        }
        if (!found){
            this.props.marked_radios.push(last_added);
        }
    }

    two_and_three_constraints_handler(){
        this.enableAllRadios();
        var marked_len = this.props.marked_radios.length
        for (let i = 0; i < marked_len; i++) {
            var element_tuple = this.props.marked_radios[i].split('_');
            var element_radio_id = element_tuple[1];
            var con_list_len = this.props.ConstraintsList.length;
            for (let i = 0; i < con_list_len; i++) {
                var len = this.props.ConstraintsList[i].length;
                if(len === 2){
                    if(element_radio_id == this.props.ConstraintsList[i][0]){
                        this.disableRadioById(this.props.ConstraintsList[i][1].toString());
                    } else if(element_radio_id == this.props.ConstraintsList[i][1]){
                        this.disableRadioById(this.props.ConstraintsList[i][0].toString());
                    }
                } else if(len === 3){
                    var activated_radios = this.activated_radios_list();
                    if(activated_radios.includes(this.props.ConstraintsList[i][0]) &&
                    activated_radios.includes(this.props.ConstraintsList[i][1])){
                        this.disableRadioById(this.props.ConstraintsList[i][2].toString());
                    }
                }
            }
        }
    }

    activated_radios_list(){
        var activated_radios_list = [];
        this.props.marked_radios.forEach(element => {
            var element_tuple = element.split('_');
            activated_radios_list.push(element_tuple[1]);
        });
        return activated_radios_list;
    }

        
    disableRadioById(radio_id){
        document.getElementById(radio_id).disabled = true;
    }

    enableAllRadios(){
        this.props.ParameterValues.forEach(pv => {
            Object.keys(pv).forEach(v => {
                document.getElementById(v).disabled = false;
            });
        });
    }
    

    render() {
        return (
            <div >
                <Form.Check
                    custom
                    type="radio"
                    label={this.props.radio_name}
                    name={this.props.param_name}
                    id={this.props.radio_id}
                    onClick={ ()=> 
                        {
                            this.duplicate_handler(this.props.param_name + '_' + this.props.radio_id);
                            this.two_and_three_constraints_handler();
                        }
                    }
                />
            </div>
        )
    }
}
