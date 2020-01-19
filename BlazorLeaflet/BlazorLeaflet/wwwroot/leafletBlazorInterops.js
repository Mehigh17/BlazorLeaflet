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
    addTilelayer: function (mapId, tileLayer, objectReference) {
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
    addMarker: function (mapId, marker, objectReference) {
        var options = {
            ...createInteractiveLayer(marker),
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

        if (marker.tooltip) {
            addTooltip(mkr, marker.tooltip);
        }

        if (marker.popup) {
            addPopup(mkr, marker.popup);
        }

        layers[mapId].push(mkr);

        mkr.on("mouseover", function (eventArgs) {
            objectReference.invokeMethodAsync("NotifyMouseOver", cleanupEventArgsForSerialization(eventArgs));
        });
    },
    addPolyline: function (mapId, polyline, objectReference) {
        const layer = L.polyline(shapeToLatLngArray(polyline.shape), createPolyline(polyline));

        layers[mapId].push(layer);
        layer.addTo(maps[mapId]);

        if (polyline.tooltip) {
            addTooltip(layer, polyline.tooltip);
        }

        if (polyline.popup) {
            addPopup(layer, polyline.popup);
        }
    },
    addPolygon: function (mapId, polygon, objectReference) {
        const layer = L.polygon(shapeToLatLngArray(polygon.shape), createPolyline(polygon));

        layers[mapId].push(layer);
        layer.addTo(maps[mapId]);

        if (polygon.tooltip) {
            addTooltip(layer, polygon.tooltip);
        }

        if (polygon.popup) {
            addPopup(layer, polygon.popup);
        }
    },
    addRectangle: function (mapId, rectangle, objectReference) {
        const layer = L.rectangle([[rectangle.shape.bottom, rectangle.shape.left], [rectangle.shape.top, rectangle.shape.right]], createPolyline(rectangle));

        layers[mapId].push(layer);
        layer.addTo(maps[mapId]);

        if (rectangle.tooltip) {
            addTooltip(layer, rectangle.tooltip);
        }

        if (rectangle.popup) {
            addPopup(layer, rectangle.popup);
        }
    },
    addCircle: function (mapId, circle, objectReference) {
        const layer = L.circle([circle.position.x, circle.position.y],
            {
                ...createPath(circle),
                radius: circle.radius
            });

        layers[mapId].push(layer);
        layer.addTo(maps[mapId]);

        if (circle.tooltip) {
            addTooltip(layer, circle.tooltip);
        }

        if (circle.popup) {
            addPopup(layer, circle.popup);
        }
    },
    addImageLayer: function (mapId, image, objectReference) {
        const layerOptions = {
            ...createInteractiveLayer(image),
            opacity: image.opacity,
            alt: image.alt,
            crossOrigin: image.crossOrigin,
            errorOverlayUrl: image.errorOverlayUrl,
            zIndex: image.zIndex,
            className: image.className
        };

        const corner1 = L.latLng(image.corner1.x, image.corner1.y);
        const corner2 = L.latLng(image.corner2.x, image.corner2.y);
        const bounds = L.latLngBounds(corner1, corner2);

        const imgLayer = L.imageOverlay(image.url, bounds, layerOptions);
        layers[mapId].push(imgLayer);
        imgLayer.addTo(maps[mapId]);
    },
    removeLayer: function (mapId, layerId) {
        const remainingLayers = layers[mapId].filter((layer) => layer.id !== layerId);
        const layersToBeRemoved = layers[mapId].filter((layer) => layer.id === layerId); // should be only one ...
        layers[mapId] = remainingLayers;

        layersToBeRemoved.forEach(m => m.removeFrom(maps[mapId]));
    },
    fitBounds: function (mapId, corner1, corner2, padding, maxZoom) {
        const corner1LL = L.latLng(corner1.x, corner1.y);
        const corner2LL = L.latLng(corner2.x, corner2.y);
        const mapBounds = L.latLngBounds(corner1LL, corner2LL);
        maps[mapId].fitBounds(mapBounds, {
            padding: padding == null ? null : L.point(padding.x, padding.y),
            maxZoom: maxZoom
        });
    },
    panTo: function (mapId, position, animate, duration, easeLinearity, noMoveStart) {
        const pos = L.latLng(position.x, position.y);
        maps[mapId].panTo(pos, {
            animate: animate,
            duration: duration,
            easeLinearity: easeLinearity,
            noMoveStart: noMoveStart
        });
    }
};

function createIcon(icon) {
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

function createPolyline(polyline) {
    return {
        ...createPath(polyline),
        smoothFactor: polyline.smoothFactor,
        noClip: polyline.noClipEnabled
    };
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

function createLayer(obj) {
    return {
        id: obj.id,
        pane: obj.pane,
        attribution: obj.attribution
    };
}

function getColorString(color) {
    return "rgb(" + color.r + "," + color.g + "," + color.b + ")";
}

function addTooltip(layerObj, tooltip) {
    layerObj.bindTooltip(tooltip.content,
        {
            pane: tooltip.pane,
            offset: L.point(tooltip.offset.x, tooltip.offset.y),
            direction: tooltip.direction,
            permanent: tooltip.isPermanent,
            sticky: tooltip.isSticky,
            opacity: tooltip.opacity
        });
}

function addPopup(layerObj, popup) {
    layerObj.bindPopup(popup.content, {
        pane: popup.pane,
        className: popup.className,
        maxWidth: popup.maximumWidth,
        minWidth: popup.minimumWidth,
        autoPan: popup.autoPanEnabled,
        autoPanPaddingTopLeft: popup.autoPanPaddingTopLeft ? L.point(popup.autoPanPaddingTopLeft.x, popup.autoPanPaddingTopLeft.y) : null,
        autoPanPaddingBottomRight: popup.autoPanPaddingBottomRight ? L.point(popup.autoPanPaddingBottomRight.x, popup.autoPanPaddingBottomRight.y) : null,
        autoPanPadding: L.point(popup.autoPanPadding.x, popup.autoPanPadding.y),
        keepInView: popup.keepInView,
        closeButton: popup.showCloseButton,
        autoClose: popup.autoClose,
        closeOnEscapeKey: popup.closeOnEscapeKey,
    });
}

// #region events

// removes properties that can cause circular references
function cleanupEventArgsForSerialization(eventArgs) {
    return Object.assign(eventArgs,
    {
        target: undefined,
        sourceTarget: undefined,
        propagatedFrom: undefined
    });
}


function connectLayerEvents(layer, objectReference) {

    layer.on("add", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyAdd", cleanupEventArgsForSerialization(eventArgs));
    });

    layer.on("remove", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyRemove", cleanupEventArgsForSerialization(eventArgs));
    });

    layer.on("popupopen", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyPopupOpen", cleanupEventArgsForSerialization(eventArgs));
    });

    layer.on("popupclose", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyPopupClose", cleanupEventArgsForSerialization(eventArgs));
    });

    layer.on("tooltipopen", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyTooltipOpen", cleanupEventArgsForSerialization(eventArgs));
    });

    layer.on("tooltipclose", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyTooltipClose", cleanupEventArgsForSerialization(eventArgs));
    });
}


function connectInteractiveLayerEvents(interactiveLayer, objectReference) {

    connectLayerEvents(interactiveLayer, objectReference);

    interactiveLayer.on("click", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyClick", cleanupEventArgsForSerialization(eventArgs));
    });

    interactiveLayer.on("dblclick", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyDblClick", cleanupEventArgsForSerialization(eventArgs));
    });

    interactiveLayer.on("mousedown", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyMouseDown", cleanupEventArgsForSerialization(eventArgs));
    });

    interactiveLayer.on("mouseup", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyMouseUp", cleanupEventArgsForSerialization(eventArgs));
    });

    interactiveLayer.on("mouseover", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyMouseOver", cleanupEventArgsForSerialization(eventArgs));
    });

    interactiveLayer.on("mouseout", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyMouseOut", cleanupEventArgsForSerialization(eventArgs));
    });

    interactiveLayer.on("contextmenu", function (eventArgs) {
        objectReference.invokeMethodAsync("NotifyContextMenu", cleanupEventArgsForSerialization(eventArgs));
    });
}

// #endregion