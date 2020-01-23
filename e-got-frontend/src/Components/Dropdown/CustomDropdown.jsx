import React from 'react';
import { Dropdown } from 'semantic-ui-react';

class CustomDropdown extends React.Component {

    render() {
        let { header, placeholder, options, initialValue, onChange } = this.props

        return(
            <div>
                <p>{header}</p>
                <Dropdown
                    placeholder={placeholder}
                    fluid
                    search
                    selection
                    options={options}
                    value={initialValue}
                    onChange={(_, data) => {
                        onChange(data.value)
                    }}
                />
            </div>
        )
    }
}

export default CustomDropdown;
