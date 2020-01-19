import React from 'react';
import './HoweView.css';
import { Header, Button } from 'semantic-ui-react';

class PrepopulateDatabaseView extends React.Component {
    render() {

        handlePrepopulateClick = () => {
            
        }

        const mountainSystemsJson =
        [
            {
                "name": "Tatry i Podtatrze"
            },
            {
                "name": "Beskidy Zachodnie"
            },
            {
                "name": "Beskidy Wschodnie"
            },
            {
                "name": "Sudety"
            }
        ];

        const mountainRangesJson =
        [
            {
                "name": "Tatry Wysokie",
                "mountainRange": 0
            },
            {
                "name": "Tatry Zachodnie",
                "mountainRange": 0
            },
            {
                "name": "Podtatrze",
                "mountainRange": 0
            },
            {
                "name": "Beskid Śląski",
                "mountainRange": 1
            },
            {
                "name": "Beskid Żywiecki",
                "mountainRange": 1
            },
            {
                "name": "Beskid Mały",
                "mountainRange": 1
            },
            {
                "name": "Beskid Średni",
                "mountainRange": 1
            },
            {
                "name": "Gorce",
                "mountainRange": 1
            },
            {
                "name": "Beskid Wyspowy",
                "mountainRange": 1
            },
            {
                "name": "Orawa",
                "mountainRange": 1
            },
            {
                "name": "Spisz i Pieniny",
                "mountainRange": 1
            },
            {
                "name": "Beskid Sądecki",
                "mountainRange": 1
            },
            {
                "name": "Pogórze Wielickie",
                "mountainRange": 1
            },
            {
                "name": "Pogórze Wiśnickie",
                "mountainRange": 1
            },
            {
                "name": "Pogórze Rożnowskie",
                "mountainRange": 1
            },
            {
                "name": "Pogórze Ciężkowickie",
                "mountainRange": 2
            },
            {
                "name": "Beskid Niski część zachodnia",
                "mountainRange": 2
            },
            {
                "name": "Beskid Niski część wschodnia",
                "mountainRange": 2
            },
            {
                "name": "Bieszczady",
                "mountainRange": 2
            },
            {
                "name": "Pogórze Strzyżowsko-Dynowskie",
                "mountainRange": 2
            },
            {
                "name": "Pogórze Przemyskie",
                "mountainRange": 2
            },
            {
                "name": "Góry Izerskie",
                "mountainRange": 3
            },
            {
                "name": "Pogórze Izerskie",
                "mountainRange": 3
            },
            {
                "name": "Karkonosze",
                "mountainRange": 3
            },
            {
                "name": "Kotlina Jeleniogórska",
                "mountainRange": 3
            },
            {
                "name": "Rudawy Janowickie",
                "mountainRange": 3
            },
            {
                "name": "Góry Kaczawskie",
                "mountainRange": 3
            },
            {
                "name": "Pogórze Kaczawskie",
                "mountainRange": 3
            },
            {
                "name": "Kotlina Kamiennogórska",
                "mountainRange": 3
            },
            {
                "name": "Góry Kamienne",
                "mountainRange": 3
            },
            {
                "name": "Góry Wałbrzyskie, Pogórze Bolkowsko-Wałbrzyskie",
                "mountainRange": 3
            },
            {
                "name": "Góry Sowie, Wzgórza Włodzickie",
                "mountainRange": 3
            },
            {
                "name": "Góry Bardzkie",
                "mountainRange": 3
            },
            {
                "name": "Góry Stołowe, Wzgórza Lewińskie",
                "mountainRange": 3
            },
            {
                "name": "Góry Orlickie, Góry Bystrzyckie",
                "mountainRange": 3
            },
            {
                "name": "Kotlina Kłodzka, Rów Górnej Nysy",
                "mountainRange": 3
            },
            {
                "name": "Masyw Śnieżnika, Góry Bialskie",
                "mountainRange": 3
            },
            {
                "name": "Góry Złote",
                "mountainRange": 3
            },
            {
                "name": "Góry Opawskie",
                "mountainRange": 3
            },
            {
                "name": "Wzgórza Strzegomskie",
                "mountainRange": 3
            },
            {
                "name": "Masyw Ślęży, Równina Świdnicka, Kotlina Dzierżoniowska",
                "mountainRange": 3
            },
            {
                "name": "Wzgórza Niemczańsko-Strzelińskie, Przedgórze Paczkowskie",
                "mountainRange": 3
            }
        ]

        return(
            <div className="homeview--container">
                <Button>
                    Załaduj przykładowe dane.
                </Button>
            </div>
        )
    }
}
export default PrepopulateDatabaseView;