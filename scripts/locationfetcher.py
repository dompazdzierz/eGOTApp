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
for i, msystem in enumerate(mountains.keys()):
    global_msystems.append((i, msystem))

global_mranges = []
index = 0
for msystem, mranges in mountains.items():
    for mrange in mranges:
        global_mranges.append((index, mrange, [i for i, ms in global_msystems if ms == msystem][0]))
        index += 1

locations_for_mrange = {}
index = 0
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

                    longitude = round(random.uniform(49.541157, 50.779619), 6)
                    latitude = round(random.uniform(16.210728, 22.367053), 6)

                    locations_for_mrange[mrange].append((index, location, longitude, latitude))
                    
                    index += 1

global_locations = []
for mrange, locations in locations_for_mrange.items():
    for location in locations:
        global_locations.append(location)

global_sections = []
index = 0
for mrange, locations in locations_for_mrange.items():
    for i in range(len(locations) * 3):
        indexxx = i // 5
        choice = random.choice(locations)
        start_location = [i for i, loc, lat, lon in global_locations if loc == locations[indexxx][1]][0]
        end_location = [i for i, loc, lat, lon in global_locations if loc == choice[1]][0]
        length = int(random.uniform(500, 5000))
        elevation_gain = int(random.uniform(50, 500))
        reverse_elevation_gain = max(0, elevation_gain + random.uniform(-100, 100))
        score = int(length // 1000 + elevation_gain // 100)
        reverse_score = int(length // 1000 + reverse_elevation_gain // 100)
        status = True
        mountain_range = [i for i, mr, ms in global_mranges if mr == mrange][0]

        global_sections.append((index, start_location, end_location, length, elevation_gain, score, status, mountain_range))
        global_sections.append((index + 1, end_location, start_location, length, elevation_gain, reverse_score, status, mountain_range))

        index += 2


with open('mountainSystems.json', 'w') as file:
    file.write('[')
    separator = ''

    for i, msystem in global_msystems:
        file.write('{0}\n    {{\n        "id": {1},\n        "name": "{2}"\n    }}'.format(separator, i, msystem))
        separator = ','
    
    file.write('\n]\n')


with open('mountainRanges.json', 'w') as file:
    file.write('[')
    separator = ''

    for i, mrange, msystem in global_mranges:
        file.write('{0}\n    {{\n        "id": {1},\n        "name": "{2}",\n        "mountainRange": {3}\n    }}'.format(separator, i, mrange, msystem))
        separator = ','
    
    file.write('\n]\n')


with open('locations.json', 'w') as file:
    file.write('[')
    separator = ''

    for index, location, longitude, latitude in global_locations:
        file.write('{0}\n    {{\n        "id": {1},\n        "name": "{2}",\n        "longitude": {3},\n        "latitude": {4}\n    }}'.format(separator, index, location, longitude, latitude))
        separator = ','
    
    file.write('\n]\n')


with open('sections.json', 'w') as file:
    file.write('[')
    separator = ''

    for index, start_location, end_location, length, elevation_gain, score, status, mountain_range in global_sections:
        file.write('{0}\n    {{\n        "id": {1},\n        "startLocation": {2},\n        "endLocation": {3},\n        "length": {4},\n        "elevationGain": {5},\n        "score": {6},\n        "status": {7},\n        "mountainRange": {8}\n    }}'.format(separator, index, start_location, end_location, length, elevation_gain, score, "true" if status else "false", mountain_range))
        separator = ','
    
    file.write('\n]\n')
