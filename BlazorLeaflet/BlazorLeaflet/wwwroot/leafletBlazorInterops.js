maps = {};
layers = {};

window.leafletBlazor = {
    create: function (mapId, initPosition, initZoom) {
        var map = L.map(mapId, {
            center: [initPosition.x, initPosition.y],
            zoom: initZoom
        });

        maps[mapId] = map;
        layers[mapId] = [];
    },
    addTilelayer: function (mapId, tileLayer) {
        const layer = L.tileLayer(tileLayer.urlTemplate, {
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
        });
        layer.addTo(maps[mapId]);
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

        if (marker.tooltip !== null) {
            mkr.bindTooltip(marker.tooltip.content, {
                pane: marker.tooltip.pane,
                offset: L.point(marker.tooltip.offset.x, marker.tooltip.offset.y),
                direction: marker.tooltip.direction,
                permanent: marker.tooltip.isPermanent,
                sticky: marker.tooltip.isSticky,
                opacity: marker.tooltip.opacity
            });
        }

        if (marker.popup !== null) {
            mkr.bindPopup(marker.popup.content, {
                pane: marker.popup.pane,
                className: marker.popup.className,
                maxWidth: marker.popup.maximumWidth,
                minWidth: marker.popup.minimumWidth,
                autoPan: marker.popup.autoPanEnabled,
                autoPanPaddingTopLeft: marker.popup.autoPanPaddingTopLeft ? L.point(marker.popup.autoPanPaddingTopLeft.x, marker.popup.autoPanPaddingTopLeft.y) : null,
                autoPanPaddingBottomRight: marker.popup.autoPanPaddingBottomRight ? L.point(marker.popup.autoPanPaddingBottomRight.x, marker.popup.autoPanPaddingBottomRight.y) : null,
                autoPanPadding: L.point(marker.popup.autoPanPadding.x, marker.popup.autoPanPadding.y),
                keepInView: marker.popup.keepInView,
                closeButton: marker.popup.showCloseButton,
                autoClose: marker.popup.autoClose,
                closeOnEscapeKey: marker.popup.closeOnEscapeKey,
            });
        }

        layers[mapId].push(mkr);
    },
    removeLayer: function (mapId, layerId) {
        const remainingLayers = layers[mapId].filter((layer) => layer.id !== layerId);
        const layersToBeRemoved = layers[mapId].filter((layer) => layer.id === layerId); // should be only one ...
        layers[mapId] = remainingLayers;

        layersToBeRemoved.forEach(m => m.removeFrom(maps[mapId]));
    }
};

function createIcon(icon) {
    console.log(icon);
    return L.icon({
        iconUrl: icon.url,
        iconRetinaUrl: icon.retinaUrl,
        iconSize: icon.size ? L.point(icon.size.value.width, icon.size.value.height) : null,
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

function shapeToLatLngArray(shape) {
    var latlngs = [];
    shape.forEach(pts => {
        var ll = [];
        pts.forEach(p => ll.push([p.x, p.y]));
        latlngs.push(ll);
    });

    return latlngs;
}

function createPath(path) {
    return {
        ...createInteractiveLayer(path),
        stroke: path.drawStroke,
        color: getColorString(path.strokeColor),
        weight: path.strokeWidth,
        opacity: path.strokeOpacity,
        lineCap: path.lineCap,
        lineJoin: path.lineJoin,
        dashArray: path.strokeDashArray,
        dashOffset: path.strokeDashOffset,
        fill: path.fill,
        fillColor: getColorString(path.fillColor),
        fillOpacity: path.fillOpacity,
        fillRule: path.fillRule
    };
}

function createInteractiveLayer(layer) {
    return {
        ...createLayer(layer),
        interactive: layer.isInteractive,
        bubblingMouseEvents: layer.isBubblingMouseEvents
    };
}

function createLayer(layer) {
    return {
        id: layer.id,
        pane: layer.pane,
        attribution: layer.attribution
    };
}

function getColorString(color) {
    return "rgb(" + color.r + "," + color.g + "," + color.b + ")";
}