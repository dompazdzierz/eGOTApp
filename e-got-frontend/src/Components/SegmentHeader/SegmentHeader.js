import React from 'react';
import { Icon, Header } from 'semantic-ui-react';

function SegmentHeader(props) {
    return (
        <div style={{marginTop: '36px'}}>
            {props.iconName ?  <Icon style={{linemaxHeight: 'unset', verticalAlign: 'unset'}} name={props.iconName} size="big"/> : null}
            <Header icon as='h2'>
                <Header.Content>{props.headerContent}</Header.Content>
            </Header>
        </div>
    )
}
export default SegmentHeader;