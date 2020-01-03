import React from 'react';
import './HoweView.css';
import { Header } from 'semantic-ui-react';
import AppHeader from '../../Components/AppHeader/AppHeader';

class HomeView extends React.Component {
    render() {
        return(
            <div>
                <AppHeader home />
                <div className="main-container">
                    <div className="header-container">
                        <Header as="h1" className="header">Odkryj piękno tatr wraz z internetową książeczką PTTK</Header>
                    </div>
                </div>
            </div>
        )
    }
}
export default HomeView;