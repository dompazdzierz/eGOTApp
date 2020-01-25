export const capitalizeFirstLetter = (string) => {
    return string.charAt(0).toUpperCase() + string.slice(1);
}

export const getEntityId = (urlWithId) => {
    return urlWithId.substring(urlWithId.lastIndexOf('/') + 1);
}

export const deleteArrayElem = (id, arrayCopy) => {
    return arrayCopy.filter(x => x.id !== id);
}

export const countSectionScore = (length, elevationGain) => {
    // 1 punkt za każde 1000 m długości
    // 1 punkt za każde 100 m różnicy poziomów
    // zakokrąglamy w górę przy odpowiednio 501m i 51m
    const lengthPoints = Math.round((length / 1000) - 0.001);
    const elevationGainPoints = Math.round((elevationGain / 100) - 0.01);
    return lengthPoints + elevationGainPoints;
}