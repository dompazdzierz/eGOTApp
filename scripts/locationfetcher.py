from urllib.request import urlopen
import random

mountains = {
    'Tatry i Podtatrze': {
        'Tatry Wysokie': 'http://ktg.hg.pl/komisja-tg/got/tatry_wysokie.html',
        'Tatry Zachodnie': 'http://ktg.hg.pl/komisja-tg/got/tatry_zachodnie.html',
        'Podtatrze': 'http://ktg.hg.pl/komisja-tg/got/podtatrze.html'
    },
    'Beskidy Zachodnie': {
        'Beskid Śląski': 'http://ktg.hg.pl/komisja-tg/got/b_slaski-a.html',
        'Beskid Żywiecki': 'http://ktg.hg.pl/komisja-tg/got/zywiecki.html',
        'Beskid Mały': 'http://ktg.hg.pl/komisja-tg/got/b_maly.html',
        'Beskid Średni': 'http://ktg.hg.pl/komisja-tg/got/b_sredni.html',
        'Gorce': 'http://ktg.hg.pl/komisja-tg/got/gorce.html',
        'Beskid Wyspowy': 'http://ktg.hg.pl/komisja-tg/got/b_wyspowy.html',
        'Orawa': 'http://ktg.hg.pl/komisja-tg/got/orawa.html',
        'Spisz i Pieniny': 'http://ktg.hg.pl/komisja-tg/got/pieniny_spisz.html',
        'Beskid Sądecki': 'http://ktg.hg.pl/komisja-tg/got/b_sadecki.html',
        'Pogórze Wielickie': 'http://ktg.hg.pl/komisja-tg/got/p_wielickie.html',
        'Pogórze Wiśnickie': 'http://ktg.hg.pl/komisja-tg/got/p_wisnickie.html',
        'Pogórze Rożnowskie': 'http://ktg.hg.pl/komisja-tg/got/p_roznowskie.html'
    },
    'Beskidy Wschodnie': {
        'Pogórze Ciężkowickie': 'http://ktg.hg.pl/komisja-tg/got/p_ciezkowickie.html',
        'Beskid Niski część zachodnia': 'http://ktg.hg.pl/komisja-tg/got/niski-zachod.html',
        'Beskid Niski część wschodnia': 'http://ktg.hg.pl/komisja-tg/got/niski-wschod.html',
        'Bieszczady': 'http://ktg.hg.pl/komisja-tg/got/bieszczady.html',
        'Pogórze Strzyżowsko-Dynowskie': 'http://ktg.hg.pl/komisja-tg/got/p_strzyzowsko-dynowskie.html',
        'Pogórze Przemyskie': 'http://ktg.hg.pl/komisja-tg/got/p_przemyskie.html'
    },
    'Sudety': {
        'Góry Izerskie': 'http://ktg.hg.pl/komisja-tg/got/sudety/izerskie-s01.html',
        'Pogórze Izerskie': 'http://ktg.hg.pl/komisja-tg/got/sudety/izerskie-s02.html',
        'Karkonosze': 'http://ktg.hg.pl/komisja-tg/got/sudety/karkonosze-s03.html',
        'Kotlina Jeleniogórska': 'http://ktg.hg.pl/komisja-tg/got/sudety/kotlina-jeleniogorska-s04.html',
        'Rudawy Janowickie': 'http://ktg.hg.pl/komisja-tg/got/sudety/rudawy-janowickie-s05.html',
        'Góry Kaczawskie': 'http://ktg.hg.pl/komisja-tg/got/sudety/kaczawskie-s06.html',
        'Pogórze Kaczawskie': 'http://ktg.hg.pl/komisja-tg/got/sudety/pogorze-kaczawskie-s07.html',
        'Kotlina Kamiennogórska': 'http://ktg.hg.pl/komisja-tg/got/sudety/kotlina-kamiennogorska-s08.html',
        'Góry Kamienne': 'http://ktg.hg.pl/komisja-tg/got/sudety/kamienne-s09.html',
        'Góry Wałbrzyskie, Pogórze Bolkowsko-Wałbrzyskie': 'http://ktg.hg.pl/komisja-tg/got/sudety/walbrzyskie-s10.html',
        'Góry Sowie, Wzgórza Włodzickie': 'http://ktg.hg.pl/komisja-tg/got/sudety/sowie-s11.html',
        'Góry Bardzkie': 'http://ktg.hg.pl/komisja-tg/got/sudety/bardzkie-s12.html',
        'Góry Stołowe, Wzgórza Lewińskie': 'http://ktg.hg.pl/komisja-tg/got/sudety/stolowe-s13.html',
        'Góry Orlickie, Góry Bystrzyckie': 'http://ktg.hg.pl/komisja-tg/got/sudety/orlickie-s14.html',
        'Kotlina Kłodzka, Rów Górnej Nysy': 'http://ktg.hg.pl/komisja-tg/got/sudety/kotlina_klodzka-s15.html',
        'Masyw Śnieżnika, Góry Bialskie': 'http://ktg.hg.pl/komisja-tg/got/sudety/snieznik-s16.html',
        'Góry Złote': 'http://ktg.hg.pl/komisja-tg/got/sudety/zlote-s17.html',
        'Góry Opawskie': 'http://ktg.hg.pl/komisja-tg/got/sudety/opawskie-s18.html',
        'Wzgórza Strzegomskie': 'http://ktg.hg.pl/komisja-tg/got/sudety/strzegomskie-s19.html',
        'Masyw Ślęży, Równina Świdnicka, Kotlina Dzierżoniowska': 'http://ktg.hg.pl/komisja-tg/got/sudety/strzegomskie-s19.html',
        'Wzgórza Niemczańsko-Strzelińskie, Przedgórze Paczkowskie': 'http://ktg.hg.pl/komisja-tg/got/sudety/paczkowskie-s21.html'
    }
}


