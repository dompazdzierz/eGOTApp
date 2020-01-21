import React from 'react';
import { Icon, Header, Segment } from 'semantic-ui-react';

function NoDataSegment(props) {
    return (
        <Segment placeholder style={{height: '70vh'}}>
            <Header icon>
            <Icon name='exclamation triangle' />
                {props.noDataMessage}
            </Header>
        </Segment>
    )
}
export default NoDataSegment;


