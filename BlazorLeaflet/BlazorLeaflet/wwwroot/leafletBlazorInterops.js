maps = {};
markers = {};

window.leafletBlazor = {
    create: function (elementId) {
        var map = L.map(elementId, {
            center: [0.0, 0.0],
            zoom: 13
        });

        maps[elementId] = map;
        markers[elementId] = [];
    },
    addTilelayer: function (mapId, tileLayer) {
        L.tileLayer(tileLayer.urlTemplate, {
            attribution: tileLayer.attribution,
            pane: tileLayer.pane,
            // ---
            size: tileLayer.size ? L.point(tileLayer.size.width, tileLayer.size.height) : undefined,
            opacity: tileLayer.opacity,
            updateWhenZooming: tileLayer.updateWhenZooming,
            updateInterval: tileLayer.updateInterval,
            zIndex: tileLayer.zIndex,
            bounds: tileLayer.bounds ? L.latLng((parseFloat(tileLayer.bounds.item1), parseFloat(tileLayer.bounds.item2))) : null,
            // ---
            minZoom: tileLayer.minimumZoom,
            maxZoom: tileLayer.maximumZoom,
            subdomains: tileLayer.subdomains,
            errorTileUrl: tileLayer.errorTileUrl,
            zoomOffset: tileLayer.zoomOffset,
            // TMS
            zoomReverse: tileLayer.isZoomReversed,
            detectRetina: tileLayer.detectRetina,
            // crossOrigin
        }).addTo(maps[mapId]);
    },
    addMarker: function (mapId, marker) {
        var options = {
            keyboard: marker.isKeyboardAccessible,
            title: marker.title,
            alt: marker.alt,
            zIndexOffset: marker.zIndexOffset,
            opacity: marker.opacity,
            riseOnHover: marker.riseOnHover,
            riseOffset: marker.riseOffset,
            pane: marker.pane,
            bubblingMouseEvents: marker.isBubblingMouseEvents,
            draggable: marker.draggable,
            autoPan: marker.useAutopan,
            autoPanPadding: marker.autoPanPadding,
            autoPanSpeed: marker.autoPanSpeed
        };

        if (marker.icon !== null) {
            options.icon = createIcon(marker.icon);
        }

        const mkr = L.marker([marker.position.x, marker.position.y], options).addTo(maps[mapId]);
        mkr.id = marker.id;

        markers[mapId].push(mkr);
    },
    removeMarker: function (mapId, markerId) {
        const remainingMarkers = markers[mapId].filter((m) => m.id !== markerId);
        const markersToBeRemoved = markers[mapId].filter((m) => m.id === markerId); // should be only one ...
        markers[mapId] = remainingMarkers;

        markersToBeRemoved.forEach(m => m.removeFrom(maps[mapId]));
    },
    clearMarkers: function (mapId) {
        markers[mapId].forEach((m) => {
            m.removeFrom(maps[mapId]);
        });
        markers[mapId] = [];
    }
};

function createIcon(icon) {
    return L.icon({
        iconUrl: icon.url,
        iconRetinaUrl: icon.retinaUrl,
        iconSize: icon.size ? L.point(icon.size.width, icon.size.height) : null,
        iconAnchor: icon.anchor ? L.point(icon.anchor.x, icon.anchor.y) : null,
        popupAnchor: L.point(icon.popupAnchor.x, icon.popupAnchor.y),
        tooltipAnchor: L.point(icon.tooltipAnchor.x, icon.tooltipAnchor.y),
        shadowUrl: icon.shadowUrl,
        shadowRetinaUrl: icon.shadowRetinaUrl,
        shadowSize: icon.shadowSize ? L.point(icon.shadowSize.width, icon.shadowSize.height) : null,
        shadowSizeAnchor: icon.shadowSizeAnchor ? L.point(icon.shadowSizeAnchor.width, icon.shadowSizeAnchor.height) : null,
        className: icon.className
    })
}