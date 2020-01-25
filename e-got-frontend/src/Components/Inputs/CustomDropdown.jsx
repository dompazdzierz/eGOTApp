import React from 'react';
import './Inputs.css'
import { Form } from 'semantic-ui-react';

class CustomDropdown extends React.Component {

    render() {
        let { header, placeholder, options, initialValue, onChange, error } = this.props

        return(
            <React.Fragment>
                <p className="inputs--label">{header}</p>
                <Form.Dropdown
                    className="inputs--input"
                    placeholder={placeholder}
                    search
                    selection
                    options={options}
                    value={initialValue}
                    error={error}
                    onChange={(_, data) => {
                        onChange(data.value)
                    }}
                />
            </React.Fragment>
        )
    }
}

export default CustomDropdown;
