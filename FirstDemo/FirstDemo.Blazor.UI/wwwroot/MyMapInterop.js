var maps=[];

export function MostraMappa(id, lat, lng, zoom) {
    console.log(id);
    var map = L.map(id).setView([lat, lng], zoom);
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);
    map.id = id;
    maps.push(map);
    console.log(maps);
    var marker = L.marker([lat, lng]).addTo(map);
    DotNet.invokeMethodAsync('FirstDemo.Blazor.UI', 'PopupMappa', id).then(popup => { marker.bindPopup(popup).openPopup(); });
}

export function AggiornaCoordinate(id, lat, lng, zoom) {
    console.log("Aggiorno " + id);
    var map = maps.find(m => m.id === id);
    if (map)
        map.setView([lat, lng], zoom);
}