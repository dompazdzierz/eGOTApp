import React from 'react';
import './HoweView.css';
import { Header } from 'semantic-ui-react';
import AppHeader from '../../Components/AppHeader/AppHeader';

class HomeView extends React.Component {

    handleClick = () => {
        console.log("XD")
    }

    render() {
        return(
            <div className="homeview--container">
                <AppHeader home />
                <Header as="h1" className="homeview--header">Odkryj piękno Tatr wraz z internetową książeczką PTTK</Header>
            </div>
        )
    }
}
export default HomeView;