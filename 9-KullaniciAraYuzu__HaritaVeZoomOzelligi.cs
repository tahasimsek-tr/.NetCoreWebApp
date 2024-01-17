//Harita üzerinde etkinlik konumu gösterilecek, zoom özelliği olacak

// 'Views/Home/Index.cshtml' dosyasını düzenleyerek aşağıdaki kodu ekleyin:
@{
    ViewData["Title"] = "Event Location";
}

<h2>@ViewData["Title"]</h2>

<div id="map" style="height: 400px;"></div>

<!-- Leaflet CSS dosyasını ekleyin -->
<link rel="stylesheet" href="https://unpkg.com/leaflet/dist/leaflet.css" integrity="sha384-MrcWRIb8qXqnV4ZRDC5RQ7SNtkUOpDY0M2a6StQlFfN5QH8kM5+8a5t55JW5lFdi" crossorigin="anonymous">

<!-- Leaflet JavaScript dosyasını ekleyin -->
<script src="https://unpkg.com/leaflet/dist/leaflet.js" integrity="sha384-JUqBe8VjFH7CkpL3+R8U2fDfViZ3qOWpR97dt1QjcYgQ3eImQ+Wh1A6g/jxIbYdL" crossorigin="anonymous"></script>

<script>
    // Etkinlik konumu koordinatları
    var eventLocation = [-39.866667, -147.133333]; // Ankara koordinatları

    // Harita oluştur
    var map = L.map('map').setView(eventLocation, 13);

    // Harita üzerine OpenStreetMap katmanını ekleyin
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    // Harita üzerine bir işaretçi ekleyin
    L.marker(eventLocation).addTo(map)
        .bindPopup('Etkinlik Konumu')
        .openPopup();
</script>
