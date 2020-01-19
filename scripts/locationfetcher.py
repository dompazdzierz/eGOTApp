from urllib.request import urlopen

urls = [
    'http://ktg.hg.pl/komisja-tg/got/tatry_wysokie.html',
    'http://ktg.hg.pl/komisja-tg/got/tatry_zachodnie.html',
    'http://ktg.hg.pl/komisja-tg/got/podtatrze.html',
    'http://ktg.hg.pl/komisja-tg/got/b_slaski-a.html',
    'http://ktg.hg.pl/komisja-tg/got/zywiecki.html',
    'http://ktg.hg.pl/komisja-tg/got/b_maly.html',
    'http://ktg.hg.pl/komisja-tg/got/b_sredni.html',
    'http://ktg.hg.pl/komisja-tg/got/gorce.html',
    'http://ktg.hg.pl/komisja-tg/got/b_wyspowy.html',
    'http://ktg.hg.pl/komisja-tg/got/orawa.html',
    'http://ktg.hg.pl/komisja-tg/got/pieniny_spisz.html',
    'http://ktg.hg.pl/komisja-tg/got/b_sadecki.html',
    'http://ktg.hg.pl/komisja-tg/got/p_wielickie.html',
    'http://ktg.hg.pl/komisja-tg/got/p_wisnickie.html',
    'http://ktg.hg.pl/komisja-tg/got/p_roznowskie.html',
    'http://ktg.hg.pl/komisja-tg/got/p_ciezkowickie.html',
    'http://ktg.hg.pl/komisja-tg/got/niski-zachod.html',
    'http://ktg.hg.pl/komisja-tg/got/niski-wschod.html',
    'http://ktg.hg.pl/komisja-tg/got/bieszczady.html',
    'http://ktg.hg.pl/komisja-tg/got/p_strzyzowsko-dynowskie.html',
    'http://ktg.hg.pl/komisja-tg/got/p_przemyskie.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/izerskie-s01.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/izerskie-s02.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/karkonosze-s03.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/kotlina-jeleniogorska-s04.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/rudawy-janowickie-s05.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/kaczawskie-s06.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/pogorze-kaczawskie-s07.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/kotlina-kamiennogorska-s08.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/kamienne-s09.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/walbrzyskie-s10.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/sowie-s11.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/bardzkie-s12.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/stolowe-s13.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/orlickie-s14.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/kotlina_klodzka-s15.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/snieznik-s16.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/zlote-s17.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/opawskie-s18.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/strzegomskie-s19.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/strzegomskie-s19.html',
    'http://ktg.hg.pl/komisja-tg/got/sudety/paczkowskie-s21.html'
]
index = 0
filename = 'locations.json'

with open(filename, 'w') as file:
    file.write('[')
    separator = ''

    for url in urls:
        with urlopen(url) as response:
            for encoded_line in response.readlines():
                line = str(encoded_line.decode('iso-8859-2'))

                tag = 'strong' if line.find('<strong>') != -1 else 'b' if line.find('<b>') != -1 else None

                if tag:
                    start_index = line.find('<{0}>'.format(tag))

                    if start_index != -1:
                        end_index = line.find('</{0}>'.format(tag))
                        location = line[start_index + len('<{0}>'.format(tag)):end_index].strip()

                        parenthesis_index = location.find('(')
                        location = location if parenthesis_index == -1 else location[0:parenthesis_index - 1]

                        mystery_characters_index = line.find('&#160;')
                        location = location if mystery_characters_index == -1 else location[len('&#160;'):]

                        location = location.replace('"', '\\"')

                        file.write('{2}\n    {{\n        "id": {0},\n        "name": "{1}",\n        "longitude": 0,\n        "latitude": 0\n    }}'.format(index, location, separator))

                        index += 1
                        separator = ','
    file.write('\n]\n')
