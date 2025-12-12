window.loadScript = function (url) {
    return new Promise(function (resolve, reject) {
        if (document.querySelector(`script[src="/js/${url}"]`)) {
            resolve();
            return;
        }
        var script = document.createElement('script');
        script.src = "js/" + url;
        script.type = "text/javascript";
        script.onload = resolve;
        script.onerror = reject;
        document.body.appendChild(script);
    });
};