global_msystems = []
for msystem in mountains.keys():
    global_msystems.append(msystem)

global_mranges = []
for msystem, mranges in mountains.items():
    for mrange in mranges:
        global_mranges.append((mrange, msystem))

locations_for_mrange = {}
for msystem, mranges in mountains.items():
    for mrange, url in mranges.items():
        locations_for_mrange[mrange] = []

        with urlopen(url) as response:
            for encoded_line in response.readlines():
                line = str(encoded_line.decode('iso-8859-2'))
                tag = 'strong' if line.find('<strong>') != -1 else 'b' if line.find('<b>') != -1 else None

                if tag:
                    start_index = line.find('<{0}>'.format(tag))
                    end_index = line.find('</{0}>'.format(tag))
                    location = line[start_index + len('<{0}>'.format(tag)):end_index].strip()

                    parenthesis_index = location.find('(')
                    location = location if parenthesis_index == -1 else location[0:parenthesis_index - 1]

                    location = location.replace('&#160;', ' ')
                    location = location.strip()
                    location = location.replace('"', '\\"')

                    locations_for_mrange[mrange].append(location)

global_locations = []
all_locations = []
for mrange, locations in locations_for_mrange.items():
    for location in locations:
        all_locations.append(location)

for location in list(set(all_locations)):
    longitude = round(random.uniform(49.541157, 50.779619), 6)
    latitude = round(random.uniform(16.210728, 22.367053), 6)

    global_locations.append((location, longitude, latitude))

global_sections = []
for mrange, locations in locations_for_mrange.items():
    for i in range(len(locations) * 3):
        start_location = locations[i // 5]
        end_location = random.choice(locations)
        length = int(random.uniform(500, 5000))
        elevation_gain = int(random.uniform(50, 500))
        reverse_elevation_gain = max(0, elevation_gain + random.uniform(-100, 100))
        score = int(length // 1000 + elevation_gain // 100)
        reverse_score = int(length // 1000 + reverse_elevation_gain // 100)
        status = True
        mountain_range = mrange

        global_sections.append((start_location, end_location, length, elevation_gain, score, status, mountain_range))
        global_sections.append((end_location, start_location, length, elevation_gain, reverse_score, status, mountain_range))


with open('mountainSystems.json', 'w') as file:
    file.write('[')
    separator = ''

    for msystem in global_msystems:
        file.write('{0}\n    {{\n        "name": "{1}"\n    }}'.format(separator, msystem))
        separator = ','
    
    file.write('\n]\n')


with open('mountainRanges.json', 'w') as file:
    file.write('[')
    separator = ''

    for mrange, msystem in global_mranges:
        file.write('{0}\n    {{\n        "name": "{1}",\n        "mountainRange": "{2}"\n    }}'.format(separator, mrange, msystem))
        separator = ','
    
    file.write('\n]\n')


with open('locations.json', 'w') as file:
    file.write('[')
    separator = ''

    for location, longitude, latitude in global_locations:
        file.write('{0}\n    {{\n        "name": "{1}",\n        "longitude": {2},\n        "latitude": {3}\n    }}'.format(separator, location, longitude, latitude))
        separator = ','
    
    file.write('\n]\n')


with open('sections.json', 'w') as file:
    file.write('[')
    separator = ''

    for start_location, end_location, length, elevation_gain, score, status, mountain_range in global_sections:
        file.write('{0}\n    {{\n        "startLocation": "{1}",\n        "endLocation": "{2}",\n        "length": {3},\n        "elevationGain": {4},\n        "score": {5},\n        "status": {6},\n        "mountainRange": "{7}"\n    }}'.format(separator, start_location, end_location, length, elevation_gain, score, "true" if status else "false", mountain_range))
        separator = ','
    
    file.write('\n]\n')
