import React from 'react';
import './Inputs.css'
import { Dropdown } from 'semantic-ui-react';

class CustomDropdown extends React.Component {

    render() {
        let { header, placeholder, options, initialValue, onChange } = this.props

        return(
            <React.Fragment>
                <p className="inputs--label">{header}</p>
                <Dropdown
                    className="inputs--input"
                    placeholder={placeholder}
                    search
                    selection
                    options={options}
                    value={initialValue}
                    onChange={(_, data) => {
                        onChange(data.value)
                    }}
                />
            </React.Fragment>
        )
    }
}

export default CustomDropdown;
