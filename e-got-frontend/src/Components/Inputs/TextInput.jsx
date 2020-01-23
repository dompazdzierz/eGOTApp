import React from 'react';
import './Inputs.css'
import { Input } from 'semantic-ui-react';

function TextInput(props) {
    // Jeżeli textInput ma być modyfikowalny należy przekazać do niego metodę onChange.
    // onChange może być generyczny, należy wtedy przekazać 'name', którego wartość to nazwa zmienianego state'a
    // przykład generycznego onChange'a:   onChange = e => this.setState({ [e.target.name]: e.target.value })

    const label = props.label ? { basic: true, content: props.label } : undefined;
    const labelPosition = props.label ? 'right' : undefined;

    return (
        props.onChange ?
            <React.Fragment>
                <p className='inputs--label'>{props.header}</p>
                <Input className='inputs--input' name={props.name} onChange={props.onChange} type={props.type} min={props.min} max={props.max}
                    value={props.value} label={label} labelPosition={labelPosition} required={props.required} maxLength={props.maxLength}/>
            </React.Fragment>
            :
            <React.Fragment>
                <p className='inputs--label'>{props.header}</p>
                <Input disabled className='inputs--input' value={props.value} label={label} labelPosition={labelPosition} name={props.name}
                required={props.required} maxLength={props.maxLength}/>
            </React.Fragment>
    )
}
export default TextInput;