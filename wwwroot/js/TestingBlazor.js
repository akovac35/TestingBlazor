TestingBlazor = {
    renderJson: function (elementId, json) {
        document.getElementById(elementId).appendChild(renderjson(JSON.parse(json)));
    }
}