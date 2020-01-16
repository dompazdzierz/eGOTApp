import React from 'react';
import { Icon, Header } from 'semantic-ui-react';

function SegmentHeader(props) {
    return (
        <div style={{marginTop: '20px'}}>
            {props.iconName ?  <Icon style={{linemaxHeight: 'unset', verticalAlign: 'unset'}} name={props.iconName} size="big"/> : null}
            <Header icon as='h2' style={{paddingLeft: '10px', marginTop: '0px'}}>
                <Header.Content>{props.headerContent}</Header.Content>
            </Header>
        </div>
    )
}
export default SegmentHeader;