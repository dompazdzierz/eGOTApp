import {capitalizeFirstLetter, getEntityId,
  deleteArrayElem, countSectionScore} from './Common/methods';

test('capitalize first letter', () => {
  const text = 'value';
  const capitalizedFirstLetterText = capitalizeFirstLetter(text);
  expect(capitalizedFirstLetterText).toBe('Value');
});


test('get id from url that is containig id', () => {
  const url = 'http://localhost:3000/edit-trip/5';
  const idFromUrl = getEntityId(url);
  expect(idFromUrl).toBe('5');
});

test('delete array elem by elem parameter id', () => {
  const array = [];
  array.push({id: 1, value: 'abc'});
  array.push({id: 2, value: 'abcd'});
  const shorterArray = deleteArrayElem(1, array);
  expect(shorterArray).toStrictEqual([{id: 2, value: 'abcd'}]);
});

test('counting trip score 1', () => {
  const length1 = 501;
  const elevationGain1 = 51;
  expect(countSectionScore(length1, elevationGain1)).toBe(2);
});

test('counting trip score 2', () => {
  const length1 = 500;
  const elevationGain1 = 50;
  expect(countSectionScore(length1, elevationGain1)).toBe(0);
});

test('counting trip score 3', () => {
  const length1 = 2750;
  const elevationGain1 = 225;
  expect(countSectionScore(length1, elevationGain1)).toBe(5);
});
