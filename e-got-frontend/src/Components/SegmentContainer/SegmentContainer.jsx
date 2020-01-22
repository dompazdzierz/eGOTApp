import React from 'react';
import { Segment, Button } from 'semantic-ui-react';
import { Route } from 'react-router';
import AppHeader from '../AppHeader/AppHeader';
import SegmentHeader from '../SegmentHeader/SegmentHeader';


class SegmentContainer extends React.Component {
    // IMPORTANT INFO: when using this component you should pass the props in pairs,
    // FOR EXAMPLE: if you want to render leftButton then pass leftButtonContent and leftButtonOnClick

    render() {
        const { leftButtonContent, leftSecButtonContent, rightButtonContent, rightSecButtonContent,
            leftButtonOnClick, leftSecButtonOnClick, rightButtonOnClick, rightSecButtonOnClick, headerContent, iconName} = this.props

        const leftBtnStyle = {
            visibility: leftButtonContent == null ? 'hidden' : 'visible'
        }

        const leftSecBtnStyle = {
            marginLeft: '15px',
            visibility: leftSecButtonContent == null ? 'hidden': 'visible'
        }

        const rightBtnStyle = {
            visibility: rightButtonContent == null ? 'hidden': 'visible'
        }

        const rightSecBtnStyle = {
            marginRight: '15px',
            visibility: rightSecButtonContent == null ? 'hidden': 'visible'
        }

        return(
            <div className="common--container">
                <AppHeader />
                <Segment className="common--segment">

                    <Route render={({ history }) => (
                        <Button id='left-btn' primary content={leftButtonContent} floated="left" style={leftBtnStyle}
                            className="common--button" onClick={leftButtonOnClick ? () => leftButtonOnClick(history) : () => {}} />
                    )} />

                    <Route render={({ history }) => (
                        <Button id='left-btn-sec' primary basic content={leftSecButtonContent} floated="left" style={leftSecBtnStyle}
                            className="common--button" onClick={leftSecButtonOnClick ? () => leftSecButtonOnClick(history) : () => {}}/>
                    )} />

                    <Route render={({ history }) => (
                        <Button id='right-btn' primary content={rightButtonContent} floated="right" style={rightBtnStyle}
                            className="common--button" onClick={rightButtonOnClick ? () => rightButtonOnClick(history) : () => {}}/>
                    )} />

                    <Route render={({ history }) => (
                        <Button id='right-btn-sec' primary basic content={rightSecButtonContent} floated="right" style={rightSecBtnStyle}
                            className="common--button" onClick={rightSecButtonOnClick ? () => rightSecButtonOnClick(history) : () => {}}/>
                    )} />

                    <SegmentHeader headerContent={headerContent} iconName={iconName}/>

                    {this.props.children}

                </Segment>
            </div>
        )
    }
}
export default SegmentContainer;