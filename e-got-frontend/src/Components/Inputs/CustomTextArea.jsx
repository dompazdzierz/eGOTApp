import React from 'react';
import './Inputs.css'
import { TextArea } from 'semantic-ui-react';

class CustomTextArea extends React.Component {
    render() {
        let { header, placeholder, value, onChange } = this.props

        return(
            <React.Fragment>
                <p className="inputs--label">{header}</p>
                <TextArea disabled className="inputs--input" value={value} onChange={onChange} placeholder={placeholder}/>
            </React.Fragment>
        )
    }
}
export default CustomTextArea;


